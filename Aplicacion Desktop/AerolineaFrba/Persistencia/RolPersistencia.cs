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

        public static Rol ObtenerRolPorUsuario(Usuario usuario) {
            //Obtengo el rol del usuario
            var param = new List<SPParameter> { new SPParameter("ID_Usuario", usuario.ID) };
            var sp = new StoreProcedure(DBQueries.Usuario.SPGetRolPorUsuario, param);

            //Retorno una lista de Roles a partir de un ExecuteReader
            var roles = sp.ExecuteReader<Rol>();

            if (roles == null || roles.Count == 0)
                return null;

            //Se llena el ron con sus funcionalidades
            Rol rolARetornar = roles[0].AgregarFuncionalidades();
            return rolARetornar;
        }
    }
}
