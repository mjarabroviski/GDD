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
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    CrearTablaAuxiliarPasajeros(transaccion);
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error mientras se borraba la tabla auxiliar");
                }
            }
        }

        public static int CrearTablaAuxiliarPasajeros(SqlTransaction transaccion)
        {
            var param = new List<SPParameter> { };
            var sp = (transaccion != null)
                ? new StoreProcedure(DBQueries.Compra.SPCrearTablaAuxiliarPasajeros,param,transaccion)
                : new StoreProcedure(DBQueries.Compra.SPCrearTablaAuxiliarPasajeros,param);

            return sp.ExecuteNonQuery(transaccion);
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

        private static int BorrarTabla(SqlTransaction transaccion)
        {
            var param = new List<SPParameter> {};

            var sp = (transaccion != null)
            ? new StoreProcedure(DBQueries.Compra.SPBorrarTablaAuxiliarPasajeros, param, transaccion)
            : new StoreProcedure(DBQueries.Compra.SPBorrarTablaAuxiliarPasajeros, param);

            return sp.ExecuteNonQuery(transaccion);
        }

        public static void CargarTablaDatosPasajeros(string tipoDoc, int nroDoc, string ape, string nom, string calle, string nroCalle, int telefono, DateTime fechaNac, string mail, int idButaca)
        {
             /* 
             * Lo tengo que hacer transaccionado ya que no quiero que pueda llegar a quedar una ruta insertada
             * por la mitad debido a un error
             */
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    CargarDatosAuxiliares(tipoDoc, nroDoc, ape, nom, calle, nroCalle, telefono, fechaNac, mail, idButaca,transaccion);
                    transaccion.Commit();
                }
                catch
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error durante la carga de la tabla auxiliar");
                }
            }
            
        }

        private static int CargarDatosAuxiliares(string tipoDoc, int nroDoc, string ape, string nom, string calle, string nroCalle, int telefono, DateTime fechaNac, string mail, int idButaca, SqlTransaction transaccion)
        {
            var param = new List<SPParameter> {
                                                 new SPParameter("Tipo_Doc",tipoDoc),
                                                 new SPParameter("Nro_Doc",nroDoc),
                                                 new SPParameter("Apellidos",ape),
                                                 new SPParameter("Nombres",nom),
                                                 new SPParameter("Calle",calle),
                                                 new SPParameter("Nro_Calle",nroCalle),
                                                 new SPParameter("Telefono",telefono),
                                                 new SPParameter("Fecha_Nacimiento",fechaNac),
                                                 new SPParameter("Mail",mail ?? (object)DBNull.Value),
                                                 new SPParameter("ID_Butaca",idButaca)
                                              };

            var sp = (transaccion != null)
            ? new StoreProcedure(DBQueries.Compra.SPCargarTablaAuxiliarPasajeros, param, transaccion)
            : new StoreProcedure(DBQueries.Compra.SPCargarTablaAuxiliarPasajeros, param);

            return sp.ExecuteNonQuery(transaccion);
        }

        public static Cliente ObtenerClientePorDoc(string tipoDoc, int? nroDoc)
        {
            var param = new List<SPParameter>{
                                                new SPParameter("Tipo_Doc",tipoDoc),
                                                new SPParameter("Nro_Doc",nroDoc ?? (object)DBNull.Value),
                                             };
            var sp = new StoreProcedure(DBQueries.Compra.SPObtenerClientePorDoc, param);

            List<Cliente> clientes = sp.ExecuteReader<Cliente>();

            if (clientes == null || clientes.Count == 0 || clientes.Count>1)
                return null;

            return clientes[0];
        }
    }
}
