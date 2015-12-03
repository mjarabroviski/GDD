using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using Herramientas;
using System.Data.SqlClient;

namespace Persistencia
{
    public static class ButacaPersistencia
    {
        public static Butaca ObtenerIdTipoPorDescripcion(string descripcion, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("Descripcion", descripcion) };
            var sp = new StoreProcedure(DBQueries.Butaca.SPGetIdTipoPorDescripcion, param, transaction);

            var butacas = sp.ExecuteReaderTransactioned<Butaca>(transaction);

            if (butacas == null || butacas.Count == 0)
                return null;

            return butacas[0];
        }

        public static Butaca InsertarButaca(Butaca butaca, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Numero", butaca.Numero),
                    new SPParameter("Tipo", butaca.ID_Tipo),
                    new SPParameter("ID_Aeronave", butaca.ID_Aeronave),
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DBQueries.Butaca.SPInsertarButaca, param, transaction)
                        : new StoreProcedure(DBQueries.Butaca.SPInsertarButaca, param);

            butaca.ID = (int)sp.ExecuteScalar(transaction);
            return butaca;
        }

        public static List<Butaca> ObtenerTodasDeAeronave(Aeronave aeronave, SqlTransaction transaction)
        {
            //Obtengo la lista de butacas de una aeronave
            var param = new List<SPParameter>{ new SPParameter("ID_Aeronave",aeronave.ID) };

            var sp = (transaction != null)
                    ? new StoreProcedure(DBQueries.Butaca.SPGetButacasDeAeronave, param, transaction)
                    : new StoreProcedure(DBQueries.Butaca.SPGetButacasDeAeronave, param);

            return sp.ExecuteReaderTransactioned<Butaca>(transaction);
        }

        public static int ModificarButaca(Butaca butaca, SqlTransaction transaccion)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Butaca", butaca.ID),
                    new SPParameter("Tipo", butaca.ID_Tipo)
                };

            var sp = (transaccion != null)
                        ? new StoreProcedure(DBQueries.Butaca.SPModificarButaca, param, transaccion)
                        : new StoreProcedure(DBQueries.Butaca.SPModificarButaca, param);

            return sp.ExecuteNonQuery(transaccion);
        }

        public static int DarDeBajaButaca(Butaca butaca, SqlTransaction transaccion)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Butaca", butaca.ID),
                };

            var sp = (transaccion != null)
                        ? new StoreProcedure(DBQueries.Butaca.SPDarDeBajaButaca, param, transaccion)
                        : new StoreProcedure(DBQueries.Butaca.SPDarDeBajaButaca, param);

            return sp.ExecuteNonQuery(transaccion);
        }

        public static int ObtenerMaxNroButaca(Aeronave aeronave, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Aeronave", aeronave.ID)};

            var sp = (transaction != null)
                    ? new StoreProcedure(DBQueries.Butaca.SPGetMaxNroButaca, param, transaction)
                    : new StoreProcedure(DBQueries.Butaca.SPGetMaxNroButaca, param);

            var butacas = sp.ExecuteReaderTransactioned<Butaca>(transaction);
            return butacas[0].Numero;
        }

        public static int ObtenerCantButacasPorAeronave(Aeronave aeronave, String descripcion, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Aeronave", aeronave.ID),
                                                new SPParameter("Descripcion",descripcion)
                                              };

            var sp = (transaction != null)
                    ? new StoreProcedure(DBQueries.Butaca.SPGetCantButacasPorAeronave, param, transaction)
                    : new StoreProcedure(DBQueries.Butaca.SPGetCantButacasPorAeronave, param);

            var butacas = sp.ExecuteReaderTransactioned<Butaca>(transaction);
            return butacas[0].Numero;
        }

        public static List<Butaca> ObtenerTodasLasLibresDeAeronave(Viaje viaje)
        {
            //Obtengo la lista de butacas habilitadas de una aeronave
            var param = new List<SPParameter> { new SPParameter("ID_Viaje", viaje.ID) };

            var sp = new StoreProcedure(DBQueries.Butaca.SPObtenerInfoButacasDisponibles, param);

            return sp.ExecuteReader<Butaca>();
        }

        public static int HabilitarButaca(Butaca butaca, SqlTransaction transaccion)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Butaca", butaca.ID)};

            var sp = (transaccion != null)
                    ? new StoreProcedure(DBQueries.Butaca.SPHabilitarButaca, param,transaccion)
                    : new StoreProcedure(DBQueries.Butaca.SPHabilitarButaca, param);

            return sp.ExecuteNonQuery(transaccion);
        }
    }
}
