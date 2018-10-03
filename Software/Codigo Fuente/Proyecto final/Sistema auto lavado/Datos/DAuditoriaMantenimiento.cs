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
   public class DAuditoriaMantenimiento
    {
       public List<EAuditoriaMantenimiento> obtenermantenimiento()
       {
           try
           {
               SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
               SqlCommand cmd = new SqlCommand();
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.CommandText = "sp_auditoria_man";              
               cmd.Connection = conexion;
               conexion.Open();
               SqlDataReader leer = cmd.ExecuteReader();

               List<EAuditoriaMantenimiento> listaMan = new List<EAuditoriaMantenimiento>();
               while (leer.Read())
               {
                   EAuditoriaMantenimiento datosMantenimiento = new EAuditoriaMantenimiento();

                   datosMantenimiento.idmantenimiento = leer.GetInt32(0);

                   if (leer.IsDBNull(1))
                       datosMantenimiento.realizado = null;
                   else
                       datosMantenimiento.realizado = leer.GetString(1);

                   if (leer.IsDBNull(2))
                       datosMantenimiento.total = null;
                   else
                       datosMantenimiento.total = leer.GetDecimal(2);

                   if (leer.IsDBNull(3))
                       datosMantenimiento.fecha = null;
                   else
                       datosMantenimiento.fecha = leer.GetDateTime(3);

                   if (leer.IsDBNull(4))
                       datosMantenimiento.placa = null;
                   else
                       datosMantenimiento.placa = leer.GetString(4);

                   if (leer.IsDBNull(5))
                       datosMantenimiento.tecnicos = null;
                   else
                       datosMantenimiento.tecnicos = leer.GetString(5);

                   if (leer.IsDBNull(6))
                       datosMantenimiento.servicio = null;
                   else
                       datosMantenimiento.servicio = leer.GetString(6);

                   if (leer.IsDBNull(7))
                       datosMantenimiento.vehiculo = null;
                   else
                       datosMantenimiento.vehiculo = leer.GetString(7);

                   if (leer.IsDBNull(8))
                       datosMantenimiento.creado = null;
                   else
                       datosMantenimiento.creado = leer.GetDateTime(8);

                   if (leer.IsDBNull(9))
                       datosMantenimiento.Modificado = null;
                   else
                       datosMantenimiento.Modificado = leer.GetDateTime(9);

                   if (leer.IsDBNull(10))
                       datosMantenimiento.Accion = null;
                   else
                       datosMantenimiento.Accion = leer.GetString(10);


                   listaMan.Add(datosMantenimiento);

               }
               return listaMan;
           }
           catch (Exception ex)
           {
               throw ex;
           }


       }


    }
}
