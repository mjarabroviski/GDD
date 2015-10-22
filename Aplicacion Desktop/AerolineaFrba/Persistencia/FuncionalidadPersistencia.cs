using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Persistencia.Entidades;

namespace Persistencia
{
    public static class FuncionalidadPersistencia
    {
        public static List<Funcionalidad> ObtenerPorRol(Rol rol)
        {
            //Obtengo todas las funcionalidades asociadas a determinado rol
            var param = new List<SPParameter> { new SPParameter("ID_Rol", rol.ID) };
            var sp = new StoreProcedure(DBQueries.Funcionalidad.SPGetFuncionalidadesPorRol, param);

            //Retorno una lista de Funcionalidad a partir de un ExecuteReader
            return sp.ExecuteReader<Funcionalidad>();
        }
    }
}
