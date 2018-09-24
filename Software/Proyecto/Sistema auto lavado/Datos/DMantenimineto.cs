using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Datos
{
   public  class DMantenimineto
    {
        public List<EMantenimineto> SelectRow()
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..[sp_mantenimiento]";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "S";
                cmd.Connection = conex;
                conex.Open();

                SqlDataReader leer = cmd.ExecuteReader();
                List<EMantenimineto> listaManteniemiento = new List<EMantenimineto>();
                while (leer.Read())
                {
                    EMantenimineto lista = new EMantenimineto();
                    lista.idMantenimiento = leer.GetInt32(0);

                    if (leer.IsDBNull(1))
                        lista.total = null;
                    else
                        lista.total = leer.GetDecimal(1);

                    if (leer.IsDBNull(2))
                        lista.fecha = null;
                    else
                        lista.fecha = leer.GetDateTime(2);

                    if (leer.IsDBNull(3))
                        lista.placa = null;
                    else
                        lista.placa = leer.GetString(3);


                    if (leer.IsDBNull(4))
                        lista.idgrupo.grupoTrabajadores = null;
                    else
                        lista.idgrupo.grupoTrabajadores = leer.GetString(4);

                    if (leer.IsDBNull(5))
                        lista.idservicioVehiculo.idServicioMantenimiento.servicioMantenimiento = null;
                    else
                        lista.idservicioVehiculo.idServicioMantenimiento.servicioMantenimiento = leer.GetString(5);

                    if (leer.IsDBNull(6))
                        lista.idservicioVehiculo.idVehiculoMantenimiento.vehiculoMantenimiento = null;
                    else
                        lista.idservicioVehiculo.idVehiculoMantenimiento.vehiculoMantenimiento = leer.GetString(6);

                    if (leer.IsDBNull(7))
                        lista.usuario.usuario= null;
                    else
                        lista.usuario.usuario = leer.GetString(7);

                    if (leer.IsDBNull(8))
                        lista.usuario.Empleado.apellidos= null;
                    else
                        lista.usuario.Empleado.apellidos = leer.GetString(8);
                    //no se si funcionara 
                    if (leer.IsDBNull(9))
                        lista.usuario.Empleado.nombres = null;
                    else
                        lista.usuario.Empleado.nombres = leer.GetString(9);


                    if (leer.IsDBNull(10))
                        lista.idgrupo.idGrupo = null;
                    else
                        lista.idgrupo.idGrupo = leer.GetInt32(10);

                    if (leer.IsDBNull(11))
                        lista.idservicioVehiculo.idServicioMantenimiento = null;
                    else
                        lista.idservicioVehiculo.idServicioVehiculo = leer.GetInt32(11);

                    if (leer.IsDBNull(12))
                        lista.idservicioVehiculo.idServicioMantenimiento.idServicioMantenimiento = null;
                    else
                        lista.idservicioVehiculo.idServicioMantenimiento.idServicioMantenimiento = leer.GetInt32(12);
                    if (leer.IsDBNull(13))
                        lista.idservicioVehiculo.idServicioMantenimiento.idServicioMantenimiento = null;
                    else
                        lista.idservicioVehiculo.idVehiculoMantenimiento.idVehiculoMantenimiento = leer.GetInt32(13);


                    listaManteniemiento.Add(lista);
                }
                conex.Close();
                leer.Close();
                return listaManteniemiento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertRow(EMantenimineto newManv)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..[sp_mantenimiento]";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "I";
                cmd.Parameters.AddWithValue("@idMantenimiento", newManv.idMantenimiento);
                cmd.Parameters.AddWithValue("@total", newManv.total);
                cmd.Parameters.AddWithValue("@fecha", newManv.fecha);
                cmd.Parameters.AddWithValue("@placa", newManv.placa);
                cmd.Parameters.AddWithValue("@idgrupo", newManv.idgrupo.idGrupo);
                cmd.Parameters.AddWithValue("@idservicioVehiculo", newManv.idservicioVehiculo.idServicioVehiculo);
                cmd.Parameters.AddWithValue("@usuario", newManv.usuario.usuario);
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
