using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Eproductos
    {
        public int Codproducto { get; set; }
        public string Producto { get; set; }
        public string CodSac { get; set; }
        public int? Existencia { get; set; }
        public decimal? Costo { get; set; }
        public decimal? Precio { get; set; }
        public bool? Activo { get; set; }
        public EMarcas Marca { get; set; }

        public Eproductos()
        {
            Marca = new EMarcas();

        }


    }
}
