using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
     public class Eventa
    {
        public int Num_venta { get; set; }
        public ECliente Cliente { get; set; }
        public EUsuario Usuario { get; set; }
        public DateTime? FechaFactura { get; set; }
        public string Tipopago { get; set; }
        public string Estado { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? TotalCordobas { get; set; }
        public decimal? TotalDolares { get; set; }
        public List<Edetalleventa> listadetalle { get; set; }

        public Eventa() {

            Cliente = new ECliente();
            Usuario = new EUsuario();
            listadetalle = new List<Edetalleventa>();
        }
    }
}
