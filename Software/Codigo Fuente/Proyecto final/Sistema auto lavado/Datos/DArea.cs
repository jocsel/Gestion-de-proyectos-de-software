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
   public class DArea
    {
        public List<EArea> SelectRow() {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_Area";
                cmd.Parameters.Add("@i_operacion",SqlDbType.Char,1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EArea> listaArea = new List<EArea>();
                while (leer.Read()) {
                    EArea lista = new EArea();
                    lista.idArea = leer.GetInt32(0);
                    if (leer.IsDBNull(1))
                        lista.area = null;
                    else
                        lista.area = leer.GetString(1);
                    listaArea.Add(lista);
                }
                conex.Close();
                leer.Close();
                return listaArea;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InsertRow(EArea Iarea) {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText =  "Ingenieria..sp_Area";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "I";
                cmd.Parameters.AddWithValue("@i_area",Iarea.area);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void UpdateRow(EArea Uarea)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_Area";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "U";
                cmd.Parameters.AddWithValue("@i_area", Uarea.area);
                cmd.Parameters.AddWithValue("@idArea",Uarea.idArea);
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
