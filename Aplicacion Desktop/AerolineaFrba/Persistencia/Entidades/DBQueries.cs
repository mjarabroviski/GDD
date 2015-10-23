using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Entidades
{
    public static class DBQueries
    {
        public static class Rol
        {
            public static String SPGetRoles = "EL_PUNTERO.GetRoles";
            public static String SPGetRolPorNombre = "EL_PUNTERO.GetRolPorNombre";
            public static String SPGetRolPorNombreComo = "EL_PUNTERO.GetRolPorNombreComo";
        }

        public static class Funcionalidad
        {
            public static String SPGetFuncionalidades = "EL_PUNTERO.GetFuncionalidades";
            public static String SPGetFuncionalidadesPorRol = "EL_PUNTERO.GetAFuncionalidadesPorRol";
        }

        public static class Usuario { 
            public static String SPGetUsuarios = "EL_PUNTERO.GetUsuarios";
            public static String SPGetUsuarioPorUsername = "EL_PUNTERO.GetUsuarioPorUsername";
            public static String SPGetRolPorUsuario = "EL_PUNTERO.GetRolPorUsuario";
            public static String SPInhabilitarUsuario = "EL_PUNTERO.InhabilitarUsuario";
            public static String SPUpdateUsuario = "EL_PUNTERO.UpdateUsuario";
            public static String SPLimpiarIntentos = "EL_PUNTERO.LimpiarIntentos";
        }
    }
}
