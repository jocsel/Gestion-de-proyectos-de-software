using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
   public  class NControl_Entrada
    {
       public void Insertar(EControl_Entrada Econtrol)
       {
           try
           {
               if (Econtrol.usuario.usuario.Length == 0)
                   throw new ArgumentException("Error en el logout");

               DControl_Entrada gestionarcontrol = new DControl_Entrada();
               gestionarcontrol.insertar(Econtrol);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public List<EControl_Entrada> ObtenerControl()
       {
           try
           {
               DControl_Entrada datosControl = new DControl_Entrada();
               return datosControl.SelectRow();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

    }
}
