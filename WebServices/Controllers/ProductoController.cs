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
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepo _context;
        private readonly IMapper _mapper;
        public ProductoController(IProductoRepo context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Retorna la lista de productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = _mapper.Map<List<ProductoVM>>((await _context.GetAllAsync()).ToList());
            return Ok(productos);
        }

    }
}
