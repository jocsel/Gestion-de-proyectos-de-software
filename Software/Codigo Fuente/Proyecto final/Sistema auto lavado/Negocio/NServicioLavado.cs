using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
   public class NServicioLavado
    {
        public List<EServicioLavado> SelectRow()
        {
            try
            {
                DServicioLavado listar = new DServicioLavado();
                return listar.SelectRow();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertRow(EServicioLavado InsertSL)
        {
            try
            {
                if (InsertSL.servicioLavado == null)
                    throw new ArgumentException("Ingresa el servicio");
                DServicioLavado Insert = new DServicioLavado();
                Insert.InsertRow(InsertSL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void UpdaetRow(EServicioLavado UpdateSL)
        {
            try
            {
                if (UpdateSL.servicioLavado == null)
                    throw new ArgumentException("Ingresa el servicio");
                DServicioLavado update = new DServicioLavado();
                update.UpdateRow(UpdateSL);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
