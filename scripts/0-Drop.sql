DROP TABLE [EL_PUNTERO].[TL_REGISTRO_MILLAS];
DROP TABLE [EL_PUNTERO].[TL_ENCOMIENDA];
DROP TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO];
DROP TABLE [EL_PUNTERO].[TL_DEVOLUCION_ENCOMIENDA];
DROP TABLE [EL_PUNTERO].[TL_DEVOLUCION_PASAJE];
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
DROP TABLE [EL_PUNTERO].[TL_ROL_USUARIO];
DROP TABLE [EL_PUNTERO].[TL_SERVICIO_RUTA];

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
DROP PROCEDURE [EL_PUNTERO].[GetAeronavesPorParametros];
DROP PROCEDURE [EL_PUNTERO].CancelarPasajesYEncomiendasConRutaInhabilitada;
DROP PROCEDURE [EL_PUNTERO].[GetRolPorID];
DROP PROCEDURE [EL_PUNTERO].InsertarFuncionalidadPorRol;
DROP PROCEDURE [EL_PUNTERO].[ModificarRuta];
DROP PROCEDURE [EL_PUNTERO].[GetFuncionalidadesPorRol];
DROP PROCEDURE [EL_PUNTERO].[ObtenerServiciosDeRuta];
DROP PROCEDURE [EL_PUNTERO].[GetAeronavesPorParametrosComo];
DROP PROCEDURE [EL_PUNTERO].[BajaPorVidaUtil];
DROP PROCEDURE [EL_PUNTERO].[GetAeronavePorMatricula];
DROP PROCEDURE [EL_PUNTERO].[InsertarAeronave];
DROP PROCEDURE [EL_PUNTERO].[GetIdTipoPorDescripcion];
DROP PROCEDURE [EL_PUNTERO].[InsertarButaca];
DROP PROCEDURE [EL_PUNTERO].[ObtenerIDPorNombreDeServicio];
DROP PROCEDURE [EL_PUNTERO].[EliminarAeronave];
DROP PROCEDURE [EL_PUNTERO].[ObtenerButacasDisponibles];
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
DROP PROCEDURE [EL_PUNTERO].[CancelarPasajesYEncomiendasPorBajaAeronave];
DROP PROCEDURE [EL_PUNTERO].[DarDeBajaPorFueraDeServicio];
DROP PROCEDURE [EL_PUNTERO].[BajaPorFueraDeServicio];
DROP PROCEDURE [EL_PUNTERO].[CancelarPasajesYEncomiendasPorBajaServicioAeronave];
DROP PROCEDURE [EL_PUNTERO].[ReemplazoAeronavePorServicio];
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
DROP PROCEDURE [EL_PUNTERO].[InsertarCiudad];
DROP PROCEDURE [EL_PUNTERO].[ActualizarCiudad];
DROP PROCEDURE [EL_PUNTERO].[ObtenerTodasLasCiudadesConOrigen];
DROP PROCEDURE [EL_PUNTERO].[ObtenerCiudadPorId_Ciudad];
DROP PROCEDURE [EL_PUNTERO].[ObtenerAeronavesHabilitadas];
DROP PROCEDURE [EL_PUNTERO].[ObtenerRutaPorOrigenYDestino];
DROP PROCEDURE [EL_PUNTERO].[ObtenerIDPorNombreDeCiudad];
DROP PROCEDURE [EL_PUNTERO].[GenerarViaje];
DROP PROCEDURE [EL_PUNTERO].[ValidarHorarioDeAeronave];
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
DROP PROCEDURE [EL_PUNTERO].[GetClientePorTipoYDocumentoYFechaNac];
DROP PROCEDURE [EL_PUNTERO].[AgregarRegistroMillas];
DROP PROCEDURE [EL_PUNTERO].[ObtenerViajes];
DROP PROCEDURE [EL_PUNTERO].[ServicioPorIDRuta];
DROP PROCEDURE [EL_PUNTERO].[GetAllRegistrosMillas];
DROP PROCEDURE [EL_PUNTERO].[GetRegistrosPorIDCliente];
DROP PROCEDURE [EL_PUNTERO].[GetCanjePorIDCliente];
DROP PROCEDURE [EL_PUNTERO].[GetFuncionalidadesPorUsuario];
DROP PROCEDURE [EL_PUNTERO].[BorrarTablaAuxiliarPasajeros];
DROP PROCEDURE [EL_PUNTERO].[CargarTablaAuxiliarPasajeros];
DROP PROCEDURE [EL_PUNTERO].[CrearTablaAuxiliarPasajeros];
DROP PROCEDURE [EL_PUNTERO].[GetClientesAuxiliares];
DROP PROCEDURE [EL_PUNTERO].[ObtenerClientePorDoc];
DROP PROCEDURE [EL_PUNTERO].[ObtenerInfoButacasDisponibles];
DROP PROCEDURE [EL_PUNTERO].[GetProductos];
DROP PROCEDURE [EL_PUNTERO].[GetProductosParaUnCliente];
DROP PROCEDURE [EL_PUNTERO].[GetClientePorID];
DROP PROCEDURE [EL_PUNTERO].[GenerarCanje];
DROP PROCEDURE [EL_PUNTERO].[GetServiciosPorIDRuta];
DROP PROCEDURE [EL_PUNTERO].[EliminarServiciosPorRuta];
DROP PROCEDURE [EL_PUNTERO].[InsertarServiciosPorRuta];
DROP PROCEDURE [EL_PUNTERO].[GetClientePorNombreYApellido];
DROP PROCEDURE [EL_PUNTERO].[ObtenerTipoDocumentoPorID];

DROP PROCEDURE [EL_PUNTERO].[ObtenerPasajesFuturos];
DROP PROCEDURE [EL_PUNTERO].[ObtenerEncomiendasFuturas];
DROP PROCEDURE [EL_PUNTERO].ObtenerRutaDeEncomienda;
DROP PROCEDURE [EL_PUNTERO].ObtenerFechaSalidaDeEncomienda;
DROP PROCEDURE [EL_PUNTERO].ObtenerRutaDePasaje;
DROP PROCEDURE [EL_PUNTERO].ObtenerFechaSalidaDePasaje;
DROP PROCEDURE [EL_PUNTERO].ObtenerNombreClientePorID;
DROP PROCEDURE [EL_PUNTERO].[ObtenerServicioAeronave];
DROP PROCEDURE [EL_PUNTERO].ObtenerRutaEncomienda;
DROP PROCEDURE [EL_PUNTERO].ObtenerCiudadesOrigenParaUnServicio;
DROP PROCEDURE [EL_PUNTERO].ObtenerServicioAeronave;
DROP PROCEDURE [EL_PUNTERO].[GetUsuarioPorUsernameYRol];
DROP PROCEDURE [EL_PUNTERO].InsertarDevolucionPasaje
DROP PROCEDURE [EL_PUNTERO].InsertarDevolucionEncomienda
DROP PROCEDURE [EL_PUNTERO].DevolverTodosLosPasajes
DROP PROCEDURE [EL_PUNTERO].DevolverTodasLasEncomiendas
DROP PROCEDURE [EL_PUNTERO].[GetProductoMinimo];
DROP PROCEDURE [EL_PUNTERO].[GetProductoPorID];
DROP PROCEDURE [EL_PUNTERO].InsertarDevolucionPasaje;
DROP PROCEDURE [EL_PUNTERO].InsertarDevolucionEncomienda;
DROP PROCEDURE [EL_PUNTERO].[GetDestinosConMasPasajesComprados];
DROP PROCEDURE [EL_PUNTERO].[GetDestinosConMasAeronavesVacias];
DROP PROCEDURE [EL_PUNTERO].[GetClientesConMasPuntosAcumulados];
DROP PROCEDURE [EL_PUNTERO].[GetDestinosConMasPasajesCancelados];
DROP PROCEDURE [EL_PUNTERO].[GetAeronavesConMayorCantDeDiasFueraDeServicio];

DROP PROCEDURE [EL_PUNTERO].[GetAllTipoTarjeta]
DROP PROCEDURE [EL_PUNTERO].[GetRutaPorID]
DROP PROCEDURE [EL_PUNTERO].[GuardarPasajeros]
DROP PROCEDURE [EL_PUNTERO].[GuardarAlQuePaga]
DROP PROCEDURE [EL_PUNTERO].[GuardarTarjetaYCompra]
DROP PROCEDURE [EL_PUNTERO].[GuardarCompraEnEfectivo]
DROP PROCEDURE [EL_PUNTERO].[ObtenerPNR]

DROP TRIGGER [EL_PUNTERO].[Tr_DeshabilitarUsuariosConRolDeshabilitado];

DROP FUNCTION [EL_PUNTERO].[CompraAPartirDeEncomienda];
DROP FUNCTION [EL_PUNTERO].[CompraAPartirDePasaje];
DROP FUNCTION [EL_PUNTERO].[ObtenerAeronaveDeReemplazo];
DROP FUNCTION [EL_PUNTERO].[ObtenerIDBajaServicioMax];
DROP FUNCTION [EL_PUNTERO].[ObtenerAeronaveDeReemplazoPorServicio];
DROP FUNCTION [EL_PUNTERO].[ObtenerMillasCanje];
DROP FUNCTION [EL_PUNTERO].[CantFueraDeServicio];

DROP SCHEMA [EL_PUNTERO];