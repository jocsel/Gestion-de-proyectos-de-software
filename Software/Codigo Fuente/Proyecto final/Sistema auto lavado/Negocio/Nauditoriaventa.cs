using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Nauditoriaventa
    {
        public List<EauditoriaVenta> Obtenerauditoriaventa()
        {
            try
            {
                Dauditoriaventa datos = new Dauditoriaventa();
                return datos.obtenerlistaauditoriaventa();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
