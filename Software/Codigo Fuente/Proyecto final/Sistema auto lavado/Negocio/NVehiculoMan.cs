using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NVehiculoMan
    {
        public List<EVehiculoMantenimiento> ObtenerListaVehiculoMan()
        {
            try
            {
                DVehiculoMantenimiento datosVehiculoMan = new DVehiculoMantenimiento();
                return datosVehiculoMan.obtenerVehiculoMan();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Modificar(EVehiculoMantenimiento ModificarVehiculoMan)
        {
            try
            {
                if (ModificarVehiculoMan.vehiculoMantenimiento.Length < 3)
                    throw new ArgumentException("Ingresa el tipo de vehiculo");


                DVehiculoMantenimiento gestionaVehiculoMan = new DVehiculoMantenimiento();
                gestionaVehiculoMan.Modificar(ModificarVehiculoMan);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Agregar(EVehiculoMantenimiento AgregarVehiculoMan)
        {
            try
            {
                if (AgregarVehiculoMan.vehiculoMantenimiento.Length < 3)
                    throw new ArgumentException("Ingresa el tipo de vehiculo");


                DVehiculoMantenimiento gestionaVehiculoMan = new DVehiculoMantenimiento();
                gestionaVehiculoMan.Agregar(AgregarVehiculoMan);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
