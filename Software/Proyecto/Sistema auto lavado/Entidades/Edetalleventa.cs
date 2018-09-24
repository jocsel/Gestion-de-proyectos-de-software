using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Edetalleventa
    {

        public int? Cantidad { get; set; }
        public Eventa Venta { get; set; }
        public Eproductos producto { get; set ; }       
        public decimal? Totaldetalle { get; set; }

        public Edetalleventa() {

            Venta = new Eventa();
            producto = new Eproductos();

        }


    }
}
