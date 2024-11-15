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
    public class CategoriaService : ICategoriaService
    {
        //Se inyecta la interfaz del repository para poder acceder a sus metodos
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService (ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            try
            {
                IEnumerable<Categoria> categorias = await _categoriaRepository.GetAllAsync();
                if (!categorias.Any())
                {
                    throw new CategoryNotFoundException();
                }
                return categorias;
            }
            catch (CategoryNotFoundException ex)
            {
                throw new CategoryNotFoundException();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            try
            {
                var categoria =  await _categoriaRepository.GetByIdAsync(id);

                if (categoria == null)
                {
                    throw new CategoryNotFoundException();
                }
                return categoria;
            }
            catch (CategoryNotFoundException ex)
            {
                throw new CategoryNotFoundException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddAsync(Categoria categoria)
        {
            try
            {
                await _categoriaRepository.AddAsync(categoria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
