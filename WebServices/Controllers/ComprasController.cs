using Microsoft.AspNetCore.Mvc;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using AutoMapper;
using DAL.Models.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraRepo _context;
        private readonly IMapper _mapper;
        public ComprasController(ICompraRepo context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        /// <summary>
        /// Obtiene la lista de compras registradas
        /// </summary>
        /// <returns>Lista de objetos comprasVM</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var comprasVM = _mapper.Map<List<CompraMostrarVM>>(await _context.GetAllAsync());
                return Ok(new { data = comprasVM });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message});
            }
        }
        /// <summary>
        /// Obtiene la informacion de una compra especifica
        /// </summary>
        /// <param name="id">Id de la compra a consultar</param>
        /// <returns>Objeto compra</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var variable = await _context.Get(compra => compra.Id == id);
            CompraVM compra = _mapper.Map<CompraVM>(variable.ToList().FirstOrDefault());
            if (compra == null)
            {
                return NotFound(new { message = "Register not found"});
            }
            return Ok(new { data = compra });
        }
        /// <summary>
        /// Actualiza la informacion del registro compras
        /// </summary>
        /// <param name="compra"></param>
        /// <returns>Un valor de verdad si la operacion fue realizada con exitos</returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CompraActualizarVM compra)
        {
            try
            {
                if (compra != null)
                {
                    bool exito = await _context.ActualizarCompra(_mapper.Map<Compra>(compra));
                    return Ok(new { data = exito });
                }
                return BadRequest(new { message = "No body format founded" });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {ex.Message});
            }
        }

    }
}
