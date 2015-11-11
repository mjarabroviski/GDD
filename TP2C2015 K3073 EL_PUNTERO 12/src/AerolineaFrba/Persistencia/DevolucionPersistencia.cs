using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public static class DevolucionPersistencia
    {
        public static void CancelarPasajesYEncomiendasPorBajaAeronave(Aeronave aeronave, String motivo, Usuario usuario)
        {
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    CancelarPorAeronave(aeronave, motivo, usuario, transaccion);
                    transaccion.Commit();

                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error durante la cancelación de pasajes y encomiendas");
                }
            }
        }

        private static int CancelarPorAeronave(Aeronave aeronave, String motivo, Usuario usuario, SqlTransaction transaccion)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Aeronave",aeronave.ID),
                    new SPParameter("Motivo",motivo),
                    new SPParameter("ID_Usuario",usuario.ID)
                };

            var sp = (transaccion != null)
                        ? new StoreProcedure(DBQueries.Devolucion.SPCancelarPasajesYEncomiendasPorBajaAeronave, param, transaccion)
                        : new StoreProcedure(DBQueries.Devolucion.SPCancelarPasajesYEncomiendasPorBajaAeronave, param);

            return sp.ExecuteNonQuery(transaccion);
        }

        public static void CancelarPasajesYEncomiendasPorBajaServicioAeronave(Aeronave aeronave, String motivo,DateTime comienzo, DateTime fin, Usuario usuario)
        {
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    CancelarPorAeronaveServicio(aeronave, motivo, usuario, comienzo, fin, transaccion);
                    transaccion.Commit();

                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error durante la cancelación de pasajes y encomiendas");
                }
            }
        }

        private static int CancelarPorAeronaveServicio(Aeronave aeronave, String motivo, Usuario usuario,DateTime comienzo, DateTime fin, SqlTransaction transaccion)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Aeronave",aeronave.ID),
                    new SPParameter("Motivo",motivo),
                    new SPParameter("ID_Usuario",usuario.ID),
                    new SPParameter("Comienzo",comienzo),
                    new SPParameter("Reinicio",fin)
                };

            var sp = (transaccion != null)
                        ? new StoreProcedure(DBQueries.Devolucion.SPCancelarPasajesYEncomiendasPorBajaServicioAeronave, param, transaccion)
                        : new StoreProcedure(DBQueries.Devolucion.SPCancelarPasajesYEncomiendasPorBajaServicioAeronave, param);

            return sp.ExecuteNonQuery(transaccion);
        }
    }
}
