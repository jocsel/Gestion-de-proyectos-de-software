using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
     public class NAuditoriaMantenimiento
    {
         public List<EAuditoriaMantenimiento> ObtenerMantenimiento()
         {
             try
             {
                 DAuditoriaMantenimiento datosMan = new DAuditoriaMantenimiento();
                 return datosMan.obtenermantenimiento();
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
    }
}
