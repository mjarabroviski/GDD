using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using Filtros;
using System.Data.SqlClient;

namespace Persistencia
{
    public class AeronavePersistencia
    {
        public static List<Aeronave> ObtenerTodas()
        {
            //Obtengo la lista de aeronaves almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.Aeronave.SPGetAeronaves);
            return sp.ExecuteReader<Aeronave>();
        }

        public static List<Aeronave> ObtenerAeronavesHabilitadas()
        {
            //Obtengo la lista de ciudades almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.Aeronave.SPObtenerAeronavesHabilitadas);
            return sp.ExecuteReader<Aeronave>();
        }

        public static List<Aeronave> ObtenerTodasPorParametros(AeronaveFiltros filtros)
        {
            var param = new List<SPParameter> { new SPParameter("Matricula", filtros.Matricula ?? (object)DBNull.Value),
                                                new SPParameter("Fabricante", filtros.Fabricante ?? (object)DBNull.Value),
                                                new SPParameter("Modelo", filtros.Modelo ?? (object)DBNull.Value),
                                                new SPParameter("Nombre_Servicio", filtros.Servicio ?? (object)DBNull.Value),
                                                new SPParameter("Fecha_Alta", (filtros.Fecha_Alta == DateTime.MinValue) ?  DateTime.Parse("01/01/1990") : filtros.Fecha_Alta)
                                              };

            var sp = new StoreProcedure(DBQueries.Aeronave.SPGetAeronavesPorParametros, param);

            return sp.ExecuteReader<Aeronave>();
        }

        public static List<Aeronave> ObtenerTodasPorParametrosComo(AeronaveFiltros filtros)
        {
            var param = new List<SPParameter> { new SPParameter("Matricula", filtros.Matricula ?? (object)DBNull.Value),
                                                new SPParameter("Fabricante", filtros.Fabricante ?? (object)DBNull.Value),
                                                new SPParameter("Modelo", filtros.Modelo ?? (object)DBNull.Value),
                                                new SPParameter("Nombre_Servicio", filtros.Servicio ?? (object)DBNull.Value),
                                                new SPParameter("Fecha_Alta", (filtros.Fecha_Alta == DateTime.MinValue) ?  DateTime.Parse("01/01/1990") : filtros.Fecha_Alta)
                                              };

            var sp = new StoreProcedure(DBQueries.Aeronave.SPGetAeronavesPorParametrosComo, param);

            return sp.ExecuteReader<Aeronave>();
        }

        public static int BajaPorVidaUtil(Aeronave aeronave)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Aeronave", aeronave.ID), 
                };

            var sp = new StoreProcedure(DBQueries.Aeronave.SPBajaPorVidaUtil, param);

            return sp.ExecuteNonQuery(null);
        }

        public static int SeleccionarAeronaveParaReemplazar(Aeronave aeronave)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Aeronave", aeronave.ID), 
                    new SPParameter("Modelo", aeronave.Modelo), 
                    new SPParameter("Fabricante", aeronave.Fabricante), 
                    new SPParameter("ID_Servicio", aeronave.ID_Servicio) 
                };

            var sp = new StoreProcedure(DBQueries.Aeronave.SPSeleccionReemplazo, param);

            return sp.ExecuteNonQuery(null);
        }

        public static Aeronave ObtenerPorMatricula(string matricula, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("Matricula", matricula) };
            var sp = new StoreProcedure(DBQueries.Aeronave.SPGetAeronavePorMatricula, param, transaction);

            var aeronaves = sp.ExecuteReaderTransactioned<Aeronave>(transaction);

            if (aeronaves == null || aeronaves.Count == 0)
                return null;

            return aeronaves[0];
        }

        public static Aeronave InsertarAeronave(Aeronave aeronave, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Matricula", aeronave.Matricula),
                    new SPParameter("Fabricante", aeronave.Fabricante),
                    new SPParameter("Modelo", aeronave.Modelo),
                    new SPParameter("ID_Servicio", aeronave.ID_Servicio), 
                    new SPParameter("KG_Totales", aeronave.KG_Totales),
                    new SPParameter("Fecha_Alta", aeronave.Fecha_Alta),
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DBQueries.Aeronave.SPInsertarAeronave, param, transaction)
                        : new StoreProcedure(DBQueries.Aeronave.SPInsertarAeronave, param);

            aeronave.ID = (int)sp.ExecuteScalar(transaction);

            return aeronave;
        }

        public static int eliminarAeronave(Aeronave aeronave)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Aeronave", aeronave.ID) };

            var sp =  new StoreProcedure(DBQueries.Aeronave.SPEliminarAeronave, param);

            return sp.ExecuteNonQuery(null);
        }
    }
}
