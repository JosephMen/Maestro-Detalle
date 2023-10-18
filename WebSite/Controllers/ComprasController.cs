using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using WebSite.Utils.Interface;

namespace WebSite.Controllers
{
    public class ComprasController : Controller
    {
        private readonly IServiceAPI _service;
        public ComprasController(IServiceAPI service)
        {
            _service = service;
        }
        /// <summary>
        /// Vista de las compras registradas
        /// </summary>
        /// <returns>La vista</returns>
        public async Task<ActionResult> Index()
        {
            var lista = await _service.ObtenerCompras();
            return View(lista);
        }

        /// <summary>
        /// Obtiene la vista de edicion de la compra
        /// </summary>
        /// <param name="id">id de la compra</param>
        /// <returns>Vista</returns>
        public async Task<ActionResult> Edit(int id)
        {
            @ViewBag.MostrarMensaje = false;
            @ViewBag.MostrarMensaje = false;
            var compra = await _service.ObtenerCompra(id);
            return View(compra);
        }
        /// <summary>
        /// Metodo que recibe y actualiza las propiedades de la compra
        /// </summary>
        /// <param name="compra"></param>
        /// <returns>Vista</returns>
        [HttpPost]
        public async Task<ActionResult> Edit(Compra compra)
        {
            try
            {
                var actualizado = await _service.EditarCompra(compra);
                @ViewBag.Actualizado = actualizado;
                @ViewBag.MostrarMensaje = true;
                return View();
            }
            catch
            {
                @ViewBag.Actualizado = false;
                @ViewBag.MostrarMensaje = true;
                return View();
            }
        }

    }
}
