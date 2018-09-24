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
    public class Ddevolucion
    {
        public List<Edevolucion> obtenerlistadevolucion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "getdevolucionventa";
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                List<Edevolucion> listaventa = new List<Edevolucion>();
                while (leer.Read())
                {
                    Edevolucion nuevaFila = new Edevolucion();

                    nuevaFila.idDevolucion = leer.GetInt32(0);

                    nuevaFila.Usuario.idUsuario = leer.GetInt32(1);

                    nuevaFila.Venta.Num_venta = leer.GetInt32(2);

                    if (leer.IsDBNull(3))
                        nuevaFila.Fecha = null;
                    else
                        nuevaFila.Fecha = leer.GetDateTime(3);

                   
             
                    listaventa.Add(nuevaFila);
                }

                return listaventa;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public void agregardevolucon(Edevolucion nuevadevolucion)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "agregardevolucion";
                comando.Parameters.AddWithValue("@Idusuario", nuevadevolucion.Usuario.idUsuario);
                comando.Parameters.AddWithValue("@Numventa", nuevadevolucion.Venta.Num_venta);
                comando.Parameters.AddWithValue("@fechafactura", nuevadevolucion.Fecha);
                comando.Parameters.AddWithValue("@observacion", nuevadevolucion.Observacion);
                
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();

                while (leer.Read())
                {

                    nuevadevolucion.idDevolucion = Convert.ToInt32(leer["id"].ToString());

                }
                leer.Close();
                foreach (Edetalledevolucion item in nuevadevolucion.listadetalle)
                {
                    comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "insertar_detalledevolucion";
                    comando.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    comando.Parameters.AddWithValue("@iddevolucion", nuevadevolucion.idDevolucion);
                    comando.Parameters.AddWithValue("@idproducto", item.producto.Codproducto);
                    comando.Connection = conexion;
                    comando.ExecuteNonQuery();
                }
                conexion.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

  


    }
}
