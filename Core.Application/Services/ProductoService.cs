using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;

namespace Core.Application.Services
{
    //Se implementa la interfaz del servicio
    public class ProductoService : IProductoService
    {
        //Se inyecta la interfaz del repository para poder acceder a sus metodos
        private readonly IProductoRepository _productoRepository;

        public ProductoService (IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            try
            {
                return await _productoRepository.GetAllAsync();
            }
            catch (ProductNotFoundException ex)
            {
                throw new ProductNotFoundException();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }            
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _productoRepository.GetByIdAsync(id);
        }

        public async Task AddProductoAsync(Producto producto)
        {
            await _productoRepository.AddAsync(producto);
        }
    }
}
