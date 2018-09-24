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
    public class DVehiculoLavado
    {

        public List<EVehiculoLavado> SelectRow() {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_vehiculoLavado";
                cmd.Parameters.Add("@i_operacion",SqlDbType.Char,1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EVehiculoLavado> listarVehiculos = new List<EVehiculoLavado>();
                while (leer.Read()) {
                    EVehiculoLavado lista = new EVehiculoLavado();
                    lista.idVehiculoLavado = leer.GetInt32(0);
                    if (leer.IsDBNull(1))
                        lista.vehiculoLavado = null;
                    else
                        lista.vehiculoLavado = leer.GetString(1);
                    if (leer.IsDBNull(2))
                        lista.estado = false;
                    else
                        lista.estado = leer.GetBoolean(2);
                    listarVehiculos.Add(lista);
                }
                return listarVehiculos;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InsertRow(EVehiculoLavado IVL) {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_vehiculoLavado";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "I";
                cmd.Parameters.AddWithValue("@i_vehiculoLavado",IVL.vehiculoLavado);
                cmd.Parameters.AddWithValue("@i_estado", IVL.estado);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex) {
                throw ex;
            }

        }
        public void UpdateRow(EVehiculoLavado UVL)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_vehiculoLavado";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "U";
                cmd.Parameters.AddWithValue("@idVehiculoLavado",UVL.idVehiculoLavado);
                cmd.Parameters.AddWithValue("@i_vehiculoLavado", UVL.vehiculoLavado);
                cmd.Parameters.AddWithValue("@i_estado", UVL.estado);
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
