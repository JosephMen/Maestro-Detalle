using AutoMapper;
using DAL.Interfaces;
using DAL.Models;
using DAL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCompraController : ControllerBase
    {
        private readonly IDetalleCompraRepo _context;
        private readonly IMapper _mapper;
        public DetalleCompraController(IDetalleCompraRepo context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Vista donde se visualiza los detalles de la compra
        /// </summary>
        /// <param name="id">id de la compra </param>
        /// <returns>detalles de la compra como response</returns>
        [HttpGet]
        [Route("GetPorCompra/{id}")]
        public async Task<IActionResult> GetPorCompra(int id)
        {
            try
            {
                var detallesCompra = _mapper.Map<List<DetalleMostrarVM>>(await _context.ObtenerPorCompra(id));
                return Ok(new { data = detallesCompra });

            }catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        /// <summary>
        /// Obtiene el detalleCompra especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>El detalle especifico consultado</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var detallesCompra = _mapper.Map<List<DetalleMostrarVM>>(await _context.Get(dc => dc.Id == id)).FirstOrDefault();
                if (detallesCompra == null)
                {
                    return NotFound(new {message = "Register not Found"});
                }
                return Ok(new { data = detallesCompra });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        /// <summary>
        /// Actualiza los detalles de la tabla detalleCompra
        /// </summary>
        /// <param name="detalleCompra">El detalle con los valores a actualizar</param>
        /// <returns>Verdadero si se logro actualizar</returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DetalleActualizarVM detalleCompra)
        {
            try
            {
                var result = await _context.ActualizarDetalleCompra(_mapper.Map<DetalleCompra>(detalleCompra));
                return Ok(new { data = result });
            }catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); 
            }
        }
        /// <summary>
        /// Elimina el detalle especifico
        /// </summary>
        /// <param name="id">Id del detallea a eliminar</param>
        /// <returns>Verdadero si se elimino correctamente</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _context.EliminarDetalleCompra(id);
                return Ok(new { data = result });
            }catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
