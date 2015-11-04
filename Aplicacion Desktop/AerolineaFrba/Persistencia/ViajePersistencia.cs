using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using System.Data.SqlClient;

namespace Persistencia
{
    public class ViajePersistencia
    {
        public static int GenerarViaje(DateTime Fecha_Llegada,DateTime Fecha_Salida,DateTime Fecha_Llegada_Estimada,int ID_Ruta,int ID_Aeronave)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Fecha_Llegada",Fecha_Llegada), 
                    new SPParameter("Fecha_Salida", Fecha_Salida), 
                    new SPParameter("Fecha_Llegada_Estimada", Fecha_Llegada_Estimada), 
                    new SPParameter("ID_Ruta", ID_Ruta),
                    new SPParameter("ID_Aeronave",ID_Aeronave),
                };

            var sp = new StoreProcedure(DBQueries.Viaje.SPGenerarViaje, param);

            return sp.ExecuteNonQuery(null);
        }

        public static List<Viaje> ObtenerViajePorParametros(Filtros.ViajeFiltros filtros)
        {
            var param = new List<SPParameter>
            { 
                new SPParameter("Fecha_Salida",filtros.FechaSalida),
                new SPParameter("Ciudad_Origen", filtros.CiudadOrigen),
                new SPParameter("Ciudad_Destino", filtros.CiudadDestino),
            };

            var sp = new StoreProcedure(DBQueries.Viaje.SPFiltrarViajes, param);

            return sp.ExecuteReader<Viaje>();
        }

        public static String ObtenerCiudadOrigenPorIDRuta(int p)
        {
            var param = new List<SPParameter>
            { 
                new SPParameter("ID_Ruta",p)
            };

            var sp = new StoreProcedure(DBQueries.Viaje.SPCiudadOrigenPorIDRuta, param);

            List<Ciudad> ciudades = sp.ExecuteReader<Ciudad>();

            if (ciudades == null || ciudades.Count == 0)
                return null;

            return ciudades[0].Nombre;
        }

        public static String ObtenerCiudadDestinoPorIDRuta(int p)
        {
            var param = new List<SPParameter>
            { 
                new SPParameter("ID_Ruta",p)
            };

            var sp = new StoreProcedure(DBQueries.Viaje.SPCiudadDestinoPorIDRuta, param);

            List<Ciudad> ciudades = sp.ExecuteReader<Ciudad>();

            if (ciudades == null || ciudades.Count == 0)
                return null;

            return ciudades[0].Nombre;
        }

        public static int ObtenerButacasDisponibles(int p)
        {
            var param = new List<SPParameter>
            { 
                new SPParameter("ID_Viaje",p)
            };

            var sp = new StoreProcedure(DBQueries.Viaje.SPObtenerButacasDisponibles, param);

            return (int)sp.ExecuteScalar(null);
        }

        public static int ObtenerKGSDisponibles(int p)
        {
                var param = new List<SPParameter>
            { 
                new SPParameter("ID_Viaje",p)
            };

            var sp = new StoreProcedure(DBQueries.Viaje.SPObtenerKGSDisponibles, param);

            return (int)sp.ExecuteScalar(null);
        }
        
        public static bool ValidarHorarioDeAeronave(DateTime fechaSalida, DateTime fechaLlegadaEstimada, int ID_Aeronave)
        {

            var param = new List<SPParameter>
                {
                    new SPParameter("Fecha_Salida", fechaSalida), 
                    new SPParameter("Fecha_Llegada_Estimada", fechaLlegadaEstimada), 
                    new SPParameter("ID_Aeronave",ID_Aeronave),
                };

            var sp = new StoreProcedure(DBQueries.Viaje.SPValidarHorarioDeAeronave, param);

            return sp.ExecuteNonQuery(null) == 0;
        }


        public static List<Viaje> ObtenerViajesPorAeronave(Aeronave aeronave, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Aeronave", aeronave.ID) };
            var sp = new StoreProcedure(DBQueries.Viaje.SPGetViajesPorAeronave, param, transaction);

            var viajes = sp.ExecuteReaderTransactioned<Viaje>(transaction);

            if (viajes == null || viajes.Count == 0)
                return null;

            return viajes;
        }

        public static List<Aeronave> ValidarAeronaveDelViaje(int ID_Aeronave, int ID_Ruta, DateTime fechasalida, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Fecha_Salida", fechasalida), 
                    new SPParameter("ID_Ruta",ID_Ruta),
                    new SPParameter("ID_Aeronave",ID_Aeronave),
                };

            var sp = new StoreProcedure(DBQueries.Viaje.SPValidarAeronaveDelViaje, param);

            List<Aeronave> aeronaves = sp.ExecuteReaderTransactioned<Aeronave>(transaction);

             if (aeronaves == null || aeronaves.Count == 0)
                return null;

            return aeronaves;
        }

        public static int ReemplazarViajesDePor(Aeronave aeronaveAReemplazar, Aeronave aeronaveNueva)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Reemplazo", aeronaveAReemplazar.ID), 
                    new SPParameter("ID_Nueva", aeronaveNueva.ID), 
                };

            var sp = new StoreProcedure(DBQueries.Aeronave.SPReemplazo, param);

            return sp.ExecuteNonQuery(null);
        }

        public static object ObtenerServicioPorIDRuta(int p)
        {
            var param = new List<SPParameter>
            { 
                new SPParameter("ID_Ruta",p)
            };

            var sp = new StoreProcedure(DBQueries.Viaje.SPServicioPorIDRuta, param);

            List<Servicio> servicios = sp.ExecuteReader<Servicio>();

            if (servicios == null || servicios.Count == 0)
                return null;

            return servicios[0].Nombre;
        }
    }
}
