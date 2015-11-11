using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;

namespace Persistencia
{
    public static class RegistroMillasPersistencia
    {
        public static int ActualizarMillas(int viajeId)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Viaje", viajeId)
                };

            var sp = new StoreProcedure(DBQueries.RegistroMillas.SPActualizarMillas, param);

            return sp.ExecuteNonQuery(null);
        }
    }
}
