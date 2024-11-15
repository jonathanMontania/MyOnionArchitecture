using Core.Application.Interfaces;
using Core.Application.Services;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MyOnionArchitecture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService) 
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            try
            {
                var categorias = await _categoriaService.GetAllAsync();
                return Ok(categorias);
            }
            catch (CategoryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            try
            {
                var categoria = await _categoriaService.GetByIdAsync(id);
                return Ok(categoria);
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
        public async Task<IActionResult> AddCategoria(Categoria categoria)
        {
            try
            {
                await _categoriaService.AddAsync(categoria);
                return Created(new Uri(Request.GetEncodedUrl() + "/" + categoria.Id), categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
