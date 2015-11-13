using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class CompraPersistencia
    {
        public static void CrearTablaDatosPasajeros()
        {
            var sp = new StoreProcedure(DBQueries.Compra.SPCrearTablaAuxiliarPasajeros);
        }

        public static void BorrarTablaAuxiliar()
        {
             /* 
             * Lo tengo que hacer transaccionado ya que no quiero que pueda llegar a quedar una ruta insertada
             * por la mitad debido a un error
             */
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    BorrarTabla(transaccion);
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error mientras se borraba la tabla auxiliar");
                }
            }
        }

        private static void BorrarTabla(SqlTransaction transaccion)
        {
            var param = new List<SPParameter> {};

            var sp = (transaccion != null)
            ? new StoreProcedure(DBQueries.Compra.SPBorrarTablaAuxiliarPasajeros, param, transaccion)
            : new StoreProcedure(DBQueries.Compra.SPBorrarTablaAuxiliarPasajeros, param);
        }
    }
}
