using DAL.Models;
using DAL.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSite.Utils.Interface;

namespace WebSite.Controllers
{
    public class DetalleCompraController : Controller
    {
        private readonly IServiceAPI _service;
        public DetalleCompraController(IServiceAPI service)
        {
            _service = service;
        }
        // GET: DetalleCompra
        /// <summary>
        /// Pagina donde se pueden ver los detalles relacionados a una Compra
        /// </summary>
        /// <param name="idCompra">Id de la compra</param>
        /// <returns>Vista</returns>
        public async Task<ActionResult> Index(int idCompra)
        {
            @ViewBag.MostrarMensaje = false;

            Compra compra = await _service.ObtenerCompra(idCompra);
            CompraVistaVM compraVista = new();
            List<DetalleMostrarVM> detallesCompra = await _service.ObtenerDetallesCompra(idCompra);

            compraVista.Id = idCompra;
            compraVista.Razon = compra.Razon;
            compraVista.NumeroDocumento = compra.NumeroDocumento;
            compraVista.DetalleCompras = detallesCompra;
            return View(compraVista);
        }

        /// <summary>
        /// Permite eliminar un registro del detalle
        /// </summary>
        /// <param name="id">Id del detalle de la compra</param>
        /// <returns>Retorna una respuesa exitosa si fue eliminado</returns>
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _service.EliminarDetalle(id);
            if (result)
                return Ok(result);
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
