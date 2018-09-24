using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;

namespace Negocio
{
    public class NArea
    {
        public List<EArea> listaArea() {
            try {
                DArea lista = new DArea();
                return lista.SelectRow();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InsertRow(EArea IArea) {
            try {
                if (IArea.area.Length == 0)
                    throw new ArgumentException("Ingresa el area");
                DArea gestionArea = new DArea();
                gestionArea.InsertRow(IArea);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void UpdateRow(EArea UArea)
        {
            try
            {
                if (UArea.area.Length == 0)
                    throw new ArgumentException("Ingresa el area");
                DArea gestionArea = new DArea();
                gestionArea.UpdateRow(UArea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
