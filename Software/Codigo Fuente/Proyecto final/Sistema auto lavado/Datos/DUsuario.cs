using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
   public class DUsuario
    {
        public List<EUsuario> SelectRow() {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_Usuarios";
                cmd.Parameters.Add("@i_operacion",SqlDbType.Char,1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EUsuario> listaUsuario = new List<EUsuario>();
                while (leer.Read()) {
                    EUsuario entidadesUsuario = new EUsuario();
                    if (leer.IsDBNull(0))
                        entidadesUsuario.Empleado.nombres = null;
                    else
                        entidadesUsuario.Empleado.nombres = leer.GetString(0);
                    if (leer.IsDBNull(1))
                        entidadesUsuario.Empleado.cargo = null;
                    else
                        entidadesUsuario.Empleado.cargo = leer.GetString(1);
                    if (leer.IsDBNull(2))
                        entidadesUsuario.usuario = null;
                    else
                        entidadesUsuario.usuario = leer.GetString(2);
                    if (leer.IsDBNull(3))
                        entidadesUsuario.password = null;
                    else
                        entidadesUsuario.password = leer.GetString(3);
                    if (leer.IsDBNull(4))
                        entidadesUsuario.estado = null;
                    else
                        entidadesUsuario.estado = leer.GetString(4);
                    if (leer.IsDBNull(5))
                        entidadesUsuario.Permiso.facturar = false;
                    else
                        entidadesUsuario.Permiso.facturar = leer.GetBoolean(5);
                    if (leer.IsDBNull(6))
                        entidadesUsuario.Permiso.personas = false;
                    else
                        entidadesUsuario.Permiso.personas = leer.GetBoolean(6);
                    if (leer.IsDBNull(7))
                        entidadesUsuario.Permiso.producto = false;
                    else
                        entidadesUsuario.Permiso.producto = leer.GetBoolean(7);
                    if (leer.IsDBNull(8))
                        entidadesUsuario.Permiso.reporte = false;
                    else
                        entidadesUsuario.Permiso.reporte = leer.GetBoolean(8);
                    if (leer.IsDBNull(9))
                        entidadesUsuario.Permiso.mantenimiento = false;
                    else
                        entidadesUsuario.Permiso.mantenimiento = leer.GetBoolean(9);
                    if (leer.IsDBNull(10))
                        entidadesUsuario.Permiso.lavado = false;
                    else
                        entidadesUsuario.Permiso.lavado = leer.GetBoolean(10);
                    if (leer.IsDBNull(11))
                        entidadesUsuario.Permiso.btnFacturar = false;
                    else
                        entidadesUsuario.Permiso.btnFacturar = leer.GetBoolean(11);
                    if (leer.IsDBNull(12))
                        entidadesUsuario.Permiso.btnUsuarios = false;
                    else
                        entidadesUsuario.Permiso.btnUsuarios = leer.GetBoolean(12);
                    if (leer.IsDBNull(13))
                        entidadesUsuario.Permiso.btnProducto = false;
                    else
                        entidadesUsuario.Permiso.btnProducto = leer.GetBoolean(13);
                    if (leer.IsDBNull(14))
                        entidadesUsuario.Permiso.btnMantenimiento = false;
                    else
                        entidadesUsuario.Permiso.btnMantenimiento = leer.GetBoolean(14);
                    if (leer.IsDBNull(15))
                        entidadesUsuario.Permiso.btnLavado = false;
                    else
                        entidadesUsuario.Permiso.btnLavado = leer.GetBoolean(15);
                    if (leer.IsDBNull(16))
                        entidadesUsuario.Permiso.btnPersonas = false;
                    else
                        entidadesUsuario.Permiso.btnPersonas = leer.GetBoolean(16);
                    if (leer.IsDBNull(17))
                        entidadesUsuario.Permiso.btnFacturarCompra = false;
                    else
                        entidadesUsuario.Permiso.btnFacturarCompra = leer.GetBoolean(17);
                    if (leer.IsDBNull(18))
                        entidadesUsuario.Permiso.logs = false;
                    else
                        entidadesUsuario.Permiso.logs = leer.GetBoolean(18);
                    entidadesUsuario.idUsuario = leer.GetInt32(19);
                    entidadesUsuario.Permiso.PidUsuario = leer.GetInt32(20);
                    entidadesUsuario.Empleado.idEmpleado = leer.GetInt32(21);
                    listaUsuario.Add(entidadesUsuario);


                }
                conex.Close();
                leer.Close();
                return listaUsuario;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InsertRow(EUsuario Iusuario) {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_Usuarios";
                cmd.Parameters.Add("@i_operacion",SqlDbType.Char,1).Value = "I";
                cmd.Parameters.AddWithValue("@idUsuario",Iusuario.idUsuario);
                cmd.Parameters.AddWithValue("@i_usuario",Iusuario.usuario);
                cmd.Parameters.AddWithValue("@i_password",Iusuario.password);
                cmd.Parameters.AddWithValue("@i_idEmpleado",Iusuario.Empleado.idEmpleado);
                cmd.Parameters.AddWithValue("@i_estado",Iusuario.estado);
                cmd.Parameters.AddWithValue("@i_facturar",Iusuario.Permiso.facturar);
                cmd.Parameters.AddWithValue("@i_personas",Iusuario.Permiso.personas);
                cmd.Parameters.AddWithValue("@i_producto",Iusuario.Permiso.producto);
                cmd.Parameters.AddWithValue("@i_reporte",Iusuario.Permiso.reporte);
                cmd.Parameters.AddWithValue("@i_mantenimiento",Iusuario.Permiso.mantenimiento);
                cmd.Parameters.AddWithValue("@i_lavado",Iusuario.Permiso.lavado);
                cmd.Parameters.AddWithValue("@i_btnFacturar",Iusuario.Permiso.btnFacturar);
                cmd.Parameters.AddWithValue("@i_btnUsuario",Iusuario.Permiso.btnUsuarios);
                cmd.Parameters.AddWithValue("@i_btnProducto",Iusuario.Permiso.btnProducto);
                cmd.Parameters.AddWithValue("@i_btnMantenimiento",Iusuario.Permiso.btnMantenimiento);
                cmd.Parameters.AddWithValue("@i_btnLavado",Iusuario.Permiso.btnLavado);
                cmd.Parameters.AddWithValue("@i_btnPersonas",Iusuario.Permiso.btnPersonas);
                cmd.Parameters.AddWithValue("@i_Pusuario",Iusuario.usuario);
                cmd.Parameters.AddWithValue("@i_btnFacturarCompra",Iusuario.Permiso.btnFacturarCompra);
                cmd.Parameters.AddWithValue("@i_logs",Iusuario.Permiso.logs);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public void UpdateRow(EUsuario Uusuario)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_Usuarios";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "U";
                 cmd.Parameters.AddWithValue("@idUsuario", Uusuario.idUsuario);
                cmd.Parameters.AddWithValue("@i_PidUsuario",Uusuario.Permiso.PidUsuario);
                cmd.Parameters.AddWithValue("@i_usuario", Uusuario.usuario);
                cmd.Parameters.AddWithValue("@i_password", Uusuario.password);
                cmd.Parameters.AddWithValue("@i_idEmpleado", Uusuario.Empleado.idEmpleado);
                cmd.Parameters.AddWithValue("@i_estado", Uusuario.estado);
                cmd.Parameters.AddWithValue("@i_facturar", Uusuario.Permiso.facturar);
                cmd.Parameters.AddWithValue("@i_personas", Uusuario.Permiso.personas);
                cmd.Parameters.AddWithValue("@i_producto", Uusuario.Permiso.producto);
                cmd.Parameters.AddWithValue("@i_reporte", Uusuario.Permiso.reporte);
                cmd.Parameters.AddWithValue("@i_mantenimiento", Uusuario.Permiso.mantenimiento);
                cmd.Parameters.AddWithValue("@i_lavado", Uusuario.Permiso.lavado);
                cmd.Parameters.AddWithValue("@i_btnFacturar", Uusuario.Permiso.btnFacturar);
                cmd.Parameters.AddWithValue("@i_btnUsuario", Uusuario.Permiso.btnUsuarios);
                cmd.Parameters.AddWithValue("@i_btnProducto", Uusuario.Permiso.btnProducto);
                cmd.Parameters.AddWithValue("@i_btnMantenimiento", Uusuario.Permiso.btnMantenimiento);
                cmd.Parameters.AddWithValue("@i_btnLavado", Uusuario.Permiso.btnLavado);
                cmd.Parameters.AddWithValue("@i_btnPersonas", Uusuario.Permiso.btnPersonas);
                cmd.Parameters.AddWithValue("@i_Pusuario", Uusuario.usuario);
                cmd.Parameters.AddWithValue("@i_btnFacturarCompra", Uusuario.Permiso.btnFacturarCompra);
                cmd.Parameters.AddWithValue("@i_logs", Uusuario.Permiso.logs);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
