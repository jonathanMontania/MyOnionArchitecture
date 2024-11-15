using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Entities;

namespace Core.Domain.Interfaces
{
    public interface IProductoRepository
    {
        //Se usa el prefijo Task durante la creación de la firma de los metodos para indicar el uso de asincronismo
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task AddAsync(Producto producto);
    }
}
