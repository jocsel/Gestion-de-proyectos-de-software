using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EProveedor
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string RUC { get; set; }
        public string direccion { get; set; }
        public int idProveedor { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public bool estado { get; set; }
        public string nombreempresa { get; set; }
    }
}
