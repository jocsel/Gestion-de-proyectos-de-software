using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EAuditoriaMantenimiento
    {
        public int idmantenimiento { get; set; }
        public string realizado { get; set; }
        public decimal? total { get; set; }
        public DateTime? fecha { get; set; }
        public string placa { get; set; }
        public string tecnicos { get; set; }
        public string servicio { get; set; }
        public string vehiculo { get; set; }
        public DateTime? creado { get; set; }
        public DateTime? Modificado { get; set; }
        public string Accion { get; set; }
    }
}
