using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ealmacen
    {
        public int? IdAlmcen { get; set; }
        public Ecategoria Categoria { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public string NombreCategoria { get; set; }


        public Ealmacen()
        {
            Categoria = new Ecategoria();


        }
         



    }
}
