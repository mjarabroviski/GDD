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
            var param = new List<SPParameter> { new SPParameter("ID_User", usuario.ID) };
            var sp = new StoreProcedure(DBQueries.Usuario.SPGetRolPorUsuario, param);

            //Retorno una lista de Roles a partir de un ExecuteReader
            List<Rol> roles = sp.ExecuteReader<Rol>();

            if (roles == null || roles.Count == 0)
                return null;

            //Se llena el rol con sus funcionalidades
            Rol rolARetornar = roles[0].AgregarFuncionalidades();
            return rolARetornar;
        }

        public static Rol ObtenerRolPorNombre(String nombre)
        {
            //Obtengo el nombre del rol
            var param = new List<SPParameter> { new SPParameter("Descripcion",nombre) };
            var sp = new StoreProcedure(DBQueries.Rol.SPGetRolPorNombre, param);

            //Retorno una lista de Roles a partir de un ExecuteReader
            List<Rol> roles = sp.ExecuteReader<Rol>();

            if (roles == null || roles.Count == 0)
                return null;

            //Se llena el rol con sus funcionalidades
            Rol rolARetornar = roles[0].AgregarFuncionalidades();
            return rolARetornar;
        }

        public static List<Rol> ObtenerRolPorNombreComo(String nombre)
        {
            //Obtengo el nombre del rol
            var param = new List<SPParameter> { new SPParameter("Descripcion", nombre) };
            var sp = new StoreProcedure(DBQueries.Rol.SPGetRolPorNombreComo, param);

            //Retorno una lista de Roles a partir de un ExecuteReader
            var roles = sp.ExecuteReader<Rol>();

            if (roles == null || roles.Count == 0)
                return null;

            //Se llena el rol con sus funcionalidades
            List<Rol> rolesARetornar; 
            roles.ForEach(delegate(Rol r)
            {
                r.AgregarFuncionalidades();
            });
            rolesARetornar = roles;
            return rolesARetornar;
        }

        
    }
}
