using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using Configuracion;

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

        public static int GenerarCanje(Producto producto, int cantidad, Cliente cliente)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Producto", producto.ID),
                    new SPParameter("Cantidad", cantidad),
                    new SPParameter("ID_Cliente", cliente.ID),
                    new SPParameter("Fecha_Actual", ConfiguracionDeVariables.FechaSistema)
                };

            var sp = new StoreProcedure(DBQueries.Canje.SPGenerarCanje, param);

            return sp.ExecuteNonQuery(null);
        }
    }
}
