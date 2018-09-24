using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EAuditoriaLavado
    {
        public int idLavadoAL { get; set; }
        public string accion { get; set; }
        public string placa { get; set; }
        public DateTime? fecha { get; set; }
        public DateTime? fechaCreada { get; set; }
        public DateTime? fechaModificado { get; set; }
        public ELavado Lavado { get; set; }
        public EUsuario usuario { get; set; }
        public EGrupoTrabajadores GrupoTrabajadores { get; set; }
        public ELavadoVehiculo LavadoVehiculo{ get; set; }
        public EServicioLavado ServicioLavado { get; set; }
        public EVehiculoLavado VehiculoLavado { get; set; }
        public EEmpleado empleado { get; set; }
        public decimal? total { get; set; }

        public EAuditoriaLavado() {
            Lavado = new ELavado();
            usuario = new EUsuario();
            GrupoTrabajadores = new EGrupoTrabajadores();
            LavadoVehiculo = new ELavadoVehiculo();
            ServicioLavado = new EServicioLavado();
            VehiculoLavado = new EVehiculoLavado();
            empleado = new EEmpleado();
        }

    }
}
