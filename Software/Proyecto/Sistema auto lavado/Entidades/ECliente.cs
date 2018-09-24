using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ECliente
    {
        public int? idCliente { get; set; }
        public string nombres { get; set; }
        public string apellido { get; set; } 
        public string correo { get; set; }
        public int? celular { get; set; }
        public string estado { get; set; }
    }
}
