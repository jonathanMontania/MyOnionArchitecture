﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
