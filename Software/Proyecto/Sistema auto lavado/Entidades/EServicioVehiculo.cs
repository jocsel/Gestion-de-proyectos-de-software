using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public  class EServicioVehiculo
    {
        public int idServicioVehiculo { get; set; }
        public EServicioMantenimiento idServicioMantenimiento { get; set; }
        public EVehiculoMantenimiento idVehiculoMantenimiento { get; set; }
        public decimal? precio { get; set; }
        public bool estado { get; set; }

        public EServicioVehiculo()
        {
            idServicioMantenimiento = new EServicioMantenimiento();
            idVehiculoMantenimiento = new EVehiculoMantenimiento();

        }
    }
}
