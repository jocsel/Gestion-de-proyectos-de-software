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
    public class DPago
    {
        public List<EPago> SelectRow()
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..[sp_SelecPago]";
                //cmd.Parameters.Add("@i_operacion", SqlDbType.Char,1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EPago> listaPago = new List<EPago>();
                while (leer.Read())
                {
                    EPago lista = new EPago();
                    if (leer.IsDBNull(0))
                        lista.numeroDocumento = null;
                    else
                        lista.numeroDocumento = leer.GetInt32(0);
                    if (leer.IsDBNull(1))
                        lista.cordobas = null;
                    else
                        lista.cordobas = leer.GetDecimal(1);
                    if (leer.IsDBNull(2))
                        lista.dolares = null;
                    else
                        lista.dolares = leer.GetDecimal(2);
                    if (leer.IsDBNull(3))
                        lista.vuelto = null;
                    else
                        lista.vuelto = leer.GetDecimal(3);
                    if (leer.IsDBNull(4))
                        lista.fecha = null;
                    else
                        lista.fecha = leer.GetDateTime(4);
                    if (leer.IsDBNull(5))
                        lista.montoFactura = null;
                    else
                        lista.montoFactura = leer.GetDecimal(5);
                    if (leer.IsDBNull(6))
                        lista.EUsuario.idUsuario = null;
                    else
                        lista.EUsuario.idUsuario = leer.GetInt32(6);
                    if (leer.IsDBNull(7))
                        lista.EUsuario.usuario = null;
                    else
                        lista.EUsuario.usuario = leer.GetString(7);
                    if (leer.IsDBNull(8))
                        lista.EEmpleado.nombres = null;
                    else
                        lista.EEmpleado.nombres = leer.GetString(8);
                    listaPago.Add(lista);

                }
                conex.Close();
                leer.Close();
                return listaPago;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertRow(EPago IPago)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..[sp_Pago]";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "I";
                cmd.Parameters.AddWithValue("@i_numeroDocumento", IPago.numeroDocumento);
                cmd.Parameters.AddWithValue("@i_cordobas", IPago.cordobas);
                cmd.Parameters.AddWithValue("@i_dolares", IPago.dolares);
                cmd.Parameters.AddWithValue("@i_vuelto", IPago.vuelto);
                cmd.Parameters.AddWithValue("@fecha", IPago.fecha);
                cmd.Parameters.AddWithValue("@i_idUsuario", IPago.EUsuario.idUsuario);
                cmd.Parameters.AddWithValue("@i_montoFactura", IPago.montoFactura);
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
        public void UpdareRow(EPago UPago)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..[sp_Pago]";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "U";
                cmd.Parameters.AddWithValue("@i_numeroDocumento", UPago.numeroDocumento);
                cmd.Parameters.AddWithValue("@i_cordobas", UPago.cordobas);
                cmd.Parameters.AddWithValue("@i_dolares", UPago.dolares);
                cmd.Parameters.AddWithValue("@i_vuelto", UPago.vuelto);
                cmd.Parameters.AddWithValue("@fecha", UPago.fecha);
                cmd.Parameters.AddWithValue("@i_idUsuario", UPago.EUsuario.idUsuario);
                cmd.Parameters.AddWithValue("@i_montoFactura", UPago.montoFactura);
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
