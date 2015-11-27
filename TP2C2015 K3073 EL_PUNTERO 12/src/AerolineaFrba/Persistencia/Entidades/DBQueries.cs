using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Entidades
{
    public static class DBQueries
    {
        public static class Compra
        {
            public static String SPCrearTablaAuxiliarPasajeros = "EL_PUNTERO.CrearTablaAuxiliarPasajeros";
            public static String SPBorrarTablaAuxiliarPasajeros = "EL_PUNTERO.BorrarTablaAuxiliarPasajeros";
            public static String SPCargarTablaAuxiliarPasajeros = "EL_PUNTERO.CargarTablaAuxiliarPasajeros";
            public static String SPObtenerClientePorDoc = "EL_PUNTERO.ObtenerClientePorDoc";
        }

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
            public static String SPGetRolPorID = "EL_PUNTERO.GetRolPorID";
        }

        public static class Servicio
        {
            public static String SPGetServicios = "EL_PUNTERO.GetServicios";
            public static String SPObtenerIDPorNombreDeServicio = "EL_PUNTERO.ObtenerIDPorNombreDeServicio";
            public static String SPGetServicioPorID = "EL_PUNTERO.GetServicioPorID";
            public static String SPObtenerServiciosDeRuta = "EL_PUNTERO.ObtenerServiciosDeRuta";
            public static String SPObtenerServicioPorNombre = "EL_PUNTERO.ObtenerIDPorNombreDeServicio";
            public static String SPObtenerServiciosPorIDRuta = "EL_PUNTERO.GetServiciosPorIDRuta";
            public static String SPObtenerServiciosPorRuta = "EL_PUNTERO.ObtenerServiciosPorRuta";
            public static String SPObtenerServicioAeronave = "EL_PUNTERO.ObtenerServicioAeronave";
        }

        public static class Funcionalidad
        {
            public static String SPGetFuncionalidades = "EL_PUNTERO.GetFuncionalidades";
            public static String SPGetFuncionalidadesPorRol = "EL_PUNTERO.GetFuncionalidadesPorRol";
            public static String SPGetFuncionalidadPorNombre = "EL_PUNTERO.GetFuncionalidadPorNombre";
            public static String SPGetFuncionalidadesPorNombreRol = "EL_PUNTERO.GetFuncionalidadesPorNombreRol";
            public static String SPGetFuncionalidadesPorUsuario = "EL_PUNTERO.GetFuncionalidadesPorUsuario";
        }

        public static class Ruta
        {
            public static String SPGetAllRutas = "EL_PUNTERO.GetAllRutas"; 
            public static String SPGetServicioPorID = "EL_PUNTERO.GetServicioPorID"; 
            public static String SPGetCiudadPorID = "EL_PUNTERO.GetCiudadPorID";
            public static String SPFiltrarRutas = "EL_PUNTERO.FiltrarRutas";
            public static String SPInsertarRuta = "EL_PUNTERO.InsertarRuta";
            public static String SPModificarRuta = "EL_PUNTERO.ModificarRuta";
            public static String SPCancelarPasajesYEncomiendasConRutaInhabilitada = "EL_PUNTERO.CancelarPasajesYEncomiendasConRutaInhabilitada";
            public static String SPObtenerTodasLasCiudadesConOrigen = "EL_PUNTERO.ObtenerTodasLasCiudadesConOrigen";
            public static String SPObtenerRutaPorOrigenYDestino = "EL_PUNTERO.ObtenerRutaPorOrigenYDestino";
            public static String SPServiciosPorIDRuta = "EL_PUNTERO.GetServiciosPorIDRuta";
            public static String SPEliminarServiciosPorRuta = "EL_PUNTERO.EliminarServiciosPorRuta";
            public static String SPInsertarServiciosPorRuta = "EL_PUNTERO.InsertarServiciosPorRuta";
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
            public static String SPGetUsuarioPorUsernameYRol = "EL_PUNTERO.GetUsuarioPorUsernameYRol";
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
            public static String SPObtenerCiudadesOrigenParaUnServicio = "EL_PUNTERO.ObtenerCiudadesOrigenParaUnServicio";
        }

        public static class Aeronave
        {
            public static String SPGetAeronaves = "EL_PUNTERO.GetAeronaves";
            public static String SPGetAeronavesPorParametros = "EL_PUNTERO.GetAeronavesPorParametros";
            public static String SPGetAeronavesPorParametrosComo = "EL_PUNTERO.GetAeronavesPorParametrosComo";
            public static String SPObtenerAeronavesHabilitadas = "EL_PUNTERO.ObtenerAeronavesHabilitadas";
            public static String SPBajaPorVidaUtil = "EL_PUNTERO.BajaPorVidaUtil";
            public static String SPSeleccionReemplazo = "EL_PUNTERO.SeleccionReemplazoAeronave";
            public static String SPGetAeronavePorMatricula = "EL_PUNTERO.GetAeronavePorMatricula";
            public static String SPInsertarAeronave = "EL_PUNTERO.InsertarAeronave";
            public static String SPEliminarAeronave = "EL_PUNTERO.EliminarAeronave";
            public static String SPModificarAeronave = "EL_PUNTERO.ModificarAeronave";
            public static String SPDarDeBajaPorVidaUtil = "EL_PUNTERO.DarDeBajaPorVidaUtil";
            public static String SPReemplazo = "EL_PUNTERO.ReemplazoAeronave";
            public static String SPDarDeBajaPorFueraDeServicio = "EL_PUNTERO.DarDeBajaPorFueraDeServicio";
            public static String SPBajaPorFueraDeServicio = "EL_PUNTERO.BajaPorFueraDeServicio";
            public static String SPSeleccionReemplazoPorServicio = "EL_PUNTERO.SeleccionReemplazoAeronavePorServicio";
            public static String SPReemplazoPorServicio = "EL_PUNTERO.ReemplazoAeronavePorServicio";
        }

        public static class Butaca
        {
            public static String SPGetIdTipoPorDescripcion = "EL_PUNTERO.GetIdTipoPorDescripcion";
            public static String SPInsertarButaca = "EL_PUNTERO.InsertarButaca";
            public static String SPGetButacasDeAeronave = "EL_PUNTERO.GetButacasDeAeronave";
            public static String SPModificarButaca = "EL_PUNTERO.ModificarButaca";
            public static String SPDarDeBajaButaca = "EL_PUNTERO.DarDeBajaButaca";
            public static String SPGetMaxNroButaca = "EL_PUNTERO.GetMaxNroButaca";
            public static String SPGetCantButacasPorAeronave = "EL_PUNTERO.GetCantButacasPorAeronave";
            public static String SPObtenerInfoButacasDisponibles = "EL_PUNTERO.ObtenerInfoButacasDisponibles";
        }

        public static class Viaje
        {
            public static String SPGenerarViaje = "EL_PUNTERO.GenerarViaje";
            public static String SPFiltrarViajes = "EL_PUNTERO.FiltrarViajes";
            public static String SPCiudadOrigenPorIDRuta = "EL_PUNTERO.CiudadOrigenPorIDRuta";
            public static String SPCiudadDestinoPorIDRuta = "EL_PUNTERO.CiudadDestinoPorIDRuta";
            public static String SPObtenerButacasDisponibles = "EL_PUNTERO.ObtenerButacasDisponibles";
            public static String SPObtenerKGSDisponibles = "EL_PUNTERO.ObtenerKGSDisponibles";
            public static String SPGetViajesPorAeronave = "EL_PUNTERO.GetViajesPorAeronave";
            public static String SPValidarHorarioDeAeronave = "EL_PUNTERO.ValidarHorarioDeAeronave";
            public static String SPValidarAeronaveDelViaje = "EL_PUNTERO.ValidarAeronaveDelViaje";
            public static string SPObtenerViajes = "EL_PUNTERO.ObtenerViajes";
            public static String SPObtenerViaje = "EL_PUNTERO.ObtenerViaje";
            public static String SPActualizarFechaLlegada = "EL_PUNTERO.ActualizarFechaLlegada";
        }

        public static class TipoButaca
        {
            public static String SPGetTipoButacaPorButaca = "EL_PUNTERO.GetTipoButacaPorButaca";
            public static String SPGetTiposButacas = "EL_PUNTERO.GetTiposButacas";
            public static String SPGetTipoPorDescripcion = "EL_PUNTERO.GetTipoPorDescripcion";
        }

        public static class Devolucion
        {
            public static String SPCancelarPasajesYEncomiendasPorBajaAeronave = "EL_PUNTERO.CancelarPasajesYEncomiendasPorBajaAeronave";
            public static String SPCancelarPasajesYEncomiendasPorBajaServicioAeronave = "EL_PUNTERO.CancelarPasajesYEncomiendasPorBajaServicioAeronave";
            public static String SPInsertarDevolucionEncomienda = "EL_PUNTERO.InsertarDevolucionEncomienda";
            public static String SPInsertarDevolucionPasaje = "EL_PUNTERO.InsertarDevolucionPasaje";
            public static String SPDevolverTodasLasEncomiendas = "EL_PUNTERO.DevolverTodasLasEncomiendas";
            public static String SPDevolverTodosLosPasajes = "EL_PUNTERO.DevolverTodosLosPasajes";
            
        }

        public static class Cliente
        {
            public static String SPGetClientePorTipoYDocumento = "EL_PUNTERO.GetClientePorTipoYDocumento";
            public static String SPGetClientePorTipoYDocumentoYFechaNac = "EL_PUNTERO.GetClientePorTipoYDocumentoYFechaNac";
            public static String SPObtenerNombreClientePorID = "ObtenerNombreClientePorID";
            public static String SPGetClientesAuxiliares = "EL_PUNTERO.GetClientesAuxiliares";
            public static String SPGetClientePorID = "EL_PUNTERO.GetClientePorID";
            public static String SPGetClientePorNombreYApellido = "EL_PUNTERO.GetClientePorNombreYApellido";

        }

        public static class TipoDocumento {

            public static String SPGetAllTipoDocumento = "EL_PUNTERO.GetAllTipoDocumento";
            public static string SPObtenerTipoDocumentoPorID = "EL_PUNTERO.ObtenerTipoDocumentoPorID";
        }

        public static class RegistroMillas
        {
            public static String SPActualizarMillas = "EL_PUNTERO.AgregarRegistroMillas";
            public static String SPGetAllRegistrosMillas = "EL_PUNTERO.GetAllRegistrosMillas";
            public static String SPObtenerRegistrosPorIDCliente = "EL_PUNTERO.GetRegistrosPorIDCliente";
        }

        public static class Canje
        {
            public static String SPObtenerCanjePorIDCliente = "EL_PUNTERO.GetCanjePorIDCliente";
            public static String SPGenerarCanje = "EL_PUNTERO.GenerarCanje";
        }

        public static class Encomienda
        { 
            public static String SPObtenerEncomiendasFuturas = "EL_PUNTERO.ObtenerEncomiendasFuturas";
            public static String SPObtenerRutaDeEncomienda = "EL_PUNTERO.ObtenerRutaDeEncomienda";
            public static String SPObtenerFechaSalidaDeEncomienda = "EL_PUNTERO.ObtenerFechaSalidaDeEncomienda";
        }

        public static class Pasaje
        {
            public static String SPObtenerPasajesFuturos = "EL_PUNTERO.ObtenerPasajesFuturos";
            public static String SPObtenerRutaDePasaje = "EL_PUNTERO.ObtenerRutaDePasaje";
            public static String SPObtenerFechaSalidaDePasaje = "EL_PUNTERO.ObtenerFechaSalidaDePasaje";
        }

        public static class Producto
        {
            public static String SPGetProductos = "EL_PUNTERO.GetProductos";
            public static String SPObtenerProductosParaUnCliente = "EL_PUNTERO.GetProductosParaUnCliente";
            public static String SPGetMinimoDeProducto = "EL_PUNTERO.GetProductoMinimo";
            public static String SPObtenerProductoPorID = "EL_PUNTERO.GetProductoPorID";
        }

        public static class Estadistica
        {
            public static String SPGetDestinosConMasPasajesComprados = "EL_PUNTERO.GetDestinosConMasPasajesComprados";
            public static String SPGetDestinosConMasAeronavesVacias = "EL_PUNTERO.GetDestinosConMasAeronavesVacias";
            public static String SPGetClientesConMasPuntosAcumulados = "EL_PUNTERO.GetClientesConMasPuntosAcumulados";
            public static String SPGetDestinosConMasPasajesCancelados = "EL_PUNTERO.GetDestinosConMasPasajesCancelados";
            public static String SPGetAeronavesConMayorCantDeDiasFueraDeServicio = "EL_PUNTERO.GetAeronavesConMayorCantDeDiasFueraDeServicio";
        }

    }
}
