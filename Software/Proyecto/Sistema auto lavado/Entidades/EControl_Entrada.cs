using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class EControl_Entrada
    {
        public EUsuario usuario { get; set; }
        public DateTime loginn { get; set; }
        public DateTime logout { get; set; }
        public int idControl { get; set; }
        public string maquina { get; set; }
        public string Empleado { get; set; }

        public EControl_Entrada()
        {
            usuario = new EUsuario();
        }
    }
}
