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
    public class DCliente
    {
        public List<ECliente> obtenerlistacliente()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getcliente";
                cmd.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<ECliente> listacliente = new List<ECliente>();
                while (leer.Read())
                {
                    ECliente nuevafila = new ECliente();

                    nuevafila.idCliente = leer.GetInt32(0);


                    if (leer.IsDBNull(1))
                        nuevafila.nombres = null;
                    else
                        nuevafila.nombres = leer.GetString(1);

                    if (leer.IsDBNull(2))
                        nuevafila.apellido = null;
                    else
                        nuevafila.apellido = leer.GetString(2);

                    if (leer.IsDBNull(3))
                        nuevafila.correo = null;
                    else
                        nuevafila.correo = leer.GetString(3);

                    if (leer.IsDBNull(4))
                        nuevafila.celular = null;
                    else
                        nuevafila.celular = leer.GetInt32(4);

                    if (leer.IsDBNull(5))
                        nuevafila.estado = null;
                    else
                        nuevafila.estado = leer.GetString(5);

                    listacliente.Add(nuevafila);
                }
                return listacliente;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregarCliente(ECliente nuevocliente)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "insertar_cliente";
                comando.Parameters.AddWithValue("@nombres", nuevocliente.nombres);
                comando.Parameters.AddWithValue("@apellido", nuevocliente.apellido);         
                comando.Parameters.AddWithValue("@correo", nuevocliente.correo);
                comando.Parameters.AddWithValue("@celular", nuevocliente.celular);
                comando.Parameters.AddWithValue("@estado", nuevocliente.estado);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Modificarclientes(ECliente modificarclientes)
        {
            try
            {

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "actualizar_clientes";
                comando.Parameters.AddWithValue("@i_idcliente", modificarclientes.idCliente);
                comando.Parameters.AddWithValue("@i_nombres", modificarclientes.nombres);
                comando.Parameters.AddWithValue("@i_apellido", modificarclientes.apellido);               
                comando.Parameters.AddWithValue("@i_correo", modificarclientes.correo);
                comando.Parameters.AddWithValue("@i_celular", modificarclientes.celular);
                comando.Parameters.AddWithValue("@i_estado", modificarclientes.estado);

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
