using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Nmarca
    {
        
            public List<EMarcas> obtenerlistmarca()

            {
                try
                {
                    Dmarca datosmarca = new Dmarca();
                    return datosmarca.obtenerlistamarca();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

            public void agregar(EMarcas nuevo)
            {
                try
                {

                    if (nuevo.Marca.Length == 0)
                        throw new ArgumentException("Ingrese la marca del producto");

                    Dmarca gestion = new Dmarca();
                    gestion.agregarMarca(nuevo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void modificar(EMarcas modificar)
            {
                try
                {


                    if (modificar.Marca.Length == 0)
                        throw new ArgumentException("Ingrese la marca del producto");

                    Dmarca gestion = new Dmarca();
                    gestion.modificarmarca(modificar);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
      }
}
