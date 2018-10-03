using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Ninactivo_anulada
    {

        public List<Eventa> obtenerlistventaANULADA()
        {

            try
            {
                Dinactivo_cancelada datosventa = new Dinactivo_cancelada();
                return datosventa.obtenerlistaventaANULADAS();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ECliente> obtenerlistClientesANULADO()

        {
            try
            {
                Dinactivo_cancelada datos = new Dinactivo_cancelada();
                return datos.obtenerlistaclienteINACTIVA();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Eproductos> obtenerlistproductoANULADO()

        {
            try
            {
                Dinactivo_cancelada datos = new Dinactivo_cancelada();
                return datos.obtenerlistaproductoINACTIVO();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
