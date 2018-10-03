using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NLavado
    {
        public List<ELavado> selectRow() {
            DLavado listar = new DLavado();
            return listar.SelectRow();
        }
        public void InsertRow(ELavado ILavado) {
            if (ILavado.total == 0)
                throw new ArgumentException("Ingresa el total");
            if (ILavado.fecha == null)
                throw new ArgumentException("Ingresa la fecha");
            if (ILavado.placa.Length == 0)
                throw new ArgumentException("Ingresa la placa");
            if (ILavado.LavadoVehiculo.idLavadoVehiculo == 0)
                throw new ArgumentException("Ingresa el vehiculo");
            if (ILavado.grupoTrabajadores.idGrupo == 0)
                throw new ArgumentException("Ingresa el grupo");
            if (ILavado.usuario.usuario == null)
                throw new ArgumentException("Ingresa el usuario");
            DLavado lavado = new DLavado();
            lavado.InsertRow(ILavado);
        }
        public void UpdateRow(ELavado ULavado)
        {
            if (ULavado.total == 0)
                throw new ArgumentException("Ingresa el total");
            if (ULavado.fecha == null)
                throw new ArgumentException("Ingresa la fecha");
            if (ULavado.placa == null)
                throw new ArgumentException("Ingresa la placa");
            if (ULavado.LavadoVehiculo.idLavadoVehiculo == 0)
                throw new ArgumentException("Ingresa el vehiculo");
            if (ULavado.grupoTrabajadores.idGrupo == 0)
                throw new ArgumentException("Ingresa el grupo");
            if (ULavado.usuario.usuario == null)
                throw new ArgumentException("Ingresa el usuario");
            DLavado lavado = new DLavado();
            lavado.UpdatetRow(ULavado);
        }
    }
}
