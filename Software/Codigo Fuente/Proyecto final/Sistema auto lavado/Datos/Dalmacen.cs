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
    public class Dalmacen
    {


        public List<Ealmacen> obtenerlistaalmacen()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getalmacen";
                cmd.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<Ealmacen> listaalmacen = new List<Ealmacen>();
                while (leer.Read())
                {
                    Ealmacen nuevafila = new Ealmacen();

                    nuevafila.IdAlmcen = leer.GetInt32(0);

                    nuevafila.Categoria.CodCategoria = leer.GetInt32(1);

                    if (leer.IsDBNull(2))

                        nuevafila.Nombre = null;

                    else
                        nuevafila.Nombre = leer.GetString(2);

                    if (leer.IsDBNull(3))

                        nuevafila.Ubicacion = null;

                    else
                        nuevafila.Ubicacion = leer.GetString(3);

                    if (leer.IsDBNull(4))

                        nuevafila.Descripcion = null;

                    else
                        nuevafila.Descripcion = leer.GetString(4);


                    if (leer.IsDBNull(5))

                        nuevafila.NombreCategoria = null;

                    else
                        nuevafila.NombreCategoria = leer.GetString(5);

                    listaalmacen.Add(nuevafila);
                }

                return listaalmacen;



            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public void agregaralmacen(Ealmacen Nueva)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertaralmacen";
                cmd.Parameters.AddWithValue("@CodCategoria", Nueva.Categoria.CodCategoria);
                cmd.Parameters.AddWithValue("@nombre", Nueva.Nombre);
                cmd.Parameters.AddWithValue("@ubicacion", Nueva.Ubicacion);
                cmd.Parameters.AddWithValue("@descripcion", Nueva.Descripcion);
                cmd.Parameters.AddWithValue("@NombreCategoria", Nueva.NombreCategoria);
                cmd.Connection = conexion;
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificaralmacen(Ealmacen  modificar)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "actualizaralmacen";
                cmd.Parameters.AddWithValue("@idalmacen", modificar.IdAlmcen);
                cmd.Parameters.AddWithValue("@CodCategoria", modificar.Categoria.CodCategoria);
                cmd.Parameters.AddWithValue("@nombre", modificar.Nombre);
                cmd.Parameters.AddWithValue("@ubicacion", modificar.Ubicacion);
                cmd.Parameters.AddWithValue("@descripcion", modificar.Descripcion);
                cmd.Parameters.AddWithValue("@NombreCategoria", modificar.NombreCategoria);
                cmd.Connection = conexion;
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();



            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

    }
}
