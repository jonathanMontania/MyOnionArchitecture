using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException() : base("Categoria/s not encontrada/s") { }
    }
}
