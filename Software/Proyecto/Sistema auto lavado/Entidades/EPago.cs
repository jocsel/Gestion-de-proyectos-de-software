using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EPago
    {
        public int? numeroDocumento { get; set; }
        public decimal? cordobas { get; set; }
        public decimal? dolares { get; set; }
        public decimal? vuelto { get; set; }
        public DateTime? fecha { get; set; }
        public EUsuario EUsuario { get; set; }
        public decimal? montoFactura { get; set; }
        public EEmpleado EEmpleado { get; set; }

        public EPago()
        {
            EUsuario = new EUsuario();
            EEmpleado = new EEmpleado();
        }
    }
}
