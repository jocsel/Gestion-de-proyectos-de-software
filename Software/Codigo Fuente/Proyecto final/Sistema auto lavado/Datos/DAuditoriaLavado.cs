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
    public class DAuditoriaLavado
    {
        public List<EAuditoriaLavado> 
            SelectRow()
        {
            try {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_auditoriaLavado";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EAuditoriaLavado> listarAuditoriaLavado = new List<EAuditoriaLavado>();
                while (leer.Read()) {
                    EAuditoriaLavado AL = new EAuditoriaLavado();
                    if (leer.IsDBNull(0))
                        AL.fecha = null;
                    else
                        AL.fecha = leer.GetDateTime(0);
                    if (leer.IsDBNull(1))
                        AL.accion = null;
                    else
                        AL.accion = leer.GetString(1);
                    if (leer.IsDBNull(2))
                        AL.empleado.nombres = null;
                    else
                        AL.empleado.nombres = leer.GetString(2);
                    if (leer.IsDBNull(3))
                        AL.VehiculoLavado.vehiculoLavado = null;
                    else
                        AL.VehiculoLavado.vehiculoLavado = leer.GetString(3);
                    if (leer.IsDBNull(4))
                        AL.placa = null;
                    else
                        AL.placa = leer.GetString(4);
                    if (leer.IsDBNull(5))
                        AL.GrupoTrabajadores.grupoTrabajadores = null;
                    else
                        AL.GrupoTrabajadores.grupoTrabajadores = leer.GetString(5);
                    if (leer.IsDBNull(6))
                        AL.ServicioLavado.servicioLavado = null;
                    else
                        AL.ServicioLavado.servicioLavado = leer.GetString(6);
                    if (leer.IsDBNull(7))
                        AL.total = null;
                    else
                        AL.total = leer.GetDecimal(7);
                    if (leer.IsDBNull(8))
                        AL.fechaCreada = null;
                    else
                        AL.fechaCreada = leer.GetDateTime(8);
                    if (leer.IsDBNull(9))
                        AL.fechaModificado = null;
                    else
                        AL.fechaModificado = leer.GetDateTime(9);

                    AL.idLavadoAL = leer.GetInt32(10);
                    AL.Lavado.idLavado = leer.GetInt32(11);
                    AL.usuario.idUsuario = leer.GetInt32(12);
                    AL.GrupoTrabajadores.idGrupo = leer.GetInt32(13);
                    AL.ServicioLavado.idServicioLavado = leer.GetInt32(14);
                    AL.VehiculoLavado.idVehiculoLavado = leer.GetInt32(15);
                    AL.empleado.idEmpleado = leer.GetInt32(16);
                    AL.LavadoVehiculo.idLavadoVehiculo = leer.GetInt32(17);
                    listarAuditoriaLavado.Add(AL);
                }
                return listarAuditoriaLavado;
             }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
