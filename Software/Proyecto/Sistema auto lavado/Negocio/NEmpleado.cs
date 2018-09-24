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
    public class NEmpleado
    {
        public List<EEmpleado> listaEmpleado() {

            try {
                DEmpleado datosEmpleado = new DEmpleado();
                return datosEmpleado.SelectRow();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InserRow(EEmpleado Iempleado) {
            try {
                if (Iempleado.apellidos.Length == 0)
                    throw new ArgumentException("Ingresa el apellido");
                if (Iempleado.fechaNacimiento == null)
                    throw new ArgumentException("Ingresa la fecha de nacimiento");
                if (Iempleado.celular == 0)
                    throw new ArgumentException("Ingresa celular");
                if (Iempleado.direccion.Length == 0)
                    throw new ArgumentException("Ingresa la direccion");
                if (Iempleado.cedula.Length < 16)
                    throw new ArgumentException("Ingresa la cedula");
                if (Iempleado.nombres.Length == 0)
                    throw new ArgumentException("Ingresa los nombres");
                if (Iempleado.salario == 0)
                    throw new ArgumentException("Ingresa el salario");
                if (Iempleado.estado.Length == 0)
                    throw new ArgumentException("Ingresa el estado");
                if (Iempleado.cargo.Length == 0)
                    throw new ArgumentException("Ingresa el cargo");
                if (Iempleado.Area.idArea == 0)
                    throw new ArgumentException("Ingresa el area");
                if (Iempleado.GrupoTrabajadores.idGrupo == 0)
                    throw new ArgumentException("Ingresa el grupo");
                DEmpleado gestionEmpleado = new DEmpleado();
                gestionEmpleado.InsertRow(Iempleado);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void UpdateRow(EEmpleado Uempleado)
        {
            try
            {
                if (Uempleado.apellidos.Length == 0)
                    throw new ArgumentException("Ingresa el apellido");
                if (Uempleado.fechaNacimiento == null)
                    throw new ArgumentException("Ingresa la fecha de nacimiento");
                if (Uempleado.celular == 0)
                    throw new ArgumentException("Ingresa celular");
                if (Uempleado.direccion.Length == 0)
                    throw new ArgumentException("Ingresa la direccion");
                if (Uempleado.cedula.Length < 16)
                    throw new ArgumentException("Ingresa la cedula");
                if (Uempleado.nombres.Length == 0)
                    throw new ArgumentException("Ingresa los nombres");
                if (Uempleado.salario == 0)
                    throw new ArgumentException("Ingresa el salario");
                if (Uempleado.estado.Length == 0)
                    throw new ArgumentException("Ingresa el estado");
                if (Uempleado.cargo.Length == 0)
                    throw new ArgumentException("Ingresa el cargo");
                if (Uempleado.Area.idArea == 0)
                    throw new ArgumentException("Ingresa el area");
                if (Uempleado.GrupoTrabajadores.idGrupo == 0)
                    throw new ArgumentException("Ingresa el grupo");
                DEmpleado gestionEmpleado = new DEmpleado();
                gestionEmpleado.UpdateRow(Uempleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
