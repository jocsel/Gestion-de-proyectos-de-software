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
    public class Dmarca
    {
        public List<EMarcas> obtenerlistamarca()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getmarca";
                cmd.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EMarcas> listamarca = new List<EMarcas>();
                while (leer.Read())
                {
                    EMarcas nuevafila = new EMarcas();

                    nuevafila.Codmarca = leer.GetInt32(0);

                    if (leer.IsDBNull(1))
                        nuevafila.Marca = null;
                    else
                        nuevafila.Marca = leer.GetString(1);

                    listamarca.Add(nuevafila);
                }
                return listamarca;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


              public void agregarMarca(EMarcas nuevo)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "insertarmarca";
                comando.Parameters.AddWithValue("@marca", nuevo.Marca);
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
        public void modificarmarca(EMarcas modificar)
        {
            try
            {

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "actualizarmarca";
                comando.Parameters.AddWithValue("@Codmarca",modificar.Codmarca);
                comando.Parameters.AddWithValue("@marca",modificar.Marca);
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

