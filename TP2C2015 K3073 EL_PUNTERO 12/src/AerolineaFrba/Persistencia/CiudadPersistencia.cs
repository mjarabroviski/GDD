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

        public static int Eliminar(Ciudad ciudad)
        {
         
                    var param = new List<SPParameter>
                        {
                            new SPParameter("ID_Ciudad", ciudad.ID),
                        };

                    var sp = new StoreProcedure(DBQueries.Ciudad.SPEliminarCiudad, param);

            return sp.ExecuteNonQuery(null);
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

        public static int InsertarCiudad(Ciudad ciudadNueva)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Nombre_Ciudad", ciudadNueva.Nombre), 
                };

           var sp=  new StoreProcedure(DBQueries.Ciudad.SPInsertarCiudad, param);

            return sp.ExecuteNonQuery(null);
        }

        public static int ActualizarCiudad(Ciudad ciudadNueva)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Nombre_Ciudad", ciudadNueva.Nombre), 
                    new SPParameter("ID_Ciudad", ciudadNueva.ID)
                };

            var sp = new StoreProcedure(DBQueries.Ciudad.SPActualizarCiudad, param);

            return sp.ExecuteNonQuery(null);
        }

        public static Ciudad ObtenerCiudadPorId_Ciudad(int idCiudad)
        {
            //Obtengo la ciudad
            var param = new List<SPParameter> { new SPParameter("ID_Ciudad", idCiudad) };
            var sp = new StoreProcedure(DBQueries.Ciudad.SPObtenerCiudadPorId_Ciudad, param);

            //Retorno una lista de Ciudades a partir de un ExecuteReader
            List<Ciudad> ciudades = sp.ExecuteReader<Ciudad>();
            if (ciudades == null || ciudades.Count == 0)
                return null;

            return ciudades[0];
        }

        public static List<Ciudad> ObtenerCiudadesOrigenParaUnServicio(int ID_Servicio)
        {
            //Obtengo la lista de ciudades que cumplen ciertos filtros 
            var param = new List<SPParameter> { new SPParameter("ID_Servicio", ID_Servicio) };
            var sp = new StoreProcedure(DBQueries.Ciudad.SPObtenerCiudadesOrigenParaUnServicio, param);

            return sp.ExecuteReader<Ciudad>();
        }

        public static int CiudadTieneViajes(int idCiudad)
        {
            //Obtengo la ciudad
            var param = new List<SPParameter> { new SPParameter("ID_Ciudad", idCiudad) };
            var sp = new StoreProcedure(DBQueries.Ciudad.SPCiudadTieneViajes, param);

            //Retorno una lista de Ciudades a partir de un ExecuteReader
            List<Ruta> ciudades = sp.ExecuteReader<Ruta>();
            if (ciudades == null || ciudades.Count == 0)
                return 0;

            return ciudades.Count;
        }       
    }
}
