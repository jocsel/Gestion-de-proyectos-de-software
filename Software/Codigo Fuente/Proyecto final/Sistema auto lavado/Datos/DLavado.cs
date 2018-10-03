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
    public class DLavado
    {
        public List<ELavado> SelectRow() {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..[sp_lavado]";
                cmd.Parameters.Add("@i_operacion",SqlDbType.Char,1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<ELavado> listaLavado = new List<ELavado>();
                while (leer.Read()) {
                    ELavado lista = new ELavado();
                    lista.idLavado = leer.GetInt32(0);
                    if (leer.IsDBNull(1))
                        lista.fecha = null;
                    else
                        lista.fecha = leer.GetDateTime(1);
                    if (leer.IsDBNull(2))
                        lista.usuario.usuario = null;
                    else
                        lista.usuario.usuario = leer.GetString(2);
                    if (leer.IsDBNull(3))
                        lista.empleado.nombres = null;
                    else
                        lista.empleado.nombres = leer.GetString(3);
                    if (leer.IsDBNull(4))
                        lista.grupoTrabajadores.idGrupo = null;
                    else
                        lista.grupoTrabajadores.idGrupo = leer.GetInt32(4);
                    if (leer.IsDBNull(5))
                        lista.grupoTrabajadores.grupoTrabajadores = null;
                    else
                        lista.grupoTrabajadores.grupoTrabajadores = leer.GetString(5);
                    if (leer.IsDBNull(6))
                        lista.vehiculoLavado.idVehiculoLavado = null;
                    else
                        lista.vehiculoLavado.idVehiculoLavado = leer.GetInt32(6);
                    if (leer.IsDBNull(7))
                        lista.vehiculoLavado.vehiculoLavado = null;
                    else
                        lista.vehiculoLavado.vehiculoLavado = leer.GetString(7);
                    if (leer.IsDBNull(8))
                        lista.servicioLavado.idServicioLavado = null;
                    else
                        lista.servicioLavado.idServicioLavado = leer.GetInt32(8);
                    if (leer.IsDBNull(9))
                        lista.servicioLavado.servicioLavado = null;
                    else
                        lista.servicioLavado.servicioLavado = leer.GetString(9);
                    if (leer.IsDBNull(10))
                        lista.grupoTrabajadores.idGrupo = null;
                    else
                        lista.grupoTrabajadores.idGrupo = leer.GetInt32(10);
                    if (leer.IsDBNull(11))
                        lista.LavadoVehiculo.idLavadoVehiculo = null;
                    else
                        lista.LavadoVehiculo.idLavadoVehiculo = leer.GetInt32(11);
                    if (leer.IsDBNull(12))
                        lista.LavadoVehiculo.precio = null;
                    else
                        lista.LavadoVehiculo.precio = leer.GetDecimal(12);
                    if (leer.IsDBNull(13))
                        lista.placa = null;
                    else
                        lista.placa = leer.GetString(13);
                    if (leer.IsDBNull(14))
                        lista.total = null;
                    else
                        lista.total = leer.GetDecimal(14);
                    listaLavado.Add(lista);
                }
                conex.Close();
                leer.Close();
                return listaLavado;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void InsertRow(ELavado ILavado) {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..[sp_lavado]";
                cmd.Parameters.Add("@i_operacion",SqlDbType.Char,1).Value = "I";
                cmd.Parameters.AddWithValue("@idLavado",ILavado.idLavado);
                cmd.Parameters.AddWithValue("@i_total",ILavado.total);
                cmd.Parameters.AddWithValue("@i_fecha",ILavado.fecha);
                cmd.Parameters.AddWithValue("@i_placa",ILavado.placa);
                cmd.Parameters.AddWithValue("@i_idlavadoVehiculo",ILavado.LavadoVehiculo.idLavadoVehiculo);
                cmd.Parameters.AddWithValue("@i_idGrupo",ILavado.grupoTrabajadores.idGrupo);
                cmd.Parameters.AddWithValue("@i_usuario",ILavado.usuario.usuario);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void UpdatetRow(ELavado ULavado)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..[sp_lavado]";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "U";
                cmd.Parameters.AddWithValue("@idLavado", ULavado.idLavado);
                cmd.Parameters.AddWithValue("@i_total", ULavado.total);
                cmd.Parameters.AddWithValue("@i_fecha", ULavado.fecha);
                cmd.Parameters.AddWithValue("@i_placa", ULavado.placa);
                cmd.Parameters.AddWithValue("@i_idlavadoVehiculo", ULavado.LavadoVehiculo.idLavadoVehiculo);
                cmd.Parameters.AddWithValue("@i_idGrupo", ULavado.grupoTrabajadores.idGrupo);
                cmd.Parameters.AddWithValue("@i_usuario", ULavado.usuario.usuario);
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
