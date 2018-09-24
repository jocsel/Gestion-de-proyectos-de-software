using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EdetalleCompra
    {
        public int? Cantidad { get; set; }
        public Ecompra Compra { get; set; }
        public Eproductos producto { get; set; }
        public decimal? Total { get; set; }

        public EdetalleCompra()
        {

            Compra = new Ecompra();
            producto = new Eproductos();

        }

    }
}
