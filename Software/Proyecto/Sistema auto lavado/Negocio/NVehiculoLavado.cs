using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NVehiculoLavado
    {
        public List<EVehiculoLavado> SelectRow() {
            try {
                DVehiculoLavado listar = new DVehiculoLavado();
                return listar.SelectRow();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InsertRow(EVehiculoLavado InsertVL) {
            try {
                if (InsertVL.vehiculoLavado == null)
                    throw new ArgumentException("Ingresa el vehiculo");
                
                DVehiculoLavado Insert = new DVehiculoLavado();
                Insert.InsertRow(InsertVL);
            }
            catch (Exception ex) {
                throw ex;
            }

        }
        public void UpdaetRow(EVehiculoLavado UpdateVL)
        {
            try
            {
                if (UpdateVL.vehiculoLavado == null)
                    throw new ArgumentException("Ingresa el vehiculo");
                DVehiculoLavado update = new DVehiculoLavado();
                update.UpdateRow(UpdateVL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
