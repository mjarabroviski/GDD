using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using Filtros;

namespace Persistencia
{
    public static class EstadisticaPersistencia
    {
        public static List<Estadistica> ObtenerDestinosConMasPasajesComprados(EstadisticaFiltros filtros)
        {
            var param = new List<SPParameter> { 
                new SPParameter("Fecha_Desde", filtros.FechaDesde),
                new SPParameter("Fecha_Hasta", filtros.FechaHasta)
            };
            var sp = new StoreProcedure(DBQueries.Estadistica.SPGetDestinosConMasPasajesComprados, param);

            var statistics = sp.ExecuteReader<Estadistica>();

            if (statistics == null || statistics.Count == 0)
                return null;

            return statistics;
        }

        public static List<Estadistica> ObtenerDestinosConMasAeronavesVacias(EstadisticaFiltros filtros)
        {
            var param = new List<SPParameter> { 
                new SPParameter("Fecha_Desde", filtros.FechaDesde),
                new SPParameter("Fecha_Hasta", filtros.FechaHasta)
            };
            var sp = new StoreProcedure(DBQueries.Estadistica.SPGetDestinosConMasAeronavesVacias, param);

            var statistics = sp.ExecuteReader<Estadistica>();

            if (statistics == null || statistics.Count == 0)
                return null;

            return statistics;
        }

        public static List<Estadistica> ObtenerClientesConMasPuntosAcumulados(EstadisticaFiltros filtros)
        {
            var param = new List<SPParameter> { 
                new SPParameter("Fecha_Desde", filtros.FechaDesde),
                new SPParameter("Fecha_Hasta", filtros.FechaHasta)
            };
            var sp = new StoreProcedure(DBQueries.Estadistica.SPGetClientesConMasPuntosAcumulados, param);

            var statistics = sp.ExecuteReader<Estadistica>();

            if (statistics == null || statistics.Count == 0)
                return null;

            return statistics;
        }

        public static List<Estadistica> ObtenerDestinosConMasPasajesCancelados(EstadisticaFiltros filtros)
        {
            var param = new List<SPParameter> { 
                new SPParameter("Fecha_Desde", filtros.FechaDesde),
                new SPParameter("Fecha_Hasta", filtros.FechaHasta)
            };
            var sp = new StoreProcedure(DBQueries.Estadistica.SPGetDestinosConMasPasajesCancelados, param);

            var statistics = sp.ExecuteReader<Estadistica>();

            if (statistics == null || statistics.Count == 0)
                return null;

            return statistics;
        }

        public static List<Estadistica> ObtenerAeronavesConMayorCantDeDiasFueraDeServicio(EstadisticaFiltros filtros)
        {
            var param = new List<SPParameter> { 
                new SPParameter("Fecha_Desde", filtros.FechaDesde),
                new SPParameter("Fecha_Hasta", filtros.FechaHasta)
            };
            var sp = new StoreProcedure(DBQueries.Estadistica.SPGetAeronavesConMayorCantDeDiasFueraDeServicio, param);

            var statistics = sp.ExecuteReader<Estadistica>();

            if (statistics == null || statistics.Count == 0)
                return null;

            return statistics;
        }
    }
}
