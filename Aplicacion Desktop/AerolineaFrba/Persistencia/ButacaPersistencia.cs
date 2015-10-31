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
    }
}
