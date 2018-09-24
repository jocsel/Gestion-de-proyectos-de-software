using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NServicioVehiculo
    {
        public List<EServicioVehiculo> ObtenerServicioV()
        {
            try
            {
                DServicioVehiculo datosServicioV = new DServicioVehiculo();
                return datosServicioV.obtenerlistaSericioV();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(EServicioVehiculo ModificarServicioV)
        {
            try
            {
                if (ModificarServicioV.idServicioMantenimiento.idServicioMantenimiento == null)
                    throw new ArgumentException("Ingresa un tipo de servicio");
                if (ModificarServicioV.idVehiculoMantenimiento.idVehiculoMantenimiento == null)
                    throw new ArgumentException("Ingresa un tipo de vehiculo");
                if (ModificarServicioV.precio == null)
                    throw new ArgumentException("Ingresa un precio del servicio");
                if (ModificarServicioV.precio <= 0)
                    throw new ArgumentException("Ingresa un precio  valido");


                DServicioVehiculo gestionaServicioV = new DServicioVehiculo();
                gestionaServicioV.Modificar(ModificarServicioV);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Agregar(EServicioVehiculo AgregarServicioV)
        {
            try
            {
                if (AgregarServicioV.idServicioMantenimiento.idServicioMantenimiento ==null)
                    throw new ArgumentException("Ingresa un tipo de servicio");
                if (AgregarServicioV.idVehiculoMantenimiento.idVehiculoMantenimiento == null)
                    throw new ArgumentException("Ingresa un tipo de vehiculo");
                if (AgregarServicioV.precio == null)
                    throw new ArgumentException("Ingresa un precio del servicio");
                if (AgregarServicioV.precio <=0)
                    throw new ArgumentException("Ingresa un precio  valido");



                DServicioVehiculo gestionaServicioV = new DServicioVehiculo();
                gestionaServicioV.Agregar(AgregarServicioV);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
