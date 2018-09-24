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
    public class NUsuario
    {
        public Entidades.EUsuario login(string usuario, string password)
        {
            try {
                Datos.Dlogin logear = new Datos.Dlogin();
                return logear.login(usuario,password);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public List<EUsuario> SelectRow() {
            try {
                DUsuario listaUsuarios = new DUsuario();
                return listaUsuarios.SelectRow();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InsertRow(EUsuario Iusuario) {
            try {
                if (Iusuario.usuario == null)
                    throw new ArgumentException("Ingresa el nombre del usuario");
                if (Iusuario.password == null)
                    throw new ArgumentException("Ingresa la contraseña");
                if (Iusuario.Empleado.idEmpleado == 0)
                    throw new ArgumentException("Ingresa el empleado");
                if (Iusuario.estado == null)
                    throw new ArgumentException("Ingresa el estado del usuario");
                DUsuario gestioU = new DUsuario();
                gestioU.InsertRow(Iusuario);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void UpdateRow(EUsuario Uusuario)
        {
            try
            {
                if (Uusuario.usuario == null)
                    throw new ArgumentException("Ingresa el nombre del usuario");
                if (Uusuario.password == null)
                    throw new ArgumentException("Ingresa la contraseña");
                if (Uusuario.Empleado.idEmpleado == 0)
                    throw new ArgumentException("Ingresa el empleado");
                if (Uusuario.estado == null)
                    throw new ArgumentException("Ingresa el estado del usuario");
                DUsuario gestioU = new DUsuario();
                gestioU.UpdateRow(Uusuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
