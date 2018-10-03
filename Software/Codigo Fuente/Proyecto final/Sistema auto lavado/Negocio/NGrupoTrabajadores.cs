using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NGrupoTrabajadores
    {
        public List<EGrupoTrabajadores> obtenerLista() {
            try {
                DgrupoTrabajadores datosGT = new DgrupoTrabajadores();
                return datosGT.SelectRow();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InsertRow(EGrupoTrabajadores IgrupoT) {
            try {
                if (IgrupoT.grupoTrabajadores == null)
                    throw new ArgumentException("Ingresa el grupo");
                DgrupoTrabajadores gestion = new DgrupoTrabajadores();
                gestion.InsertRow(IgrupoT);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void UpdateRow(EGrupoTrabajadores UgrupoT)
        {
            try
            {
                if (UgrupoT.grupoTrabajadores == null)
                    throw new ArgumentException("Ingresa el grupo");
                DgrupoTrabajadores gestion = new DgrupoTrabajadores();
                gestion.UpdateRow(UgrupoT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
