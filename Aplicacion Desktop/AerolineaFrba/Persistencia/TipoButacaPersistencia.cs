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
    public static class TipoButacaPersistencia
    {
        public static TipoButaca ObtenerTipoPorButaca(Butaca butaca, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Tipo", butaca.ID_Tipo) };
            var sp = (transaction != null)
                    ? new StoreProcedure(DBQueries.TipoButaca.SPGetTipoButacaPorButaca, param, transaction)
                    : new StoreProcedure(DBQueries.TipoButaca.SPGetTipoButacaPorButaca, param);

            var tipos = sp.ExecuteReaderTransactioned<TipoButaca>(transaction);
            return tipos[0];
        }
    }
}
