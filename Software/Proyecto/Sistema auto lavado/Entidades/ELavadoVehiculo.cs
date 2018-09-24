using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ELavadoVehiculo
    {
        public int? idLavadoVehiculo { get; set; }
        public EServicioLavado servicioLavado { get; set; }
        public EVehiculoLavado vehiculoLavado { get; set; }
        public decimal? precio { get; set; }
        public ELavadoVehiculo() {
            servicioLavado = new EServicioLavado();
            vehiculoLavado = new EVehiculoLavado();
        }
    }
}
