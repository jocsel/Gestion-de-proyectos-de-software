using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Edetalledevolucion
    {


        public int? Cantidad { get; set; }
        public Edevolucion Devolucion { get; set; }
        public Eproductos producto { get; set; }
        public string observacion { get; set; }

        public Edetalledevolucion()
        {

            Devolucion = new Edevolucion();
            producto = new Eproductos();

        }
    }
}
