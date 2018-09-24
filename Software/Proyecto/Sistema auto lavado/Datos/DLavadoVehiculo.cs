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
    public class DLavadoVehiculo
    {
        public List<ELavadoVehiculo> SelectRow() {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_lavadoVehiculo";
                cmd.Parameters.Add("@i_operacion",SqlDbType.Char,1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<ELavadoVehiculo> listaLV = new List<ELavadoVehiculo>();
                while (leer.Read()) {
                    ELavadoVehiculo lista = new ELavadoVehiculo();
                    lista.idLavadoVehiculo = leer.GetInt32(0);
                    lista.servicioLavado.idServicioLavado = leer.GetInt32(1);
                    lista.vehiculoLavado.idVehiculoLavado = leer.GetInt32(2);
                    if (leer.IsDBNull(3))
                        lista.vehiculoLavado.vehiculoLavado = null;
                    else

                        lista.vehiculoLavado.vehiculoLavado = leer.GetString(3);
                    if (leer.IsDBNull(4))
                        lista.servicioLavado.servicioLavado = null;
                    else
                        lista.servicioLavado.servicioLavado = leer.GetString(4);
                    if (leer.IsDBNull(5))
                        lista.precio = null;
                    else
                        lista.precio = leer.GetDecimal(5);
                    listaLV.Add(lista);
                }
                conex.Close();
                leer.Close();
                return listaLV;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void InsertRow(ELavadoVehiculo ILavadoVehiculo) {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_lavadoVehiculo";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "I";
                cmd.Parameters.AddWithValue("@i_idServicioLavado",ILavadoVehiculo.servicioLavado.idServicioLavado);
                cmd.Parameters.AddWithValue("@i_idVehiculoLavado",ILavadoVehiculo.vehiculoLavado.idVehiculoLavado);
                cmd.Parameters.AddWithValue("@i_precio",ILavadoVehiculo.precio);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void UpdateRow(ELavadoVehiculo ULavadoVehiculo)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_lavadoVehiculo";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "U";
                cmd.Parameters.AddWithValue("@idLavadoVehiculo",ULavadoVehiculo.idLavadoVehiculo);
                cmd.Parameters.AddWithValue("@i_idServicioLavado", ULavadoVehiculo.servicioLavado.idServicioLavado);
                cmd.Parameters.AddWithValue("@i_idVehiculoLavado", ULavadoVehiculo.vehiculoLavado.idVehiculoLavado);
                cmd.Parameters.AddWithValue("@i_precio", ULavadoVehiculo.precio);
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
