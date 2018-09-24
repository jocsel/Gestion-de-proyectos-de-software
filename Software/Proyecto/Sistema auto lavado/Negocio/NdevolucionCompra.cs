using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
      public class NdevolucionCompra
    {
        public List<EdevolucionCompra> obtenerlistdevolucion()
        {

            try
            {
                DdevolucionCompra datos = new DdevolucionCompra();
                return datos.obtenerlistadevolucion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregardevolucioncompra(EdevolucionCompra nuevadevolucion)
        {
            try
            {
                //if
                //    (nuevaventa.cliente.id_cliente == 0)
                //    throw new ArgumentException("Ingrese datos de cliente");
                //if (nuevaventa.cliente.nombre.Length == 0)
                //    throw new ArgumentException("Ingrese datos del cliente");
                //if (nuevaventa.usuario.idusuario ==0)
                //    throw new ArgumentException("Ingrese datos del usuario");
                //if (nuevaventa.usuario.nombre.Length == 0)
                //    throw new ArgumentException("Ingrese el nombre");
                ////if (nuevaventa.cantidad.Length == 0)
                ////    throw new ArgumentException("Ingrese la cantidad");
                ////if (nuevaventa.descripcion.Length == 0)
                ////    throw new ArgumentException("Ingrese la descripcion");

                DdevolucionCompra gestion = new DdevolucionCompra();
                gestion.agregardevoluconcompra(nuevadevolucion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
