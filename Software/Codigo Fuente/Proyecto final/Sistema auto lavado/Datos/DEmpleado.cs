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
   public class DEmpleado
    {
        public List<EEmpleado> SelectRow() {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_empleado";
                cmd.Parameters.Add("@i_operacion",SqlDbType.Char,1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EEmpleado> listaEmpleado = new List<EEmpleado>();
                while (leer.Read()) {
                    EEmpleado lista = new EEmpleado();
                    lista.idEmpleado = leer.GetInt32(0);
                    lista.GrupoTrabajadores.idGrupo = leer.GetInt32(1);
                    lista.Area.idArea = leer.GetInt32(2);
                    if (leer.IsDBNull(3))
                        lista.nombres = null;
                    else
                        lista.nombres = leer.GetString(3);
                    if (leer.IsDBNull(4))
                        lista.apellidos = null;
                    else
                        lista.apellidos = leer.GetString(4);
                    if (leer.IsDBNull(5))
                        lista.fechaNacimiento = null;
                   
                    else
                        lista.fechaNacimiento = leer.GetDateTime(5);
                    if (leer.IsDBNull(6))
                        lista.cedula = null;
                    else
                        lista.cedula = leer.GetString(6);
                    if (leer.IsDBNull(7))
                        lista.direccion = null;
                    else
                        lista.direccion = leer.GetString(7);
                    if (leer.IsDBNull(8))
                        lista.celular = null;
                    else
                        lista.celular = leer.GetInt32(8);
                    if (leer.IsDBNull(9))
                        lista.salario = null;
                    else
                        lista.salario = leer.GetDecimal(9);
                    if (leer.IsDBNull(10))
                        lista.cargo = null;
                    else
                        lista.cargo = leer.GetString(10);
                    if (leer.IsDBNull(11))
                        lista.estado = null;
                    else
                        lista.estado = leer.GetString(11);
                    if (leer.IsDBNull(12))
                        lista.Area.area = null;
                    else
                        lista.Area.area = leer.GetString(12);
                    if (leer.IsDBNull(13))
                        lista.GrupoTrabajadores.grupoTrabajadores = null;
                    else
                        lista.GrupoTrabajadores.grupoTrabajadores = leer.GetString(13);
                    listaEmpleado.Add(lista);
                }
                conex.Close();
                leer.Close();
                return listaEmpleado;

            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void InsertRow(EEmpleado IEmpleado) {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_empleado";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "I";
                cmd.Parameters.AddWithValue("@i_celular",IEmpleado.celular);
                cmd.Parameters.AddWithValue("@i_direccion",IEmpleado.direccion);
                cmd.Parameters.AddWithValue("@i_cedula",IEmpleado.cedula);
                cmd.Parameters.AddWithValue("@i_apellidos",IEmpleado.apellidos);
                cmd.Parameters.AddWithValue("@i_nombres",IEmpleado.nombres);
                cmd.Parameters.AddWithValue("@i_fechaNac",IEmpleado.fechaNacimiento);
                cmd.Parameters.AddWithValue("@i_salario",IEmpleado.salario);
                cmd.Parameters.AddWithValue("@i_cargo",IEmpleado.cargo);
                cmd.Parameters.AddWithValue("@i_estado",IEmpleado.estado);
                cmd.Parameters.AddWithValue("@i_idArea",IEmpleado.Area.idArea);
                cmd.Parameters.AddWithValue("@i_idGrupo",IEmpleado.GrupoTrabajadores.idGrupo);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void UpdateRow(EEmpleado UEmpleado)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_empleado";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "U";
                cmd.Parameters.AddWithValue("@idEmpleado",UEmpleado.idEmpleado);
                cmd.Parameters.AddWithValue("@i_celular", UEmpleado.celular);
                cmd.Parameters.AddWithValue("@i_direccion", UEmpleado.direccion);
                cmd.Parameters.AddWithValue("@i_cedula", UEmpleado.cedula);
                cmd.Parameters.AddWithValue("@i_apellidos", UEmpleado.apellidos);
                cmd.Parameters.AddWithValue("@i_nombres", UEmpleado.nombres);
                cmd.Parameters.AddWithValue("@i_fechaNac", UEmpleado.fechaNacimiento);
                cmd.Parameters.AddWithValue("@i_salario", UEmpleado.salario);
                cmd.Parameters.AddWithValue("@i_cargo", UEmpleado.cargo);
                cmd.Parameters.AddWithValue("@i_estado", UEmpleado.estado);
                cmd.Parameters.AddWithValue("@i_idArea", UEmpleado.Area.idArea);
                cmd.Parameters.AddWithValue("@i_idGrupo", UEmpleado.GrupoTrabajadores.idGrupo);
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
