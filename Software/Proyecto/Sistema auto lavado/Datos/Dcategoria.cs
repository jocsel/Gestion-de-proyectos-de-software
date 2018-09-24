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
    public class Dcategoria
    {

        public List<Ecategoria> obtenerlistacategoria()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getcategoria";
                cmd.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<Ecategoria> listacategoria = new List<Ecategoria>();
                while (leer.Read())
                {
                    Ecategoria nuevafila = new Ecategoria();

                    nuevafila.CodCategoria = leer.GetInt32(0);

                    if (leer.IsDBNull(1))

                        nuevafila.Tipo = null;

                    else
                        nuevafila.Tipo = leer.GetString(1);

                    nuevafila.Producto.Codproducto = leer.GetInt32(2);


                    if (leer.IsDBNull(3))

                        nuevafila.Nombredelproducto = null;

                    else
                        nuevafila.Nombredelproducto= leer.GetString(3);


                    listacategoria.Add(nuevafila);
                }

                return listacategoria;



            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public void agregarcategoria(Ecategoria Nueva)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertarcategoria";         
                cmd.Parameters.AddWithValue("@Tipo", Nueva.Tipo);
                cmd.Parameters.AddWithValue("@Codproducto", Nueva.Producto.Codproducto);
                cmd.Parameters.AddWithValue("@Nombredelproducto", Nueva.Nombredelproducto);
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

        public void modificarcategoria(Ecategoria modificar)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "actualizarcategoria";
                cmd.Parameters.AddWithValue("@CodCategoria", modificar.CodCategoria);
                cmd.Parameters.AddWithValue("@Tipo", modificar.Tipo);
                cmd.Parameters.AddWithValue("@Codproducto", modificar.Producto.Codproducto);
                cmd.Parameters.AddWithValue("@Nombredelproducto", modificar.Nombredelproducto);
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
