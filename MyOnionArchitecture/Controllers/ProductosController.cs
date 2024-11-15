using Core.Application.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MyOnionArchitecture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                var productos = await _productoService.GetAllProductosAsync();
                return Ok(productos);
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoById(int id)
        {
            try
            {
                var producto = await _productoService.GetProductoByIdAsync(id);
                return Ok(producto);
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddProducto(Producto producto)
        {
            try
            {
                await _productoService.AddProductoAsync(producto);
                return Created(new Uri(Request.GetEncodedUrl() + "/" + producto.Id), producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
