using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NauditoriaCompra
    {
        public List<Eauditoriacompra> obtenerlistcompra()
        {

            try
            {
                Dauditoriacompra datos = new Dauditoriacompra();
                return datos.obtenerlistacompra();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
