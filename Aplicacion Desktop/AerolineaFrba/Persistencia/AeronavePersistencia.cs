using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using Filtros;

namespace Persistencia
{
    public class AeronavePersistencia
    {
        public static List<Aeronave> ObtenerTodas()
        {
            //Obtengo la lista de ciudades almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.Aeronave.SPGetAeronaves);
            return sp.ExecuteReader<Aeronave>();
        }

        public static List<Aeronave> ObtenerTodasPorParametros(AeronaveFiltros filtros)
        {
            var param = new List<SPParameter> { new SPParameter("Matricula", filtros.Matricula ?? (object)DBNull.Value),
                                                new SPParameter("Fabricante", filtros.Fabricante ?? (object)DBNull.Value),
                                                new SPParameter("Modelo", filtros.Modelo ?? (object)DBNull.Value),
                                                new SPParameter("Nombre_Servicio", filtros.Servicio ?? (object)DBNull.Value),
                                                new SPParameter("Fecha_Alta", filtros.Fecha_Alta)
                                              };

            var sp = new StoreProcedure(DBQueries.Aeronave.SPGetAeronavesPorParametros, param);

            return sp.ExecuteReader<Aeronave>();
        }

       /* private DateTime obtenerFecha(DateTime fecha) {
            if (fecha == DateTime.MinValue) return DateTime.MinValue;
            return fecha;

        }*/

        public static List<Aeronave> ObtenerTodasPorParametrosComo(AeronaveFiltros filtros)
        {
            var param = new List<SPParameter> { new SPParameter("Matricula", filtros.Matricula ?? (object)DBNull.Value),
                                                new SPParameter("Fabricante", filtros.Fabricante ?? (object)DBNull.Value),
                                                new SPParameter("Modelo", filtros.Modelo ?? (object)DBNull.Value),
                                                new SPParameter("Nombre_Servicio", filtros.Servicio ?? (object)DBNull.Value),
                                                new SPParameter("Fecha_Alta", filtros.Fecha_Alta)
                                              };

            var sp = new StoreProcedure(DBQueries.Aeronave.SPGetAeronavesPorParametrosComo, param);

            return sp.ExecuteReader<Aeronave>();
        }
    }
}
