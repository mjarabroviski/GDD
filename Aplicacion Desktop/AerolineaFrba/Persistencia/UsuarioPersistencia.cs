using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Entidades;
using Herramientas;

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
            var param = new List<SPParameter> { new SPParameter("Username", userName) };
            var sp = new StoreProcedure(DBQueries.Usuario.SPGetUsuarioPorUsername, param);

            var users = sp.ExecuteReader<Usuario>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static void InhabilitarUser(Usuario user)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Usuario", user.ID)
                };
            var sp = new StoreProcedure(DBQueries.Usuario.SPInhabilitarUsuario, param);

            sp.ExecuteNonQuery(null);
        }

        public static Usuario Login(string userName, string password)
        {
            //Traigo el usuario cuyo nombre de usuario y contraseña coincidan con los parametros
            var usuario = UsuarioPersistencia.ObtenerPorUserName(userName);

            if (usuario == null)
                throw new Exception("El nombre de usuario ingresado no existe.");

            if (!usuario.Habilitado)
            {
                throw new Exception("No puede loguearse. El usuario se encuentra inhabilitado debido a supero el limite de intentos");
            }

            if (usuario.Contrasena != SHA256Encriptador.Encode(password))
            {
                usuario.CantIntentos -= 1;
                if (usuario.CantIntentos == 0)
                UsuarioPersistencia.InhabilitarUser(usuario);

                throw new Exception("La contraseña ingresada no es valida.");
            }

            return usuario;
        }

    }
}
