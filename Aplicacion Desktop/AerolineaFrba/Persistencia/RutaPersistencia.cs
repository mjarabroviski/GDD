using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class RutaPersistencia
    {
        public static List<Ruta> ObtenerTodas()
        {
            //Obtengo la lista de rutas almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.Ruta.SPGetAllRutas);
            return sp.ExecuteReader<Ruta>();
        }

        public static String ObtenerServicioPorID(int idServicio)
        {
            //Obtengo el servicio
            var param = new List<SPParameter> { new SPParameter("ID_Servicio", idServicio) };
            var sp = new StoreProcedure(DBQueries.Ruta.SPGetServicioPorID, param);

            //Retorno una lista de Servicios a partir de un ExecuteReader
            List<Servicio> servicios = sp.ExecuteReader<Servicio>();

            if (servicios == null || servicios.Count == 0)
                return null;

            return servicios[0].Nombre;
        }

        public static String ObtenerCiudadPorID(int idCiudad)
        {
            //Obtengo la ciudad
            var param = new List<SPParameter> { new SPParameter("ID_Ciudad", idCiudad) };
            var sp = new StoreProcedure(DBQueries.Ruta.SPGetCiudadPorID, param);

            //Retorno una lista de Ciudades a partir de un ExecuteReader
            List<Ciudad> ciudades = sp.ExecuteReader<Ciudad>();

            if (ciudades == null || ciudades.Count == 0)
                return null;

            return ciudades[0].Nombre;
        }

    }
}
