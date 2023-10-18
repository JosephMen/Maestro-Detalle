using DAL.Interfaces;
using DAL.Models;
using DAL.Models.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace DAL.Implementaciones
{
    public class DetalleCompraRepo :GenericRepository<DetalleCompra>, IDetalleCompraRepo
    {
        private readonly AtomContext _context;
        public DetalleCompraRepo(AtomContext context):base(context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarDetalleCompra(DetalleCompra detalleCompra)
        {
            try
            {
                var producto = _context.Productos.Where(p => p.Id == detalleCompra.IdProducto).FirstOrDefault();
                if (producto == null) return false;
                if (producto.Stock < detalleCompra.Cantidad) return false;
                var exitoSql = new SqlParameter("@Exito", SqlDbType.Int);
                exitoSql.Direction = ParameterDirection.Output;

                await _context.Database
                    .ExecuteSqlInterpolatedAsync($@"Exec SPActualizarDetalle 
                        @Id = {detalleCompra.Id},
                        @Cantidad = {detalleCompra.Cantidad},
                        @Exito = {exitoSql}"
                        );
                int exito = (int)exitoSql.Value;
                return exito == 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EliminarDetalleCompra(int id)
        {
            try
            {
                var exitoSql = new SqlParameter("@Exito", SqlDbType.Int);
                exitoSql.Direction = ParameterDirection.Output;
                await _context.Database
                    .ExecuteSqlInterpolatedAsync($@"Exec SPBorrarDetalle @Id = {id}, @Exito = {exitoSql} OUTPUT");
                int exito = (int)exitoSql.Value;
                return exito == 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<DetalleCompra>> ObtenerPorCompra(int idCompra)
        {
            List<DetalleCompra> result = await _context.DetalleCompras
                .Where(dc => dc.IdCompra == idCompra)
                .Include(dc => dc.IdProductoNavigation)
                .ToListAsync();
            return result;
        }
    }
}
