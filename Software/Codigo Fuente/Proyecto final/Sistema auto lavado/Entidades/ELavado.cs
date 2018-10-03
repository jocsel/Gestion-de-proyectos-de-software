using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ELavado
    {
        public int idLavado { get; set; }
        public decimal? total { get; set; }
        public DateTime? fecha { get; set; }
        public string placa { get; set; }
        public ELavadoVehiculo LavadoVehiculo { get; set; }
        public EGrupoTrabajadores grupoTrabajadores { get; set; }
        public EUsuario usuario { get; set; }
        public EEmpleado empleado { get; set; }
        public EVehiculoLavado vehiculoLavado { get; set; }
        public EServicioLavado servicioLavado { get; set; }
        public ELavado()
        {
            LavadoVehiculo = new ELavadoVehiculo();
            grupoTrabajadores = new EGrupoTrabajadores();
            usuario = new EUsuario();
            empleado = new EEmpleado();
            vehiculoLavado = new EVehiculoLavado();
            servicioLavado = new EServicioLavado();
        }
    }
}
