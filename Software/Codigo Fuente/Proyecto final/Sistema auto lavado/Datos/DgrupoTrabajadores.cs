using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DgrupoTrabajadores
    {
        public List<EGrupoTrabajadores> SelectRow() {

            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_grupoTrabajadores";
                cmd.Parameters.Add("@i_operacion",SqlDbType.Char,1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EGrupoTrabajadores> listaGrupoT = new List<EGrupoTrabajadores>();
                while (leer.Read()) {
                    EGrupoTrabajadores lista = new EGrupoTrabajadores();
                    lista.idGrupo = leer.GetInt32(0);
                    if (leer.IsDBNull(1))
                        lista.grupoTrabajadores = null;
                    else
                        lista.grupoTrabajadores = leer.GetString(1);

                    listaGrupoT.Add(lista);
                }
                return listaGrupoT;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InsertRow(EGrupoTrabajadores IGT) {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_grupoTrabajadores";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "I";
                cmd.Parameters.AddWithValue("@i_grupoTrabajadores",IGT.grupoTrabajadores);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close(); 
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void UpdateRow(EGrupoTrabajadores UGT)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_grupoTrabajadores";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "U";
                cmd.Parameters.AddWithValue("@i_grupoTrabajadores", UGT.grupoTrabajadores);
                cmd.Parameters.AddWithValue("@idgrupo", UGT.idGrupo);
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
