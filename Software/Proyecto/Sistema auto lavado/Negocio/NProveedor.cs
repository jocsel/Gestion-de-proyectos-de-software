using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;


namespace Negocio
{
    public class NProveedor
    {
        public List<EProveedor> ObtenerListaProveedor()
        {
            try
           {
                DProveedor datosProveedor = new DProveedor();
                return datosProveedor.obtenerlistaProveedor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(EProveedor ModificarProveedor)
        {
            try
            {
                if (ModificarProveedor.nombres.Length < 3)
                    throw new ArgumentException("Ingresa los nombres del Proveedor");
                if (ModificarProveedor.apellidos.Length < 3)
                    throw new ArgumentException("Ingresa los apellidos del Proveedor");
                if (ModificarProveedor.RUC.Length < 11 || ModificarProveedor.RUC.Length > 11)
                    throw new ArgumentException("Ingresa el Numero de RUC del Proveedor");
                //no estoy seguro de este codigo .value
                if (ModificarProveedor.telefono.Length < 8 || ModificarProveedor.telefono.Length > 8)
                    throw new ArgumentException("Ingresa un numero  telefonico del Proveedor valido");
                if (ModificarProveedor.correo.Length < 3)
                    throw new ArgumentException("Ingresa el correo del Proveedor");
                if (ModificarProveedor.direccion.Length < 10)
                    throw new ArgumentException("Ingresa una direccion del Proveedor valido");              
                if (ModificarProveedor.nombreempresa.Length < 3)
                    throw new ArgumentException("Ingrese el nombre de la empresa");

                DProveedor gestionaProveedor = new DProveedor();
                gestionaProveedor.Modificar(ModificarProveedor);


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Agregar(EProveedor AgregarProveedor)
        {
            try
            {
                if (AgregarProveedor.nombres.Length < 3)
                    throw new ArgumentException("Ingresa los nombres del Proveedor");
                if (AgregarProveedor.apellidos.Length < 3)
                    throw new ArgumentException("Ingresa los apellidos del Proveedor");
                if (AgregarProveedor.RUC.Length < 11 || AgregarProveedor.RUC.Length > 11)
                    throw new ArgumentException("Ingresa el Numero de RUC del Proveedor");
                //no estoy seguro de este codigo .value
                if (AgregarProveedor.telefono.Length < 8 || AgregarProveedor.telefono.Length > 8)
                    throw new ArgumentException("Ingresa un numero  telefonico del Proveedor valido");
                if (AgregarProveedor.correo.Length < 3)
                    throw new ArgumentException("Ingresa el correo del Proveedor");
                if (AgregarProveedor.direccion.Length < 10)
                    throw new ArgumentException("Ingresa una direccion del Proveedor valido");
                if (AgregarProveedor.nombreempresa.Length < 3)
                    throw new ArgumentException("Ingrese el nombre de la empresa");

                DProveedor gestionaProveedor = new DProveedor();
                gestionaProveedor.Agregar(AgregarProveedor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

