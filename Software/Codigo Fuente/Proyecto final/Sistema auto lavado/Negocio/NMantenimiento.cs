using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
   public class NMantenimiento
    {
        public List<EMantenimineto> selectRow()
        {
            DMantenimineto listar = new DMantenimineto();
            return listar.SelectRow();
        }
        public void InsertRow(EMantenimineto newMan)
        {
            if (newMan.total == 0)
                throw new ArgumentException("Ingresa el total");
            if (newMan.fecha == null)
                throw new ArgumentException("Ingresa la fecha");
            if (newMan.placa.Length == 0)
                throw new ArgumentException("Ingresa la placa");
            if (newMan.idservicioVehiculo.idServicioVehiculo == 0)
                throw new ArgumentException("Ingresa el vehiculo");
            if (newMan.idgrupo.idGrupo == 0)
                throw new ArgumentException("Ingresa el grupo");
            if (newMan.usuario.usuario == null)
                throw new ArgumentException("Ingresa el usuario");
            DMantenimineto man = new DMantenimineto();
            man.InsertRow(newMan);
        }
    }
}
