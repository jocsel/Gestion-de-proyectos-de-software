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
    public class Dproductos
    {
        public List<Eproductos> obtenerlistaproducto()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getprodcuto";
                cmd.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<Eproductos> listap = new List<Eproductos>();
                while (leer.Read())
                {
                    Eproductos nuevafila = new Eproductos();

                    nuevafila.Codproducto = leer.GetInt32(0);

                    if (leer.IsDBNull(1))
                        nuevafila.Producto = null;
                    else
                        nuevafila.Producto = leer.GetString(1);                 

                    nuevafila.Marca.Codmarca = leer.GetInt32(2);

                    if (leer.IsDBNull(3))
                        nuevafila.CodSac = null;
                    else
                        nuevafila.CodSac = leer.GetString(3);

                    if (leer.IsDBNull(4))
                        nuevafila.Existencia = null;
                    else
                        nuevafila.Existencia = leer.GetInt32(4);

                    if (leer.IsDBNull(5))
                        nuevafila.Costo = null;
                    else
                        nuevafila.Costo = leer.GetDecimal(5);
                    if (leer.IsDBNull(6))
                        nuevafila.Precio = null;
                    else
                        nuevafila.Precio = leer.GetDecimal(6);

                    if (leer.IsDBNull(7))
                        nuevafila.Activo = null;
                    else
                        nuevafila.Activo = leer.GetBoolean(7);


                    listap.Add(nuevafila);
                }
                return listap;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void agregarProducto(Eproductos nuevo)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "insertarproducto";
                comando.Parameters.AddWithValue("@Producto", nuevo.Producto);
                comando.Parameters.AddWithValue("@Codmarca", nuevo.Marca.Codmarca);
                comando.Parameters.AddWithValue("@CodSAC", nuevo.CodSac);
                comando.Parameters.AddWithValue("@existencia", nuevo.Existencia);
                comando.Parameters.AddWithValue("@Costo", nuevo.Costo);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                comando.Parameters.AddWithValue("@Activo", nuevo.Activo);
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
        public void modificarproducto(Eproductos modificar)
        {
            try
            {

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "actualizarproducto";
                comando.Parameters.AddWithValue("@CodProducto", modificar.Codproducto);
                comando.Parameters.AddWithValue("@Producto", modificar.Producto);
                comando.Parameters.AddWithValue("@Codmarca", modificar.Marca.Codmarca);
                comando.Parameters.AddWithValue("@CodSAC",  modificar.CodSac);
                comando.Parameters.AddWithValue("@existencia", modificar.Existencia);
                comando.Parameters.AddWithValue("@Costo", modificar.Costo);
                comando.Parameters.AddWithValue("@Precio", modificar.Precio);
                comando.Parameters.AddWithValue("@Activo", modificar.Activo);
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

