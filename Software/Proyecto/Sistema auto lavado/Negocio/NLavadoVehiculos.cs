using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
   public class NLavadoVehiculos
    {
        public List<ELavadoVehiculo> selectRow() {
            DLavadoVehiculo lista = new DLavadoVehiculo();
            return lista.SelectRow();
        }

        public void insertRow(ELavadoVehiculo ILV) {
            if (ILV.servicioLavado.idServicioLavado == 0)
                throw new ArgumentException("Ingresa el tipo de servicio");
            if (ILV.vehiculoLavado.idVehiculoLavado == 0)
                throw new ArgumentException("Ingresa el tipo de vehiculo");
            if (ILV.precio == 0)
                throw new ArgumentException("Ingresa el precio del servicio");
            DLavadoVehiculo InsertLV = new DLavadoVehiculo();
            InsertLV.InsertRow(ILV);
        }
        public void UpdateRow(ELavadoVehiculo ULV)
        {
            if (ULV.servicioLavado.idServicioLavado == 0)
                throw new ArgumentException("Ingresa el tipo de servicio");
            if (ULV.vehiculoLavado.idVehiculoLavado == 0)
                throw new ArgumentException("Ingresa el tipo de vehiculo");
            if (ULV.precio == 0)
                throw new ArgumentException("Ingresa el precio del servicio");
            DLavadoVehiculo UpdatetLV = new DLavadoVehiculo();
            UpdatetLV.UpdateRow(ULV);
        }
    }
}
