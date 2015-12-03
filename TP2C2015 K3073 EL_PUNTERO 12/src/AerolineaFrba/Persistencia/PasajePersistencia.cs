using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using System.Data;
using System.Data.SqlClient;
using Configuracion;

namespace Persistencia
{
    public static class PasajePersistencia
    {

        public static List<Pasaje> ObtenerPasajesFuturos(int ID_Cliente)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Cliente", ID_Cliente),
                    new SPParameter("Fecha_Sistema", ConfiguracionDeVariables.FechaSistema)
                };
            var sp = new StoreProcedure(DBQueries.Pasaje.SPObtenerPasajesFuturos,param);
            List<Pasaje> pasajes = sp.ExecuteReader<Pasaje>();

            if (pasajes == null || pasajes.Count == 0)
                return null;

            return pasajes;
        }

        public static DateTime ObtenerFechaSalidaDePasaje(int ID_Pasaje)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Pasaje", ID_Pasaje)
                };
            var sp = new StoreProcedure(DBQueries.Pasaje.SPObtenerFechaSalidaDePasaje, param);
            List<Viaje> viajes = sp.ExecuteReader<Viaje>();
            return viajes[0].Fecha_Salida;
        }

        public static Ruta ObtenerRutaDePasaje(int ID_Pasaje)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Pasaje", ID_Pasaje)
                };
            var sp = new StoreProcedure(DBQueries.Pasaje.SPObtenerRutaDePasaje, param);
            List<Ruta> rutas = sp.ExecuteReader<Ruta>();
            return rutas[0];
        } 
    }
}