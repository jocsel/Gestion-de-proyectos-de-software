using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ecategoria
    {
        public int? CodCategoria { get; set; }

        public string Tipo { get; set; }

        public Eproductos Producto { get; set; }

        public string Nombredelproducto { get; set; }

        public Ecategoria()
        {
            Producto = new Eproductos();

        }
            
        


    }
}
