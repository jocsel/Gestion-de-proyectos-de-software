using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Ndetalleventa
    {
        public List<Edetalleventa> obtenerlistdetalle()
        {

            try
            {

                Ddetalleventa datosdetalle = new Ddetalleventa();
                return datosdetalle.obtenerlistadetalle();



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Edetalleventa> obtenerlistdetallex()
        {

            try
            {

                Ddetalleventa datosdetalle = new Ddetalleventa();
                return datosdetalle.obtenerlistadetallex();



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
    }
