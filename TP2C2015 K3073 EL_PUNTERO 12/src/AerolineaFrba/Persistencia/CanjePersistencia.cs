using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;

namespace Persistencia
{
    public static class CanjePersistencia
    {
        public static List<Canje> ObtenerPorIDCliente(int id)
        {
            //Obtengo la lista de ciudades que cumplen ciertos filtros 
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Cliente", id)
                };

            var sp = new StoreProcedure(DBQueries.Canje.SPObtenerCanjePorIDCliente, param);

            return sp.ExecuteReader<Canje>();
        }
    }
}
