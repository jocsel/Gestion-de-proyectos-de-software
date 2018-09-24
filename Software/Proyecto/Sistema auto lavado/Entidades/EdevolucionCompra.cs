using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EdevolucionCompra
    {

        public int idDevolucion { get; set; }
        public Ecompra Compra { get; set; }
        public EUsuario Usuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string Observacion { get; set; }
        public List<EdetalledevolucionCOMPRA> listadetalle { get; set; }

        public EdevolucionCompra()
        {

            Compra = new Ecompra();
            Usuario = new EUsuario();
            listadetalle = new List<EdetalledevolucionCOMPRA>();
        }
    }
}
