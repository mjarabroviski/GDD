using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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
            var sp = new StoreProcedure(DBQueries.Rol.SPGetAllRoles);
            return sp.ExecuteReader<Rol>();
        }

        public static List<Rol> ObtenerTodosHabilitados()
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

        public static void InsertarRolYFucionalidades(Rol rol)
        {
            /* 
             * Lo tengo que hacer transaccionado ya que no quiero que pueda llegar a quedar un rol insertado
             * sin las funcionalidades asociadas debido a un error
             */
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    rol = Insertar(rol, transaccion);
                    FuncionalidadPersistencia.InsertarPorRol(rol, transaccion);

                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error durante la insercion del rol");
                }
            }
        }

        private static Rol Insertar(Rol rol, SqlTransaction transaccion)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Descripcion", rol.Descripcion), 
                    new SPParameter("Habilitado", rol.Habilitado)
                };

            var sp = (transaccion != null)
                        ? new StoreProcedure(DBQueries.Rol.SPInsertarRol, param, transaccion)
                        : new StoreProcedure(DBQueries.Rol.SPInsertarRol, param);

            rol.ID = (int)sp.ExecuteScalar(transaccion);

            return rol;
        }

        public static void ModificarRolYFuncionalidades(Rol rol)
        {
            /* 
             * Lo tengo que hacer transaccionado ya que no quiero que pueda llegar a quedar un rol insertado
             * sin las funcionalidades asociadas debido a un error 
             */
            using (var transaccion = DBManager.Instance().Connection.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    Actualizar(rol, transaccion);

                    if (FuncionalidadPersistencia.EliminarPorRol(rol, transaccion) > 0)
                        if (FuncionalidadPersistencia.InsertarPorRol(rol, transaccion) > 0)
                        {
                            //La unica forma que se realice la transaction: borro todas las funcionalidades viejas e inserto las nuevas
                            transaccion.Commit();
                        }
                        else
                            //Tuvo que haber insertado por lo menos una, sino es un error
                            transaccion.Rollback();
                    else
                        //Tuvo que haber insertado por lo menos una, sino es un error
                        transaccion.Rollback();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                    throw new Exception("Se produjo un error durante la modificacion del rol");
                }
            }
        }

        public static int Actualizar(Rol rol, SqlTransaction transaccion)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Rol", rol.ID),
                    new SPParameter("Descripcion", rol.Descripcion),
                    new SPParameter("Habilitado", rol.Habilitado)
                };

            var sp = (transaccion != null)
                        ? new StoreProcedure(DBQueries.Rol.SPActualizarRolPorID, param, transaccion)
                        : new StoreProcedure(DBQueries.Rol.SPActualizarRolPorID, param);

            return sp.ExecuteNonQuery(transaccion);
        }


    }
}
