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

        public static int InsertarPorRol(Rol rol, SqlTransaction transaccion)
        {
            var regsAfectados = 0;

            foreach (var feature in rol.Funcionalidades)
            {
                var param = new List<SPParameter> { new SPParameter("ID_Funcionalidad", feature.ID), new SPParameter("ID_Rol", rol.ID) };
                var sp = (transaccion != null)
                            ? new StoreProcedure(DBQueries.Rol.SPInsertarFuncionalidadPorRol, param,transaccion)
                            : new StoreProcedure(DBQueries.Rol.SPInsertarFuncionalidadPorRol, param);

                regsAfectados += sp.ExecuteNonQuery(transaccion);
            }

            //Retorno la cantidad de funcionalidades insertadas a partir de un ExecuteNonQuery
            return regsAfectados;
        }


        public static int EliminarPorRol(Rol rol, SqlTransaction transaccion)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Rol", rol.ID) };
            var sp = (transaccion != null)
                ?new StoreProcedure(DBQueries.Rol.SPEliminarFuncionalidadesPorRol, param,transaccion)
                            : new StoreProcedure(DBQueries.Rol.SPEliminarFuncionalidadesPorRol, param);

            //Retorno la cantidad de funcionalidades eliminadas a partir de un ExecuteNonQuery
            return sp.ExecuteNonQuery(transaccion);
        }

        public static object ObtenerTodas()
        {
            //Obtengo todas las funcionalidades almacenadas en la base de datos
            var sp = new StoreProcedure(DBQueries.Funcionalidad.SPGetFuncionalidades);

            //Retorno una lista de Funcionalidad a partir de un ExecuteReader
            return sp.ExecuteReader<Funcionalidad>();
        }

        public static Funcionalidad ObtenerPorNombre(String nombre)
        {
            var param = new List<SPParameter> { new SPParameter("Descripcion", nombre) };
            var sp = new StoreProcedure(DBQueries.Funcionalidad.SPGetFuncionalidadPorNombre, param);

            List<Funcionalidad> func = sp.ExecuteReader<Funcionalidad>();

            if (func == null || func.Count == 0)
                return null;

            return func[0];
        }

        public static List<Funcionalidad> ObtenerFuncionalidadesPorNombreRol(String nombre)
        {
            var param = new List<SPParameter> { new SPParameter("Nombre_Rol", nombre) };
            var sp = new StoreProcedure(DBQueries.Funcionalidad.SPGetFuncionalidadesPorNombreRol, param);

            List<Funcionalidad> func = sp.ExecuteReader<Funcionalidad>();

            if (func == null || func.Count == 0)
                return null;

            return func;
        }

        public static List<Funcionalidad> ObtenerFuncionalidadesPorUsuario(Usuario user)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Usuario", user.ID) };
            var sp = new StoreProcedure(DBQueries.Funcionalidad.SPGetFuncionalidadesPorUsuario, param);

            List<Funcionalidad> func = sp.ExecuteReader<Funcionalidad>();

            if (func == null || func.Count == 0)
                return null;

            return func;
        }
    }
}
