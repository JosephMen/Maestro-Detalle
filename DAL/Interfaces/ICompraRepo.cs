using DAL.Models;
namespace DAL.Interfaces
{
    public interface ICompraRepo: IGenericRepository<Compra>
    {
        /// <summary>
        /// Registra una compra nueva junto con sus detalles
        /// </summary>
        /// <param name="compra"></param>
        /// <returns>La compra registrada con su id asignado</returns>
        Task<Compra?> RegistrarCompra(Compra compra);
        /// <summary>
        /// Elimina una compra en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un valor de verdad si la operacion fue exitosa</returns>
        Task<bool> EliminarCompra(int id);
        /// <summary>
        /// Elimina una compra especifica
        /// </summary>
        /// <param name="compra">el id de la compra a eliminar</param>
        /// <returns>Un valor de verdad si la operacion fue exitosa</returns>
        Task<bool> ActualizarCompra (Compra compra);
    }
}
