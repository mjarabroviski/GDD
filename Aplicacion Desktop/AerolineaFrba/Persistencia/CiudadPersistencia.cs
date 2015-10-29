using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Persistencia.Entidades;
using System.Data;
using Filtros;

namespace Persistencia
{
    public static class CiudadPersistencia
    {
        public static List<Ciudad> ObtenerTodos()
        {
            //Obtengo la lista de ciudades almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.Ciudad.SPGetCiudades);
            return sp.ExecuteReader<Ciudad>();
        }

        public static int Eliminar(Ciudad ciudad, SqlTransaction transaccion)
        {
         
                    var param = new List<SPParameter>
                        {
                            new SPParameter("ID_Ciudad", ciudad.ID),
                        };

                    var sp = (transaccion != null)
                                ? new StoreProcedure(DBQueries.Ciudad.SPEliminarCiudad, param, transaccion)
                                : new StoreProcedure(DBQueries.Ciudad.SPEliminarCiudad, param);

            return sp.ExecuteNonQuery(transaccion);
        }

        public static int ObtenerIDPorNombreDeCiudad(string ciudad)
        {
            var param = new List<SPParameter>
            {
                new SPParameter("Nombre_Ciudad",ciudad),
            };

            var sp = new StoreProcedure(DBQueries.Ciudad.SPObtenerIDPorNombreDeCiudad, param);

            List <Ciudad> ciudades= sp.ExecuteReader<Ciudad>();

            return ciudades[0].ID;

        }

        public static List<Ciudad> ObtenerTodasPorParametro(CiudadFiltros filtros) {
            //Obtengo la lista de ciudades que cumplen ciertos filtros (busqueda exacta)
            var param = new List<SPParameter>
                {
                    new SPParameter("Nombre", filtros.Nombre ?? (object)DBNull.Value)
                };

            var sp = new StoreProcedure(DBQueries.Ciudad.SPObtenerCiudadesPorParametros, param);

            return sp.ExecuteReader<Ciudad>();
        }

        public static List<Ciudad> ObtenerTodosPorParametroComo(CiudadFiltros filtros)
        {
            //Obtengo la lista de ciudades que cumplen ciertos filtros 
            var param = new List<SPParameter>
                {
                    new SPParameter("Nombre", filtros.Nombre ?? (object)DBNull.Value)
                };

            var sp = new StoreProcedure(DBQueries.Ciudad.SPObtenerCiudadesPorParametrosComo, param);

            return sp.ExecuteReader<Ciudad>();
        }
    }
}
