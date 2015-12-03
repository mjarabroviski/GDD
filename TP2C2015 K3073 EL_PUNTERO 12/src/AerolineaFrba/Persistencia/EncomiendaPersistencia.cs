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
    public static class EncomiendaPersistencia
    {

        public static List<Encomienda> ObtenerEncomiendasFuturas(int ID_Cliente)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Cliente", ID_Cliente),
                    new SPParameter("Fecha_Sistema", ConfiguracionDeVariables.FechaSistema)
                };
            var sp = new StoreProcedure(DBQueries.Encomienda.SPObtenerEncomiendasFuturas,param);
            List<Encomienda> encomiendas = sp.ExecuteReader<Encomienda>();

            if (encomiendas == null || encomiendas.Count == 0)
                return null;

            return encomiendas;
        }

        public static DateTime ObtenerFechaSalidaDeEncomienda(int ID_Encomienda)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Encomienda", ID_Encomienda)
                };
            var sp = new StoreProcedure(DBQueries.Encomienda.SPObtenerFechaSalidaDeEncomienda, param);
            List<Viaje> viajes = sp.ExecuteReader<Viaje>();
            return viajes[0].Fecha_Salida;
        }

        public static Ruta ObtenerRutaDeEncomienda(int ID_Encomienda)   
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Encomienda", ID_Encomienda)
                };
            var sp = new StoreProcedure(DBQueries.Encomienda.SPObtenerRutaDeEncomienda,param);
            List<Ruta> rutas = sp.ExecuteReader<Ruta>();
            return rutas[0] ;
        } 
    }
}
