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
            public static String SPGetAllRoles = "EL_PUNTERO.GetAllRoles";
            public static String SPGetRolPorNombre = "EL_PUNTERO.GetRolPorNombre";
            public static String SPGetRolPorNombreComo = "EL_PUNTERO.GetRolPorNombreComo";
            public static String SPInsertarFuncionalidadPorRol = "EL_PUNTERO.InsertarFuncionalidadPorRol";
            public static String SPEliminarFuncionalidadesPorRol = "EL_PUNTERO.EliminarFuncionalidadesPorRol";
            public static String SPInsertarRol = "EL_PUNTERO.InsertarRol";
            public static String SPActualizarRolPorID = "EL_PUNTERO.ActualizarRolPorID";
            
        }

        public static class Servicio
        {
            public static String SPGetServicios = "EL_PUNTERO.GetServicios";
            public static String SPObtenerIDPorNombreDeServicio = "EL_PUNTERO.ObtenerIDPorNombreDeServicio";
            public static String SPGetServicioPorID = "EL_PUNTERO.GetServicioPorID";
            public static String SPObtenerServiciosDeRuta = "EL_PUNTERO.ObtenerServiciosDeRuta";
        }

        public static class Funcionalidad
        {
            public static String SPGetFuncionalidades = "EL_PUNTERO.GetFuncionalidades";
            public static String SPGetFuncionalidadesPorRol = "EL_PUNTERO.GetFuncionalidadesPorRol";
        }

        public static class Ruta
        {
            public static String SPGetAllRutas = "EL_PUNTERO.GetAllRutas"; 
            public static String SPGetServicioPorID = "EL_PUNTERO.GetServicioPorID"; 
            public static String SPGetCiudadPorID = "EL_PUNTERO.GetCiudadPorID";
            public static String SPFiltrarRutas = "EL_PUNTERO.FiltrarRutas";
            public static String SPInsertarRuta = "EL_PUNTERO.InsertarRuta";
            public static String SPObtenerTodasLasCiudadesConOrigen = "EL_PUNTERO.ObtenerTodasLasCiudadesConOrigen";
            public static String SPObtenerRutaPorOrigenYDestino = "EL_PUNTERO.ObtenerRutaPorOrigenYDestino";
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
            public static String SPInsertarCiudad = "EL_PUNTERO.InsertarCiudad";
            public static String SPActualizarCiudad = "EL_PUNTERO.ActualizarCiudad";
            public static String SPObtenerIDPorNombreDeCiudad = "EL_PUNTERO.ObtenerIDPorNombreDeCiudad";
            public static String SPObtenerCiudadPorId_Ciudad = "EL_PUNTERO.ObtenerCiudadPorId_Ciudad";
        }

        public static class Aeronave
        {
            public static String SPGetAeronaves = "EL_PUNTERO.GetAeronaves";
            public static String SPGetAeronavesPorParametros = "EL_PUNTERO.GetAeronavesPorParametros";
            public static String SPGetAeronavesPorParametrosComo = "EL_PUNTERO.GetAeronavesPorParametrosComo";
            public static String SPObtenerAeronavesHabilitadas = "EL_PUNTERO.ObtenerAeronavesHabilitadas";
        }
    }
}
