using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Edevolucion
    {
        public int idDevolucion { get; set; }
        public Eventa Venta { get; set; }
        public EUsuario Usuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string Observacion { get; set; }
        public List<Edetalledevolucion> listadetalle { get; set; }

        public Edevolucion()
        {

            Venta = new Eventa();
            Usuario = new EUsuario();

            listadetalle = new List<Edetalledevolucion>();
        }

    }
}
