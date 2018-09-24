using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public  class DControl_Entrada
    {
        public void insertar(EControl_Entrada ModControl)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_log";
                cmd.Parameters.AddWithValue("@usuario", ModControl.usuario.usuario);
                cmd.Parameters.Add("@operacion", SqlDbType.VarChar, 1).Value = "I";
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

        public List<EControl_Entrada> SelectRow()
        {
            try
            {

                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..[sp_log]";
                cmd.Parameters.Add("@operacion", SqlDbType.Char, 1).Value = "S";
                cmd.Connection = conex;
                conex.Open();

                SqlDataReader leer = cmd.ExecuteReader();
                List<EControl_Entrada> listacontrol = new List<EControl_Entrada>();
                while (leer.Read())
                {
                    EControl_Entrada lista = new EControl_Entrada();
                    lista.Empleado = leer.GetString(0);
                    lista.usuario.usuario = leer.GetString(1);
                    lista.loginn = (leer.GetDateTime(2));
                    lista.logout = (leer.GetDateTime(3));
                    lista.maquina = (leer.GetString(4));

                    //lista.idMantenimiento = leer.GetInt32(0);
                    listacontrol.Add(lista);

                }
                return listacontrol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
