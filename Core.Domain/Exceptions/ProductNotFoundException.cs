using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    //Aca hago una exception customizada
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Producto/s no encontrado/s"){ }
    }
}
