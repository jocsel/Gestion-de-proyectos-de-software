using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EEmpleado
    {
        public int idEmpleado{ get; set; }
        public int? celular { get; set; }
        public string direccion{ get; set; }
        public string cedula { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public decimal? salario { get; set; }
        public string cargo { get; set; }
        public string estado { get; set; }
        public EArea Area{ get; set; }
        public EGrupoTrabajadores GrupoTrabajadores  { get; set; }
        public EEmpleado() {
            Area = new EArea();
            GrupoTrabajadores = new EGrupoTrabajadores();
        }
    }
}
