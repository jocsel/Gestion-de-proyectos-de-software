using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
  public  class NServicioMantenimiento
    {

        public List<EServicioMantenimiento> ObtenerListaServicioM()
        {
            try
            {
                DServicioMantenimiento datosServicioM = new DServicioMantenimiento();
                return datosServicioM.obtenerlistaSericioM();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Modificar(EServicioMantenimiento ModificarServicioM)
        {
            try
            {
                if (ModificarServicioM.servicioMantenimiento.Length <4 )
                    throw new ArgumentException("Ingresa el tipo de servicio");


                DServicioMantenimiento gestionaServicioM = new DServicioMantenimiento();
                gestionaServicioM.Modificar(ModificarServicioM);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Agregar(EServicioMantenimiento AgregarServicioM)
        {
            try
            {
                if (AgregarServicioM.servicioMantenimiento.Length < 4 )
                    throw new ArgumentException("Ingresa el tipo de servicio");


                DServicioMantenimiento gestionaServicioM = new DServicioMantenimiento();
                gestionaServicioM.Agregar(AgregarServicioM);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
