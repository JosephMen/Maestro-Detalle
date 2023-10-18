using DAL.Models;
namespace DAL.Interfaces
{
    public interface IDetalleCompraRepo: IGenericRepository<DetalleCompra>
    {
        Task<bool> ActualizarDetalleCompra(DetalleCompra compra);
        /// <summary>
        /// Elimina una detalle en especifico
        /// </summary>
        /// <param name="id">el id del detalle a eliminar</param>
        /// <returns>Un valor de verdad si la operacion fue exitosa</returns>
        Task<bool> EliminarDetalleCompra(int id);
        /// <summary>
        /// Obtiene los detalles dado el id de la compra asociada
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns>Una lista de tipo detallesCompra</returns>
        Task<List<DetalleCompra>> ObtenerPorCompra(int idCompra);
    }
}
