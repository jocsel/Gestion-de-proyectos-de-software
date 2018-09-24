using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EUsuario
    {
        public int? idUsuario{ get; set; }
        public string usuario{ get; set; }
        public string password { get; set; }
        public EEmpleado Empleado {get;set;}
        public EPermiso Permiso { get; set; }
        public string estado { get; set; }
        public EUsuario() {
            Empleado = new EEmpleado();
            Permiso = new EPermiso();
        }
    }
}
