using DAL.Models;
using DAL.Models.ViewModels;

namespace WebSite.Utils.Interface
{
    public interface IServiceAPI
    {
        /// <summary>
        /// Obtiene la lista de compras de la base de datos
        /// </summary>
        /// <returns>Lista de compras</returns>
        Task<List<Compra>> ObtenerCompras();
        /// <summary>
        ///  Obtiene una compra especifica
        /// </summary>
        /// <param name="id">Id de la compra</param>
        /// <returns>Una compra especifica</returns>
        Task<Compra?> ObtenerCompra(int id);
        /// <summary>
        /// Edita los valores de una compra
        /// </summary>
        /// <param name="compra">Objeto compra donde vienen los nuevos valores</param>
        /// <returns>verdadero si se realizo exitosamente la </returns>
        Task<bool> EditarCompra(Compra compra);
        /// <summary>
        /// Obtiene los detalles asociados a una compra
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns>Lista de detalles</returns>
        Task<List<DetalleMostrarVM>> ObtenerDetallesCompra(int idCompra);
        /// <summary>
        /// Elimina el registro de detalle compra
        /// </summary>
        /// <param name="idDetalle">Id del detalle a eliminar</param>
        /// <returns>Verdadero si se pudo eliminar exitosamente</returns>
        Task<bool> EliminarDetalle(int idDetalle);
    }
}
