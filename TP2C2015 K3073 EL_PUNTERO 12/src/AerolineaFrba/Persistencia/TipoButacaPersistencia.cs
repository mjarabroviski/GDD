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

        public static List<TipoButaca> ObtenerTodos(SqlTransaction transaction)
        {
            //Obtengo la lista de tipos de butacas almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.TipoButaca.SPGetTiposButacas,null,transaction);
            return sp.ExecuteReaderTransactioned<TipoButaca>(transaction);
        }

        public static TipoButaca ObtenerTipoPorDescripcion(string tipo, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("Tipo", tipo)};
            var sp = new StoreProcedure(DBQueries.TipoButaca.SPGetTipoPorDescripcion, param, transaction);

            var tipos = sp.ExecuteReaderTransactioned<TipoButaca>(transaction);

            if (tipos == null || tipos.Count == 0)
                return null;

            return tipos[0];
        }

        public static TipoButaca ObtenerTipoButaca(Butaca butaca)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Tipo", butaca.ID_Tipo) };
            var sp = new StoreProcedure(DBQueries.TipoButaca.SPGetTipoButacaPorButaca, param);

            var tipos = sp.ExecuteReader<TipoButaca>();
            return tipos[0];
        }
    }
}
