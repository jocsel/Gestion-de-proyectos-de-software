using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;


namespace Negocio
{
    public class NCliente
    {
        public List<ECliente> obtenerlistClientes()

        {
            try
            {
                DCliente datosclientes = new DCliente();
                return datosclientes.obtenerlistacliente();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregar(ECliente nuevoCliente)
        {
            try
            {

                if (nuevoCliente.nombres.Length == 0)
                    throw new ArgumentException("Ingrese el nombre");
                if (nuevoCliente.apellido.Length == 0)
                    throw new ArgumentException("Ingrese el apellido");
         
                if (nuevoCliente.correo.Length == 0)
                    throw new ArgumentException("Ingrese el correo");
                if (nuevoCliente.celular == 0)
                    throw new ArgumentException("Ingrese el celular");
                if (nuevoCliente.estado.Length == 0)
                    throw new ArgumentException("Ingrese el estado");



                DCliente gestioncliente = new DCliente();
                gestioncliente.agregarCliente(nuevoCliente);
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


                if (modificarclientes.nombres.Length == 0)
                    throw new ArgumentException("Ingrese el nombre");
                if (modificarclientes.apellido.Length == 0)
                    throw new ArgumentException("Ingrese el apellido");
          
                if (modificarclientes.correo.Length == 0)
                    throw new ArgumentException("Ingrese el correo");
                if (modificarclientes.celular == 0)
                    throw new ArgumentException("Ingrese el celular");
                if (modificarclientes.estado.Length == 0)
                    throw new ArgumentException("Ingrese el estado");

                DCliente gestionclientes = new DCliente();
                gestionclientes.Modificarclientes(modificarclientes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
