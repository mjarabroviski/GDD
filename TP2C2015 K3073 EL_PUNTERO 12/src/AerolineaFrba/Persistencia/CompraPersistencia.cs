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

        public static void CargarTablaDatosPasajeros(string tipoDoc, int nroDoc, string ape, string nom, string calle, string nroCalle, string telefono, DateTime fechaNac, string mail, int idButaca)
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

        private static int CargarDatosAuxiliares(string tipoDoc, int nroDoc, string ape, string nom, string calle, string nroCalle, string telefono, DateTime fechaNac, string mail, int idButaca, SqlTransaction transaccion)
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

        public static void GuardarPasajeros(int i, int idViaje, double precioPasajes)
        {
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    GuardarPasajerosAux(i,idViaje,precioPasajes,transaccion);
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error mientras se guardaban los pasajeros");
                }
            }
        }

        private static int GuardarPasajerosAux(int i, int idViaje, double precioPasajes, SqlTransaction transaccion)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Deseado", i),
                                                new SPParameter("ID_Viaje",idViaje),
                                                new SPParameter("Precio_Pasajes",precioPasajes)
                                              };
            var sp = (transaccion != null)
                ? new StoreProcedure(DBQueries.Compra.SPGuardarPasajeros, param, transaccion)
                : new StoreProcedure(DBQueries.Compra.SPGuardarPasajeros, param);

            return sp.ExecuteNonQuery(transaccion);
        }


        public static void GuardarAlQuePaga(ClienteAuxiliar cli)
        {
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    GuardarAlQuePagaAux(cli, transaccion);
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error mientras se guardaba al que pagó");
                }
            }
        }

        private static int GuardarAlQuePagaAux(ClienteAuxiliar cli, SqlTransaction transaccion)
        {
            var param = new List<SPParameter> { new SPParameter("Apellido", cli.Apellido),
                                                new SPParameter("Direccion", cli.Direccion),
                                                new SPParameter("Fecha_Nacimiento", cli.Fecha_Nacimiento),
                                                new SPParameter("ID_Tipo_Documento", cli.ID_Tipo_Documento),
                                                new SPParameter("Mail", cli.Mail),
                                                new SPParameter("Nombre", cli.Nombre),
                                                new SPParameter("Nro_Documento", cli.Nro_Documento),
                                                new SPParameter("Telefono", cli.Telefono)
                                              };
            var sp = (transaccion != null)
                ? new StoreProcedure(DBQueries.Compra.SPGuardarAlQuePaga, param, transaccion)
                : new StoreProcedure(DBQueries.Compra.SPGuardarAlQuePaga, param);

            return sp.ExecuteNonQuery(transaccion);
        }

        public static void GuardarTarjetaYConfirmarCompra(ClienteAuxiliar cli, int idTipoTarjeta, int nroTarjeta, int cantCuotas, int idViaje, decimal cantEnc, double precioEncomienda,Usuario usuarioActual)
        {
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    int? ID_Usuario;
                    if (usuarioActual != null)
                    {
                        ID_Usuario = usuarioActual.ID;
                    }
                    else
                    {
                        ID_Usuario = null;
                    }
                    GuardarTarjetaYConfirmarCompraAux(cli, idTipoTarjeta, nroTarjeta, cantCuotas, idViaje, cantEnc, precioEncomienda,ID_Usuario, transaccion);
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error mientras se guardaba la compra");
                }
            }
        }

        public static int GuardarTarjetaYConfirmarCompraAux(ClienteAuxiliar cli, int idTipoTarjeta, int nroTarjeta, int cantCuotas, int idViaje, decimal cantEnc, double precioEncomienda,int? usuarioActual, SqlTransaction transaccion)
        {
            var param = new List<SPParameter> { new SPParameter("Apellido", cli.Apellido),
                                                new SPParameter("Nombre", cli.Nombre),
                                                new SPParameter("Nro_Documento", cli.Nro_Documento),
                                                new SPParameter("ID_Tipo_Tarjeta", idTipoTarjeta),
                                                new SPParameter("Nro_Tarjeta", nroTarjeta),
                                                new SPParameter("Cant_Cuotas", cantCuotas),
                                                new SPParameter("ID_Viaje", idViaje),
                                                new SPParameter("KG", (int)cantEnc),
                                                new SPParameter("Precio_Encomienda", precioEncomienda),
                                                new SPParameter("ID_Usuario",usuarioActual ?? (object)DBNull.Value)
                                              };
            var sp = (transaccion != null)
                ? new StoreProcedure(DBQueries.Compra.SPGuardarTarjetaYCompra, param, transaccion)
                : new StoreProcedure(DBQueries.Compra.SPGuardarTarjetaYCompra, param);

            return sp.ExecuteNonQuery(transaccion);
        }

        public static void GuardarCompraEnEfectivo(ClienteAuxiliar cli, int idViaje, decimal cantEnc, double precioEncomienda, Usuario usuarioActual)
        {
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    GuardarCompraEnEfectivoAux(cli, idViaje, cantEnc, precioEncomienda, usuarioActual, transaccion);
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error mientras se guardaba la compra");
                }
            }
        }

        private static int GuardarCompraEnEfectivoAux(ClienteAuxiliar cli, int idViaje, decimal cantEnc, double precioEncomienda, Usuario usuarioActual, SqlTransaction transaccion)
        {
            var param = new List<SPParameter> { new SPParameter("Apellido", cli.Apellido),
                                                new SPParameter("Nombre", cli.Nombre),
                                                new SPParameter("Nro_Documento", cli.Nro_Documento),
                                                new SPParameter("ID_Viaje", idViaje),
                                                new SPParameter("KG", (int)cantEnc),
                                                new SPParameter("Precio_Encomienda", precioEncomienda),
                                                new SPParameter("ID_Usuario",usuarioActual.ID)
                                              };
            var sp = (transaccion != null)
                ? new StoreProcedure(DBQueries.Compra.SPGuardarCompraEnEfectivo, param, transaccion)
                : new StoreProcedure(DBQueries.Compra.SPGuardarCompraEnEfectivo, param);

            return sp.ExecuteNonQuery(transaccion);
        }

        public static int ObtenerPNR()
        {
            var param = new List<SPParameter>{ };

            var sp = new StoreProcedure(DBQueries.Compra.SPObtenerPNR, param);

            List<Compra> compras = sp.ExecuteReader<Compra>();

            return compras[0].ID_Compra;
        }
    }
}
