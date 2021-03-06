DROP TABLE [EL_PUNTERO].[TL_REGISTRO_MILLAS];
DROP TABLE [EL_PUNTERO].[TL_ENCOMIENDA];
DROP TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO];
DROP TABLE [EL_PUNTERO].[TL_DEVOLUCION];
DROP TABLE [EL_PUNTERO].[TL_PASAJE];
DROP TABLE [EL_PUNTERO].[TL_VIAJE];
DROP TABLE [EL_PUNTERO].[TL_COMPRA];
DROP TABLE [EL_PUNTERO].[TL_TARJETA];
DROP TABLE [EL_PUNTERO].[TL_CLIENTE];
DROP TABLE [EL_PUNTERO].[TL_USUARIO];
DROP TABLE [EL_PUNTERO].[TL_FUNCIONALIDAD_ROL];
DROP TABLE [EL_PUNTERO].[TL_FUNCIONALIDAD];
DROP TABLE [EL_PUNTERO].[TL_ROL];
DROP TABLE [EL_PUNTERO].[TL_TIPO_DOCUMENTO];
DROP TABLE [EL_PUNTERO].[TL_BUTACA];
DROP TABLE [EL_PUNTERO].[TL_RUTA];
DROP TABLE [EL_PUNTERO].[TL_CANJE];
DROP TABLE [EL_PUNTERO].[TL_TIPO_TARJETA];
DROP TABLE [EL_PUNTERO].[TL_PRODUCTO];
DROP TABLE [EL_PUNTERO].[TL_TIPO_BUTACA];
DROP TABLE [EL_PUNTERO].[TL_AERONAVE];
DROP TABLE [EL_PUNTERO].[TL_BAJA_SERVICIO_AERONAVE];
DROP TABLE [EL_PUNTERO].[TL_CIUDAD];
DROP TABLE [EL_PUNTERO].[TL_SERVICIO];

DROP PROCEDURE [EL_PUNTERO].[GetFuncionalidadesPorRol];
DROP PROCEDURE [EL_PUNTERO].[GetRoles];
DROP PROCEDURE [EL_PUNTERO].[GetUsuarios];
DROP PROCEDURE [EL_PUNTERO].[GetUsuarioPorUsername];
DROP PROCEDURE [EL_PUNTERO].[GetRolPorUsuario];
DROP PROCEDURE [EL_PUNTERO].[InhabilitarUsuario];
DROP PROCEDURE [EL_PUNTERO].[ActualizarUsuarioPorContraIncorrecta];
DROP PROCEDURE [EL_PUNTERO].[LimpiarIntentos];
DROP PROCEDURE [EL_PUNTERO].[InsertarUsuario];
DROP PROCEDURE [EL_PUNTERO].[GetRolPorNombre];
DROP PROCEDURE [EL_PUNTERO].[ActualizarContrasena];
DROP PROCEDURE [EL_PUNTERO].[GetCiudades];
DROP PROCEDURE [EL_PUNTERO].[EliminarCiudad];
DROP PROCEDURE [EL_PUNTERO].[GetCiudadesPorParametros];
DROP PROCEDURE [EL_PUNTERO].[GetCiudadesPorParametrosComo];
DROP PROCEDURE [EL_PUNTERO].[FiltrarRutas];
DROP PROCEDURE [EL_PUNTERO].[GetServicios];
DROP PROCEDURE [EL_PUNTERO].[GetAeronaves];
DROP PROCEDURE [EL_PUNTERO].[GetServicioPorID];
DROP PROCEDURE [EL_PUNTERO].[GetAeronavesPorParametros];
DROP PROCEDURE [EL_PUNTERO].ActualizarRolPorID;
DROP PROCEDURE [EL_PUNTERO].CancelarPasajesYEncomiendasConRutaInhabilitada;
DROP PROCEDURE [EL_PUNTERO].EliminarFuncionalidadesPorRol;
DROP PROCEDURE [EL_PUNTERO].GetAllRoles;
DROP PROCEDURE [EL_PUNTERO].GetAllRutas;
DROP PROCEDURE [EL_PUNTERO].GetCiudadPorID;
DROP PROCEDURE [EL_PUNTERO].GetFuncionalidades;
DROP PROCEDURE [EL_PUNTERO].GetRolPorNombreComo;
DROP PROCEDURE [EL_PUNTERO].InsertarFuncionalidadPorRol;
DROP PROCEDURE [EL_PUNTERO].InsertarRol;
DROP PROCEDURE [EL_PUNTERO].InsertarRuta;
DROP PROCEDURE [EL_PUNTERO].ObtenerIDPorNombreDeCiudad;
DROP PROCEDURE [EL_PUNTERO].ObtenerIDPorNombreDeServicio;
DROP PROCEDURE [EL_PUNTERO].ModificarRuta;
DROP PROCEDURE [EL_PUNTERO].ActualizarCiudad;
DROP PROCEDURE [EL_PUNTERO].InsertarCiudad;
DROP PROCEDURE [EL_PUNTERO].[ActualizarCiudad];
DROP PROCEDURE [EL_PUNTERO].[InsertarCiudad];
DROP PROCEDURE [EL_PUNTERO].[ObtenerIDPorNombreDeCiudad];
DROP PROCEDURE [EL_PUNTERO].[ObtenerTodasLasCiudadesConOrigen];
DROP PROCEDURE [EL_PUNTERO].[SPObtenerServiciosDeRuta];
DROP PROCEDURE [EL_PUNTERO].[GetAeronavesPorParametrosComo];
DROP PROCEDURE [EL_PUNTERO].[BajaPorVidaUtil];
DROP PROCEDURE [EL_PUNTERO].[GetAeronavePorMatricula];
DROP PROCEDURE [EL_PUNTERO].[InsertarAeronave];
DROP PROCEDURE [EL_PUNTERO].[GetIdTipoPorDescripcion];
DROP PROCEDURE [EL_PUNTERO].[InsertarButaca];
DROP PROCEDURE [EL_PUNTERO].[ObtenerIDPorNombreDeServicio];
DROP PROCEDURE [EL_PUNTERO].[EliminarAeronave];
DROP PROCEDURE [EL_PUNTERO].[ObtenerButacasDisponibles];
DROP PROCEDURE [EL_PUNTERO].[GetViajesFuturosPorAeronave];
DROP PROCEDURE [EL_PUNTERO].[GetViajesPorAeronave];
DROP PROCEDURE [EL_PUNTERO].[ObtenerKGSDisponibles];
DROP PROCEDURE [EL_PUNTERO].[ModificarAeronave];
DROP PROCEDURE [EL_PUNTERO].[GetTipoButacaPorButaca];
DROP PROCEDURE [EL_PUNTERO].[GetButacasDeAeronave];
DROP PROCEDURE [EL_PUNTERO].[GetCantButacasPorAeronave];
DROP PROCEDURE [EL_PUNTERO].[InsertarIDDevolucion];
DROP PROCEDURE [EL_PUNTERO].[SeleccionReemplazoAeronave];
DROP PROCEDURE [EL_PUNTERO].[TraerLosPasajesDevueltos];
DROP PROCEDURE [EL_PUNTERO].[GetTiposButacas];
DROP PROCEDURE [EL_PUNTERO].[GetTipoPorDescripcion];
DROP PROCEDURE [EL_PUNTERO].[ModificarButaca];
DROP PROCEDURE [EL_PUNTERO].[DarDeBajaButaca];
DROP PROCEDURE [EL_PUNTERO].[GetMaxNroButaca];
DROP PROCEDURE [EL_PUNTERO].[DarDeBajaPorVidaUtil];
DROP PROCEDURE [EL_PUNTERO].[ReemplazoAeronave];
DROP PROCEDURE [EL_PUNTERO].[ObtenerButacasDisponibles];
DROP PROCEDURE [EL_PUNTERO].[ObtenerKGSDisponibles];
DROP PROCEDURE [EL_PUNTERO].[CancelarPasajesYEncomiendasPorBajaAeronave];
DROP PROCEDURE [EL_PUNTERO].[DarDeBajaPorFueraDeServicio];
DROP PROCEDURE [EL_PUNTERO].[BajaPorFueraDeServicio];
DROP PROCEDURE [EL_PUNTERO].[CancelarPasajesYEncomiendasPorBajaServicioAeronave];
DROP PROCEDURE [EL_PUNTERO].[ReemplazoAeronavePorServicio];
DROP FUNCTION [EL_PUNTERO].[ObtenerAeronaveDeReemplazoPorServicio];
DROP PROCEDURE [EL_PUNTERO].[SeleccionReemplazoAeronavePorServicio];
DROP PROCEDURE [EL_PUNTERO].[HabilitarAeronavesQueVolvieronDeBajaServicio];
DROP PROCEDURE [EL_PUNTERO].[GetFuncionalidadPorNombre];
DROP PROCEDURE [EL_PUNTERO].[ActualizarRolPorID];
DROP PROCEDURE [EL_PUNTERO].[EliminarFuncionalidadesPorRol];
DROP PROCEDURE [EL_PUNTERO].[GetAllRoles];
DROP PROCEDURE [EL_PUNTERO].[GetAllRutas];
DROP PROCEDURE [EL_PUNTERO].[GetCiudadPorID];
DROP PROCEDURE [EL_PUNTERO].[GetFuncionalidades];
DROP PROCEDURE [EL_PUNTERO].[GetRolPorNombreComo];
DROP PROCEDURE [EL_PUNTERO].[InsertarFuncionalidadPorRol];
DROP PROCEDURE [EL_PUNTERO].[InsertarRol];
DROP PROCEDURE [EL_PUNTERO].[InsertarRuta];
DROP PROCEDURE [EL_PUNTERO].[ObtenerTodasLasRutasConOrigen];
DROP PROCEDURE [EL_PUNTERO].[InsertarCiudad];
DROP PROCEDURE [EL_PUNTERO].[ActualizarCiudad];
DROP PROCEDURE [EL_PUNTERO].[ObtenerTodasLasCiudadesConOrigen];
DROP PROCEDURE [EL_PUNTERO].[GetCiudades];
DROP PROCEDURE [EL_PUNTERO].[ObtenerCiudadPorId_Ciudad];
DROP PROCEDURE [EL_PUNTERO].[ObtenerAeronavesHabilitadas];
DROP PROCEDURE [EL_PUNTERO].[ObtenerServiciosDeRuta];
DROP PROCEDURE [EL_PUNTERO].[ObtenerRutaPorOrigenYDestino];
DROP PROCEDURE [EL_PUNTERO].[GetAeronavePorMatricula];
DROP PROCEDURE [EL_PUNTERO].[ObtenerIDPorNombreDeCiudad];
DROP PROCEDURE [EL_PUNTERO].[GenerarViaje];
DROP PROCEDURE [EL_PUNTERO].[HabilitarAeronavesQueVolvieronDeBaja];
DROP PROCEDURE [EL_PUNTERO].[ValidarHorarioDeAeronave];
DROP PROCEDURE [EL_PUNTERO].[GetAeronaves]
DROP PROCEDURE [EL_PUNTERO].[CiudadDestinoPorIDRuta];
DROP PROCEDURE [EL_PUNTERO].[CiudadOrigenPorIDRuta];
DROP PROCEDURE [EL_PUNTERO].[FiltrarViajes];
DROP PROCEDURE [EL_PUNTERO].[ValidarAeronaveDelViaje];
DROP PROCEDURE [EL_PUNTERO].[GetServicioPorID];
DROP PROCEDURE [EL_PUNTERO].[ObtenerViaje];
DROP PROCEDURE [EL_PUNTERO].[ActualizarFechaLlegada];
DROP PROCEDURE [EL_PUNTERO].[GetFuncionalidadesPorNombreRol];
DROP PROCEDURE [EL_PUNTERO].[GetClientePorTipoYDocumento];
DROP PROCEDURE [EL_PUNTERO].[GetAllTipoDocumento];

DROP TRIGGER [EL_PUNTERO].[Tr_DeshabilitarUsuariosConRolDeshabilitado];

DROP FUNCTION [EL_PUNTERO].[CompraAPartirDeEncomienda];
DROP FUNCTION [EL_PUNTERO].[CompraAPartirDePasaje];
DROP FUNCTION [EL_PUNTERO].[DevolucionAPartirDePasaje];
DROP FUNCTION [EL_PUNTERO].[ObtenerAeronaveDeReemplazo];
DROP FUNCTION [EL_PUNTERO].[ObtenerIDBajaServicioMax];

DROP SCHEMA [EL_PUNTERO];