using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using Configuracion;

namespace Persistencia
{
    public static class RegistroMillasPersistencia
    {
        public static int ActualizarMillas(int viajeId)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Viaje", viajeId),
                    new SPParameter("Fecha_Actual", ConfiguracionDeVariables.FechaSistema)
                };

            var sp = new StoreProcedure(DBQueries.RegistroMillas.SPActualizarMillas, param);

            return sp.ExecuteNonQuery(null);
        }

        public static List<RegistroMillas> ObtenerTodos()
        {
            //Obtengo la lista de registros almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.RegistroMillas.SPGetAllRegistrosMillas);
            return sp.ExecuteReader<RegistroMillas>();
        }

        public static List<RegistroMillas> ObtenerPorIDCliente(int id)
        {
            //Obtengo la lista de ciudades que cumplen ciertos filtros 
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Cliente", id)
                };

            var sp = new StoreProcedure(DBQueries.RegistroMillas.SPObtenerRegistrosPorIDCliente, param);

            return sp.ExecuteReader<RegistroMillas>();
        }
    }
}
