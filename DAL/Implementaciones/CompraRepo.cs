using DAL.Interfaces;
using DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace DAL.Implementaciones
{
    public class CompraRepo : GenericRepository<Compra>, ICompraRepo
    {
        private readonly AtomContext _context;
        public CompraRepo(AtomContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarCompra(Compra compra)
        {
            try
            {
                var exitoSql = new SqlParameter("@Exito", SqlDbType.Int);
                exitoSql.Direction = ParameterDirection.Output;
                await _context.Database
                    .ExecuteSqlInterpolatedAsync($@"Exec SPActualizarCompra 
                                                        @id = {compra.Id},
                                                        @NumeroDocumento = {compra.NumeroDocumento},
                                                        @Razon = {compra.Razon},
                                                        @Exito = {exitoSql} OUTPUT");
                int exito = (int)exitoSql.Value;
                return exito == 0;
            }catch
            {
                return false;
            }
        }

        public async Task<bool> EliminarCompra(int id)
        {
            try
            {
                var exitoSql = new SqlParameter("@Exito", SqlDbType.Int);
                exitoSql.Direction = ParameterDirection.Output;
                await _context.Database
                    .ExecuteSqlInterpolatedAsync($@"Exec SPBorrarCompra @id = {id}, @Exito = {exitoSql} OUTPUT");
                int exito = (int)exitoSql.Value;
                return exito == 0;
            }catch(Exception)
            {
                return false;
            }
        }

        public async Task<Compra?> RegistrarCompra(Compra compra)
        {
            Compra compraGenerada = new();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int total = 0;
                    foreach(DetalleCompra detalleCompra in compra.DetalleCompras)
                    {
                        Producto producto = _context.Productos.Where( p => p.Id == detalleCompra.IdProducto).First();
                        if (producto.Stock < detalleCompra.Cantidad) return null;
                        producto.Stock -= detalleCompra.Cantidad;
                        detalleCompra.Total = detalleCompra.Cantidad * producto.Precio;
                        total += (int)detalleCompra.Total;
                        _context.Update(producto);
                    }
                    await _context.SaveChangesAsync();
                    compra.Total = total;
                    await _context.Compras.AddAsync(compra);
                    await _context.SaveChangesAsync();

                    compraGenerada = compra;
                    transaction.Commit();
                }catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return compraGenerada;
        }

    }
}
