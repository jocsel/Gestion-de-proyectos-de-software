using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Ndetalledevolucioncompra
    {
        public List<EdetalledevolucionCOMPRA> obtenerlistdetalle()
        {

            try
            {

                DdetalledevolucionCompra datosdetalle = new DdetalledevolucionCompra();
                return datosdetalle.obtenerlistadetalle();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
