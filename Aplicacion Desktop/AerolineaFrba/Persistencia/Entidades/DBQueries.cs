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
            public static String SPInsertarFuncionalidadPorRol = "EL_PUNTERO.InsertarFuncionalidadPorRol";
            public static String SPEliminarFuncionalidadesPorRol = "EL_PUNTERO.EliminarFuncionalidadesPorRol";
            public static String SPInsertarRol = "EL_PUNTERO.InsertarRol";
            public static String SPActualizarRolPorID = "EL_PUNTERO.ActualizarRolPorID";
        }

        public static class Funcionalidad
        {
            public static String SPGetFuncionalidades = "EL_PUNTERO.GetFuncionalidades";
            public static String SPGetFuncionalidadesPorRol = "EL_PUNTERO.GetFuncionalidadesPorRol";
        }

        public static class Usuario { 
            public static String SPGetUsuarios = "EL_PUNTERO.GetUsuarios";
            public static String SPGetUsuarioPorUsername = "EL_PUNTERO.GetUsuarioPorUsername";
            public static String SPGetRolPorUsuario = "EL_PUNTERO.GetRolPorUsuario";
            public static String SPInhabilitarUsuario = "EL_PUNTERO.InhabilitarUsuario";
            public static String SPActualizarUsuarioPorContraIncorrecta = "EL_PUNTERO.ActualizarUsuarioPorContraIncorrecta";
            public static String SPLimpiarIntentos = "EL_PUNTERO.LimpiarIntentos";
            public static String SPInsertarUsuario = "EL_PUNTERO.InsertarUsuario";
            public static String SPActualizarContrasena = "EL_PUNTERO.ActualizarContrasena";
        }

        public static class Ciudad
        {
            public static String SPGetCiudades = "EL_PUNTERO.GetCiudades";
            public static String SPEliminarCiudad = "EL_PUNTERO.EliminarCiudad";
            public static String SPObtenerCiudadesPorParametros = "EL_PUNTERO.GetCiudadesPorParametros";
            public static String SPObtenerCiudadesPorParametrosComo = "EL_PUNTERO.GetCiudadesPorParametrosComo";
        }
    }
}
