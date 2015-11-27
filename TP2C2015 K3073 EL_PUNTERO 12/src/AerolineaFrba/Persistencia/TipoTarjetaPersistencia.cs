using Persistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public static class TipoTarjetaPersistencia
    {
        public static List<TipoTarjeta> ObtenerTodos()
        {
            //Obtengo la lista de tipos de tarjetas almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.TipoTarjeta.SPGetAllTipoTarjeta);
            return sp.ExecuteReader<TipoTarjeta>();
        }
    }
}
