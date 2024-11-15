using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAllAsync();

        Task<Categoria> GetByIdAsync(int id);

        Task AddAsync(Categoria categoria);
    }
}
