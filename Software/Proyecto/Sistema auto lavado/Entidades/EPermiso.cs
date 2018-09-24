using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EPermiso
    {
        public int PidUsuario{ get; set; }
        public bool facturar{ get; set; }
        public bool personas { get; set; }
        public bool producto { get; set; }
        public bool reporte { get; set; }
        public bool mantenimiento { get; set; }
        public bool lavado { get; set; }
        public bool btnFacturar { get; set; }
        public bool btnUsuarios { get; set; }
        public bool btnProducto { get; set; }
        public bool btnMantenimiento { get; set; }
        public bool btnLavado { get; set; }
        public bool btnPersonas { get; set; }
        public bool btnFacturarCompra { get; set; }
        public bool logs { get; set; }
        public string usuario { get; set; }
    }
}
