using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMantenimineto
    {
        public int idMantenimiento { get; set; }
        public decimal? total { get; set; }
        public DateTime? fecha { get; set; }
        public string placa { get; set; }
        public EGrupoTrabajadores idgrupo { get; set; }
        public EServicioVehiculo idservicioVehiculo { get; set; }
        public EUsuario usuario { get; set; }

        public EMantenimineto()
        {
            idgrupo = new EGrupoTrabajadores();
            idservicioVehiculo = new EServicioVehiculo();
            usuario = new EUsuario();

        }

    }
}
