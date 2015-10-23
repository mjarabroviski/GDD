using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using Herramientas;
using System.Data.SqlClient;

namespace Persistencia
{
    public static class UsuarioPersistencia
    {
        public static List<Usuario> ObtenerTodos()
        {
            //Traigo todos los usuarios almacenados en la base de datos
            var sp = new StoreProcedure(DBQueries.Usuario.SPGetUsuarios);
            return sp.ExecuteReader<Usuario>();
        }

        public static Usuario ObtenerPorUserName(string userName)
        {
            //Traigo el usuario cuyo nombre de usuario coincida con el del parametro
            var param = new List<SPParameter> { new SPParameter("User", userName) };
            var sp = new StoreProcedure(DBQueries.Usuario.SPGetUsuarioPorUsername, param);

            List<Usuario> users = sp.ExecuteReader<Usuario>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static void InhabilitarUser(Usuario user)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", user.ID)
                };
            var sp = new StoreProcedure(DBQueries.Usuario.SPInhabilitarUsuario, param);

            sp.ExecuteNonQuery(null);
        }

        public static Usuario Login(string userName)
        {
            //Traigo el usuario cuyo nombre de usuario y contraseña coincidan con los parametros
            return UsuarioPersistencia.ObtenerPorUserName(userName);
        }

        public static void ActualizarPorContrasena(Usuario user)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", user.ID),
                    new SPParameter("Cant_Intentos", user.CantIntentos),
                    new SPParameter("Habilitado", user.Habilitado)
                };
            var sp = new StoreProcedure(DBQueries.Usuario.SPActualizarUsuarioPorContraIncorrecta, param);

            sp.ExecuteNonQuery(null);
        }

        public static void LimpiarIntentos(Usuario user)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", user.ID)
                };
            var sp = new StoreProcedure(DBQueries.Usuario.SPLimpiarIntentos, param);

            sp.ExecuteNonQuery(null);
        }

        public static void InsertarUsuario(Usuario user)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Username", user.Username), 
                    new SPParameter("Password", user.Contrasena),
                    new SPParameter("ID_Rol", user.Rol.ID)
                };

            var sp = new StoreProcedure(DBQueries.Usuario.SPInsertarUsuario, param);

            sp.ExecuteNonQuery(null);
        }
    }
}
