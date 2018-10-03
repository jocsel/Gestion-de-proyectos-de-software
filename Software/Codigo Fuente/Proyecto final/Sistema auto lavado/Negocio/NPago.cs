using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NPago
    {
        public List<EPago> SelectRow()
        {
            DPago listaPago = new DPago();
            return listaPago.SelectRow();
        }

        public void InsertRow(EPago IPago)
        {
            try
            {
                if (IPago.numeroDocumento == 0)
                    throw new ArgumentException("Ingresa el numero de documento");
                if (IPago.cordobas == 0)
                    throw new ArgumentException("Ingresa la  cantidad en cordobas");
                if (IPago.dolares == 0)
                    throw new ArgumentException("Ingresa la  cantidad en dolares");
                if (IPago.vuelto == 0)
                    throw new ArgumentException("Ingresa el vuelto");
                if (IPago.fecha == null)
                    throw new ArgumentException("Ingresa la fecha");
                if (IPago.EUsuario.idUsuario == 0)
                    throw new ArgumentException("Ingresa el id del usuario");
                if (IPago.montoFactura == 0)
                    throw new ArgumentException("Ingresa el monto de la factura");
                DPago InsertarPago = new DPago();
                InsertarPago.InsertRow(IPago);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateRow(EPago UPago)
        {
            if (UPago.numeroDocumento == 0)
                throw new ArgumentException("Ingresa el numero de documento");
            if (UPago.cordobas == 0)
                throw new ArgumentException("Ingresa la  cantidad en cordobas");
            if (UPago.dolares == 0)
                throw new ArgumentException("Ingresa la  cantidad en dolares");
            if (UPago.vuelto == 0)
                throw new ArgumentException("Ingresa el vuelto");
            if (UPago.fecha == null)
                throw new ArgumentException("Ingresa la fecha");
            if (UPago.EUsuario.idUsuario == 0)
                throw new ArgumentException("Ingresa el id del usuario");
            if (UPago.montoFactura == 0)
                throw new ArgumentException("Ingresa el monto de la factura");
            DPago InsertarPago = new DPago();
            InsertarPago.UpdareRow(UPago);
        }
    }
}
