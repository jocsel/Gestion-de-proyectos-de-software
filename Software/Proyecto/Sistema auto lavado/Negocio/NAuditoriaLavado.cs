using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NAuditoriaLavado
    {
        public List<EAuditoriaLavado> SelectRow() {
            try {
                DAuditoriaLavado DUL = new DAuditoriaLavado();
                return DUL.SelectRow();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
