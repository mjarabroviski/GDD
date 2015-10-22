using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Persistencia.Entidades;

namespace Persistencia
{
    public static class RolPersistencia
    {
        public static List<Rol> ObtenerTodos()
        {
            //Obtengo la lista de roles almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.Rol.SPGetRoles);
            return sp.ExecuteReader<Rol>();
        }
    }
}
