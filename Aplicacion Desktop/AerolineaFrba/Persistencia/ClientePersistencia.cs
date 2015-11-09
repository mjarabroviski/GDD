using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Herramientas;
using System.Data.SqlClient;
using Persistencia.Entidades;


namespace Persistencia
{
    public static class ClientePersistencia
    {
        public static Cliente ObtenerClientePorDNI(int doc, int tipo_Doc )
        {
            //Traigo el cliente cuyo tipo y nro de documento coincida con los parametros
            var param = new List<SPParameter> { new SPParameter("Documento", doc),
                                                new SPParameter("Tipo_Doc", tipo_Doc)
                                              };

            var sp = new StoreProcedure(DBQueries.Cliente.SPGetClientePorTipoYDocumento, param);

            List<Cliente> users = sp.ExecuteReader<Cliente>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }
    }
}
