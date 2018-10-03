using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EdetalledevolucionCOMPRA
    {
        public int? Cantidad { get; set; }
        public EdevolucionCompra Devolucion { get; set; }
        public Eproductos producto { get; set; }
        public string observacion { get; set; }

        public EdetalledevolucionCOMPRA()
        {

            Devolucion = new EdevolucionCompra();
            producto = new Eproductos();

        }

    }
}
