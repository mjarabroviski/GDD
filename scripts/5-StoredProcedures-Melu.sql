BEGIN TRANSACTION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [EL_PUNTERO].[GetFuncionalidadesPorRol]
@ID_Rol int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_Funcionalidad] F
	INNER JOIN [EL_PUNTERO].[TL_Funcionalidad_Rol] FR ON F.ID_Funcionalidad = FR.ID_Funcionalidad
	WHERE FR.ID_Rol = @ID_Rol 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetRoles]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_Rol]
	WHERE Habilitado = 1; 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetUsuarios]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_Usuario]
	WHERE Habilitado = 1; 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetUsuarioPorUsername]
@User nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_Usuario]
	WHERE Username = @User; 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetRolPorUsuario]
@ID_User int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT R.*
	FROM [EL_PUNTERO].[TL_Rol_Usuario] RU, [EL_PUNTERO].[TL_Rol] R
	WHERE R.ID_Rol = RU.ID_Rol
	AND RU.ID_Usuario = @ID_User
END
GO

CREATE PROCEDURE [EL_PUNTERO].[InhabilitarUsuario]
@ID_User int
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE [EL_PUNTERO].[TL_Usuario]
	SET Habilitado = 0
	WHERE ID_Usuario = @ID_User;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ActualizarUsuarioPorContraIncorrecta]
@ID_User int,
@Cant_Intentos int,
@Habilitado bit

AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE [EL_PUNTERO].[TL_Usuario]
	SET Habilitado = @Habilitado, Cant_Intentos = @Cant_Intentos
	WHERE ID_Usuario = @ID_User;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[LimpiarIntentos]
@ID_User int
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE [EL_PUNTERO].[TL_Usuario]
	SET Cant_Intentos = 3
	WHERE ID_Usuario = @ID_User;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[InsertarUsuario]
@Username nvarchar(255),
@Password nvarchar(64),
@ID_Rol int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID_Usuario int;
	
	INSERT INTO [EL_PUNTERO].[TL_Usuario](Username,Password,Habilitado,Cant_Intentos)
	VALUES(@Username,@Password,1,3)

	SELECT @ID_Usuario = ID_Usuario FROM EL_PUNTERO.TL_USUARIO WHERE Username = @Username

	INSERT INTO [EL_PUNTERO].[TL_ROL_USUARIO](ID_Rol,ID_Usuario)
	VALUES(@ID_Rol,@ID_Usuario)
	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetRolPorNombre]
@Descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_ROL]
	WHERE Descripcion = @Descripcion
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetRolPorID]
@ID int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_ROL]
	WHERE ID_Rol = @ID
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ActualizarContrasena]
@ID_User int,
@Password nvarchar(64)
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE [EL_PUNTERO].[TL_Usuario]
	SET Password = @Password
	WHERE ID_Usuario = @ID_User
	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetCiudades]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_Ciudad]
	ORDER BY Nombre_Ciudad
END
GO

CREATE PROCEDURE [EL_PUNTERO].[EliminarCiudad]
@ID_Ciudad int
AS
BEGIN
	IF(NOT(
	(@ID_Ciudad IN (SELECT ID_Ciudad_Origen FROM [EL_PUNTERO].[TL_Ruta] WHERE ID_Ruta IN (SELECT ID_Ruta FROM [EL_PUNTERO].[TL_Viaje] WHERE Fecha_Salida >= GETDATE())))
	OR
	(@ID_Ciudad IN (SELECT ID_Ciudad_Destino FROM [EL_PUNTERO].[TL_Ruta] WHERE ID_Ruta IN (SELECT ID_Ruta FROM [EL_PUNTERO].[TL_Viaje] WHERE Fecha_Salida >= GETDATE())))
	))
	BEGIN
	DELETE 
	FROM [EL_PUNTERO].[TL_Ciudad]
	WHERE ID_Ciudad = @ID_Ciudad
	END 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetCiudadesPorParametros]
@Nombre nvarchar(20)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [EL_PUNTERO].[TL_Ciudad]
	WHERE Nombre_Ciudad = @Nombre
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetCiudadesPorParametrosComo]
@Nombre nvarchar(20)
AS
BEGIN
	SELECT * FROM [EL_PUNTERO].[TL_Ciudad]
	WHERE Nombre_Ciudad LIKE '%' + LOWER(@Nombre) + '%'
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetServicios]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_SERVICIO]
END
GO

CREATE FUNCTION [EL_PUNTERO].[ObtenerIDBajaServicioMax](@ID_AeronaveBaja int)
RETURNS int
AS
BEGIN
DECLARE @id int

	SELECT @id = MAX(ID_Baja_Servicio) FROM [EL_PUNTERO].[TL_BAJA_SERVICIO_AERONAVE]
	WHERE ID_Aeronave = @ID_AeronaveBaja

	RETURN @id
END
GO

CREATE PROCEDURE [EL_PUNTERO].[HabilitarAeronavesQueVolvieronDeBajaServicio]
AS
BEGIN

	UPDATE [EL_PUNTERO].[TL_AERONAVE] 
	SET Baja_Por_Fuera_De_Servicio = 0
	WHERE Baja_Por_Fuera_De_Servicio = 1
	AND ID_AERONAVE IN (
					SELECT ID_Aeronave FROM [EL_PUNTERO].[TL_BAJA_SERVICIO_AERONAVE] 
					WHERE ID_Baja_Servicio = [EL_PUNTERO].[ObtenerIDBajaServicioMax](ID_AERONAVE)
					AND Fecha_Reinicio_Servicio <= GETDATE())
	END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetAeronaves]
AS
BEGIN
	SET NOCOUNT ON;
	EXECUTE [EL_PUNTERO].[HabilitarAeronavesQueVolvieronDeBajaServicio];
	SELECT *
	FROM [EL_PUNTERO].[TL_Aeronave]
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetServicioPorID]
@ID_Servicio int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_SERVICIO]
	WHERE @ID_Servicio = ID_Servicio
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetAeronavesPorParametros]
@Matricula nvarchar(7) = NULL,
@Fabricante nvarchar (30) = NULL,
@Modelo nvarchar(30) = NULL,
@Nombre_Servicio nvarchar(255) = NULL,
@Fecha_Alta datetime = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT A.*
	FROM [EL_PUNTERO].[TL_AERONAVE] AS A
	INNER JOIN [EL_PUNTERO].[TL_Servicio] AS S ON A.ID_Servicio = S.ID_Servicio

	WHERE 
	(A.Matricula = @Matricula OR @Matricula is NULL)
	AND (A.Fabricante = @Fabricante OR @Fabricante is NULL)
	AND (A.Modelo = @Modelo OR @Modelo is NULL)
	AND (S.Nombre = @Nombre_Servicio OR @Nombre_Servicio is NULL)
	AND (A.Fecha_Alta = @Fecha_Alta OR @Fecha_Alta = 01/01/0001)
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetAeronavesPorParametrosComo]
@Matricula nvarchar(7) = NULL,
@Fabricante nvarchar (30) = NULL,
@Modelo nvarchar(30) = NULL,
@Nombre_Servicio nvarchar(255) = NULL,
@Fecha_Alta datetime = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT A.*
	FROM [EL_PUNTERO].[TL_AERONAVE] AS A
	INNER JOIN [EL_PUNTERO].[TL_Servicio] AS S ON A.ID_Servicio = S.ID_Servicio
	
	WHERE 
	(A.Matricula LIKE ('%' + @Matricula + '%') OR @Matricula is NULL)
	AND (A.Fabricante LIKE ('%' + @Fabricante + '%') OR @Fabricante is NULL)
	AND (A.Modelo LIKE ('%' + @Modelo + '%') OR @Modelo is NULL)
	AND (S.Nombre LIKE ('%' + @Nombre_Servicio + '%') OR @Nombre_Servicio is NULL)
	AND ((A.Fecha_Alta BETWEEN @Fecha_Alta AND GETDATE()) OR @Fecha_Alta = 01/01/0001)
END
GO

CREATE PROCEDURE [EL_PUNTERO].[BajaPorVidaUtil]
@ID_Aeronave int
AS
BEGIN
	IF(NOT(@ID_Aeronave IN (SELECT ID_Aeronave FROM EL_PUNTERO.TL_VIAJE V WHERE V.Fecha_Salida >= GETDATE()
	 AND (V.ID_Viaje IN (SELECT ID_Viaje FROM EL_PUNTERO.TL_ENCOMIENDA) 
	 OR V.ID_Viaje IN (SELECT ID_Viaje FROM EL_PUNTERO.TL_PASAJE)))))
	BEGIN
	UPDATE EL_PUNTERO.TL_AERONAVE
	SET Baja_Por_Vida_Util = 1,
		Fecha_Baja_Definitiva = GETDATE()
	WHERE ID_Aeronave = @ID_Aeronave
	END
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetAeronavePorMatricula]
@Matricula nvarchar(7)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_AERONAVE]
	WHERE Matricula = @Matricula
END
GO

CREATE PROCEDURE [EL_PUNTERO].[InsertarAeronave]
@Matricula nvarchar(7),
@Fabricante nvarchar (30),
@Modelo nvarchar(30),
@ID_Servicio int,
@KG_Totales int,
@Fecha_Alta datetime
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [EL_PUNTERO].[TL_Aeronave](Matricula,Fabricante,Modelo,ID_Servicio,KG_Totales,Fecha_Alta)
	OUTPUT inserted.ID_Aeronave
	VALUES(@Matricula,@Fabricante,@Modelo,@ID_Servicio,@KG_Totales,@Fecha_Alta)
	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerIDPorNombreDeServicio]
@TipoServicio nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].TL_SERVICIO
	WHERE Nombre = @TipoServicio
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetIdTipoPorDescripcion]
@Descripcion nvarchar(30)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_BUTACA] AS B INNER JOIN [EL_PUNTERO].[TL_TIPO_BUTACA] AS T ON B.ID_Tipo_Butaca = T.ID_Tipo_Butaca 
	WHERE T.Descripcion = @Descripcion
END
GO

CREATE PROCEDURE [EL_PUNTERO].[InsertarButaca]
@Numero int,
@Tipo int,
@ID_Aeronave int

AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO [EL_PUNTERO].[TL_Butaca](Nro_Butaca,ID_Tipo_Butaca,ID_Aeronave)
	OUTPUT inserted.ID_Aeronave
	VALUES(@Numero,@Tipo,@ID_Aeronave)
END
GO

CREATE PROCEDURE [EL_PUNTERO].[EliminarAeronave]
@ID_Aeronave int
AS
BEGIN
	DELETE 
	FROM [EL_PUNTERO].[TL_Aeronave]
	WHERE ID_Aeronave = @ID_Aeronave
END
GO

CREATE FUNCTION [EL_PUNTERO].[ObtenerAeronaveDeReemplazo](@ID_AeronaveBaja int, @Modelo nvarchar(30), @Servicio int, @Fabricante nvarchar(30))
RETURNS int
AS
BEGIN
DECLARE @reemplazo int
DECLARE @maxLlegada datetime

    SELECT @maxLlegada = MAX(V.Fecha_Llegada) FROM [EL_PUNTERO].TL_VIAJE V WHERE V.ID_Aeronave = @ID_AeronaveBaja
	SELECT TOP 1 @reemplazo = ID_Aeronave FROM [EL_PUNTERO].TL_AERONAVE A WHERE A.ID_Aeronave != @ID_AeronaveBaja
																			AND Baja_Por_Fuera_De_Servicio = 0
																			AND Baja_Por_Vida_Util = 0 
																			AND A.Modelo = @Modelo 
																			AND A.Fabricante = @Fabricante 
																			AND A.ID_Servicio = @Servicio
																			AND not exists (SELECT 1 FROM [EL_PUNTERO].TL_VIAJE B WHERE A.ID_Aeronave = B.ID_Aeronave  
																																	AND B.Fecha_Salida <= @maxLlegada
																																	AND B.Fecha_Salida >= GETDATE())
	RETURN @reemplazo	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[SeleccionReemplazoAeronave]
@ID_Aeronave int,
@Modelo nvarchar(30),
@Fabricante nvarchar(30),
@ID_Servicio int
AS
BEGIN
DECLARE @reemplazo int

	BEGIN TRY 

	SET @reemplazo = [EL_PUNTERO].[ObtenerAeronaveDeReemplazo](@ID_Aeronave,@Modelo,@ID_Servicio,@Fabricante)
	IF(@reemplazo is not null)
	BEGIN
	UPDATE EL_PUNTERO.TL_VIAJE 
	SET ID_Aeronave = @reemplazo
	WHERE ID_Aeronave = @ID_Aeronave
	END
	
	END TRY 
	BEGIN CATCH

	END CATCH
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetViajesPorAeronave]
@ID_Aeronave int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_Viaje] 
	WHERE ID_Aeronave = @ID_Aeronave
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ModificarAeronave]
@ID_Aeronave int,
@Matricula nvarchar(7),
@Fabricante nvarchar (30),
@Modelo nvarchar(30),
@ID_Servicio int,
@KG_Totales int,
@Fecha_Alta datetime
AS
BEGIN
	UPDATE [EL_PUNTERO].[TL_Aeronave]
	SET Matricula = @Matricula,
		Fabricante = @Fabricante,
		Modelo = @Modelo,
		ID_Servicio = @ID_Servicio,
		KG_Totales = @KG_Totales,
		Fecha_Alta = @Fecha_Alta
	WHERE ID_Aeronave = @ID_Aeronave	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetTipoButacaPorButaca]
@ID_Tipo int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_TIPO_BUTACA] 
	WHERE ID_Tipo_Butaca = @ID_Tipo
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetButacasDeAeronave]
@ID_Aeronave int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_BUTACA] 
	WHERE ID_Aeronave = @ID_Aeronave
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetTiposButacas]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_TIPO_BUTACA] 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetTipoPorDescripcion]
@Tipo nvarchar(30)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_TIPO_BUTACA]
	WHERE Descripcion = @Tipo 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ModificarButaca]
@ID_Butaca int,
@Tipo int
AS
BEGIN
	UPDATE [EL_PUNTERO].[TL_BUTACA]
	SET ID_Tipo_Butaca = @Tipo
	WHERE ID_Butaca = @ID_Butaca	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[DarDeBajaButaca]
@ID_Butaca int
AS
BEGIN
	UPDATE [EL_PUNTERO].[TL_BUTACA]
	SET Habilitado = 0
	WHERE ID_Butaca = @ID_Butaca	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetMaxNroButaca]
@ID_Aeronave int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_BUTACA]
	WHERE ID_Aeronave = @ID_Aeronave AND Nro_Butaca = (SELECT MAX(Nro_Butaca)FROM [EL_PUNTERO].[TL_BUTACA] WHERE ID_Aeronave = @ID_Aeronave)
END
GO

CREATE PROCEDURE [EL_PUNTERO].[DarDeBajaPorVidaUtil]
@ID_Aeronave int
AS
BEGIN
	UPDATE [EL_PUNTERO].[TL_AERONAVE]
	SET Baja_Por_Vida_Util = 1
	WHERE ID_Aeronave = @ID_Aeronave	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ReemplazoAeronave]
@ID_Reemplazo int,
@ID_Nueva int
AS
BEGIN
	UPDATE [EL_PUNTERO].TL_VIAJE 
	SET ID_Aeronave = @ID_Nueva
	WHERE ID_Aeronave = @ID_Reemplazo AND Fecha_Salida >= GETDATE();
END
GO

CREATE PROCEDURE [EL_PUNTERO].[CancelarPasajesYEncomiendasPorBajaAeronave]
	@ID_Aeronave int,
	@Motivo varchar(255),
	@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;

	--Inserto los id_pasaje del viaje de la aeronave que viene por parametro 
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION_PASAJE] (ID_Pasaje)
	SELECT P.ID_Pasaje FROM TL_PASAJE P WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND Fecha_Salida > GETDATE())
	AND P.ID_Pasaje NOT IN (SELECT D.ID_Pasaje FROM EL_PUNTERO.TL_DEVOLUCION_PASAJE D)

	--Se llenan la fecha, el motivo y el usuario de los pasajes
	UPDATE [EL_PUNTERO].TL_DEVOLUCION_PASAJE
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;
	
	--Inserto los id_encomienda del viaje de la aeronave que viene por parametro 
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION_ENCOMIENDA] (ID_Encomienda)
	SELECT E.ID_Encomienda FROM TL_ENCOMIENDA E WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND Fecha_Salida > GETDATE())
	AND E.ID_Encomienda NOT IN (SELECT D.ID_Encomienda FROM EL_PUNTERO.TL_DEVOLUCION_ENCOMIENDA D)

	--Se llenan la fecha, el motivo y el usuario de las encomiendas
	UPDATE [EL_PUNTERO].TL_DEVOLUCION_ENCOMIENDA
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[DarDeBajaPorFueraDeServicio]
@ID_Aeronave int,
@Comienzo datetime,
@Reinicio datetime
AS
BEGIN
	UPDATE [EL_PUNTERO].[TL_AERONAVE]
	SET Baja_Por_Fuera_De_Servicio = 1
	WHERE ID_Aeronave = @ID_Aeronave
	
	INSERT INTO [EL_PUNTERO].[TL_BAJA_SERVICIO_AERONAVE] (ID_Aeronave,Fecha_Fuera_De_Servicio,Fecha_Reinicio_Servicio)
	VALUES (@ID_Aeronave,@Comienzo,@Reinicio)
END
GO

CREATE PROCEDURE [EL_PUNTERO].[BajaPorFueraDeServicio]
@ID_Aeronave int,
@Comienzo datetime,
@Reinicio datetime
AS
BEGIN
	IF(NOT(@ID_Aeronave IN (SELECT ID_Aeronave FROM EL_PUNTERO.TL_VIAJE V WHERE (V.Fecha_Salida >= @Comienzo AND V.Fecha_Salida < @Reinicio)
	 AND (V.ID_Viaje IN (SELECT ID_Viaje FROM EL_PUNTERO.TL_ENCOMIENDA) 
	 OR V.ID_Viaje IN (SELECT ID_Viaje FROM EL_PUNTERO.TL_PASAJE)))))
	BEGIN
	UPDATE EL_PUNTERO.TL_AERONAVE
	SET Baja_Por_Fuera_De_Servicio = 1
	WHERE ID_Aeronave = @ID_Aeronave

	INSERT INTO [EL_PUNTERO].[TL_BAJA_SERVICIO_AERONAVE] (ID_Aeronave,Fecha_Fuera_De_Servicio,Fecha_Reinicio_Servicio)
	VALUES (@ID_Aeronave,@Comienzo,@Reinicio)
	END
END
GO

CREATE PROCEDURE [EL_PUNTERO].[CancelarPasajesYEncomiendasPorBajaServicioAeronave]
	@ID_Aeronave int,
	@Motivo varchar(255),
	@ID_Usuario int,
	@Comienzo datetime,
	@Reinicio datetime
AS
BEGIN
	SET NOCOUNT ON;

	--Inserto los id_pasaje del viaje de la aeronave que viene por parametro 
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION_PASAJE] (ID_Pasaje)
	SELECT P.ID_Pasaje FROM TL_PASAJE P WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND (Fecha_Salida>=@Comienzo AND Fecha_Salida<@Reinicio))
	AND P.ID_Pasaje NOT IN (SELECT D.ID_Pasaje FROM EL_PUNTERO.TL_DEVOLUCION_PASAJE D)

	--Se llenan la fecha, el motivo y el usuario de los pasajes
	UPDATE [EL_PUNTERO].TL_DEVOLUCION_PASAJE
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;
	
	--Inserto los id_encomienda del viaje de la aeronave que viene por parametro 
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION_ENCOMIENDA] (ID_Encomienda)
	SELECT E.ID_Encomienda FROM TL_ENCOMIENDA E WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND (Fecha_Salida>=@Comienzo AND Fecha_Salida<@Reinicio))
	AND E.ID_Encomienda NOT IN (SELECT D.ID_Encomienda FROM EL_PUNTERO.TL_DEVOLUCION_ENCOMIENDA D)

	--Se llenan la fecha, el motivo y el usuario de las encomiendas
	UPDATE [EL_PUNTERO].TL_DEVOLUCION_ENCOMIENDA
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;
END
GO

CREATE FUNCTION [EL_PUNTERO].[ObtenerAeronaveDeReemplazoPorServicio](@ID_AeronaveBaja int, @Modelo nvarchar(30), @Servicio int, @Fabricante nvarchar(30), @Comienzo datetime, @Reinicio datetime)
RETURNS int
AS
BEGIN
DECLARE @reemplazo int
DECLARE @maxLlegada datetime

	SELECT TOP 1 @reemplazo = ID_Aeronave FROM [EL_PUNTERO].TL_AERONAVE A WHERE A.ID_Aeronave != @ID_AeronaveBaja
																			AND Baja_Por_Fuera_De_Servicio = 0
																			AND Baja_Por_Vida_Util = 0 
																			AND A.Modelo = @Modelo 
																			AND A.Fabricante = @Fabricante 
																			AND A.ID_Servicio = @Servicio
																			AND not exists (SELECT 1 FROM [EL_PUNTERO].TL_VIAJE B WHERE A.ID_Aeronave = B.ID_Aeronave  
																																	AND B.Fecha_Salida >= @Comienzo
																																	AND B.Fecha_Salida < @Reinicio)
	RETURN @reemplazo	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[SeleccionReemplazoAeronavePorServicio]
@ID_Aeronave int,
@Modelo nvarchar(30),
@Fabricante nvarchar(30),
@ID_Servicio int,
@Comienzo datetime,
@Reinicio datetime
AS
BEGIN
DECLARE @reemplazo int

	BEGIN TRY 

	SET @reemplazo = [EL_PUNTERO].[ObtenerAeronaveDeReemplazoPorServicio](@ID_Aeronave,@Modelo,@ID_Servicio,@Fabricante,@Comienzo,@Reinicio)
	IF(@reemplazo is not null)
	BEGIN
	UPDATE EL_PUNTERO.TL_VIAJE 
	SET ID_Aeronave = @reemplazo
	WHERE ID_Aeronave = @ID_Aeronave
	END
	
	END TRY 
	BEGIN CATCH

	END CATCH
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ReemplazoAeronavePorServicio]
@ID_Reemplazo int,
@ID_Nueva int,
@Comienzo datetime,
@Reinicio datetime
AS
BEGIN
	UPDATE [EL_PUNTERO].TL_VIAJE 
	SET ID_Aeronave = @ID_Nueva
	WHERE ID_Aeronave = @ID_Reemplazo AND Fecha_Salida >= @Comienzo AND Fecha_Salida < @Reinicio;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetCantButacasPorAeronave]
@ID_Aeronave int,
@Descripcion nvarchar(30)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_BUTACA]
	WHERE ID_Aeronave = @ID_Aeronave AND Nro_Butaca = 
	(SELECT MAX(Nro_Butaca)FROM [EL_PUNTERO].[TL_BUTACA] WHERE ID_Aeronave = @ID_Aeronave AND ID_Tipo_Butaca = 
	(SELECT ID_Tipo_Butaca FROM [EL_PUNTERO].[TL_TIPO_BUTACA] WHERE Descripcion = @Descripcion))
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetFuncionalidadPorNombre]
@Descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_Funcionalidad] 
	WHERE Descripcion = @Descripcion
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetFuncionalidadesPorNombreRol]
@Nombre_Rol nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_Funcionalidad] F
	INNER JOIN [EL_PUNTERO].TL_FUNCIONALIDAD_ROL FR ON F.ID_Funcionalidad = FR.ID_Funcionalidad 
	INNER JOIN EL_PUNTERO.TL_ROL R ON R.ID_Rol = FR.ID_Rol 
	WHERE R.Descripcion = @Nombre_Rol
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetClientePorTipoYDocumento]
@Documento int,
@Tipo_Doc int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_CLIENTE] 
	WHERE Nro_Documento = @Documento 
	AND ID_Tipo_Documento = @Tipo_Doc
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetAllTipoDocumento]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_TIPO_DOCUMENTO] 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetClientePorTipoYDocumentoYFechaNac]
@Documento int,
@Tipo_Doc int,
@Fecha datetime
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_CLIENTE] 
	WHERE Nro_Documento = @Documento 
	AND ID_Tipo_Documento = @Tipo_Doc
	AND Fecha_Nacimiento = @Fecha
END
GO

CREATE PROCEDURE [EL_PUNTERO].[AgregarRegistroMillas]
@ID_Viaje int
AS
BEGIN
	--Elimino los registros vencidos
	DELETE FROM EL_PUNTERO.TL_REGISTRO_MILLAS 
	WHERE DATEDIFF(DAY, Fecha_Inicio, GETDATE()) = 366

	--Agrego Pasajes
	INSERT INTO EL_PUNTERO.TL_REGISTRO_MILLAS (ID_Cliente,Codigo_Item,Fecha_Inicio,Millas)
	(SELECT DISTINCT ID_Cliente,Codigo_Pasaje, GETDATE(), (Precio/10) FROM EL_PUNTERO.TL_PASAJE WHERE ID_Viaje = @ID_Viaje
	AND ID_Pasaje NOT IN (SELECT ID_Pasaje FROM EL_PUNTERO.TL_DEVOLUCION_PASAJE))

	--Agrego Encomiendas
	INSERT INTO [EL_PUNTERO].[TL_REGISTRO_MILLAS] (ID_Cliente,Codigo_Item,Fecha_Inicio,Millas)
	(SELECT DISTINCT ID_Cliente,Codigo_Encomienda, GETDATE(), (Precio/10) FROM EL_PUNTERO.TL_ENCOMIENDA E INNER JOIN EL_PUNTERO.TL_COMPRA C ON C.ID_Compra = E.ID_Compra  
	WHERE ID_Viaje = @ID_Viaje AND ID_Encomienda NOT IN (SELECT ID_Encomienda FROM EL_PUNTERO.TL_DEVOLUCION_ENCOMIENDA))

	--Sumo las millas del cliente
	UPDATE C
	SET C.Millas += (SELECT SUM(R.Millas) 
					 FROM EL_PUNTERO.TL_REGISTRO_MILLAS R  
					 WHERE R.ID_Cliente = C.ID_Cliente 
					 AND ((R.Codigo_Item IN (SELECT P.Codigo_Pasaje FROM EL_PUNTERO.TL_PASAJE P WHERE P.ID_Viaje = @ID_Viaje)) 
					 OR (R.Codigo_Item IN (SELECT E.Codigo_Encomienda FROM EL_PUNTERO.TL_ENCOMIENDA E WHERE E.ID_Viaje = @ID_Viaje)))) 
	FROM EL_PUNTERO.TL_CLIENTE C

	--Pongo en cero los demas campos de millas
	UPDATE EL_PUNTERO.TL_CLIENTE
	SET Millas = 0
	WHERE Millas is null
END
GO

---------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [EL_PUNTERO].[GetAllRegistrosMillas]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_REGISTRO_MILLAS] 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetRegistrosPorIDCliente]
@ID_Cliente int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_REGISTRO_MILLAS]
	WHERE ID_Cliente = @ID_Cliente
	ORDER BY Fecha_Inicio;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetCanjePorIDCliente]
@ID_Cliente int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_CANJE]
	WHERE ID_Cliente = @ID_Cliente
	ORDER BY Fecha_Canje;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetFuncionalidadesPorUsuario]
@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT F.*
	FROM [EL_PUNTERO].[TL_Funcionalidad] F
	INNER JOIN [EL_PUNTERO].TL_FUNCIONALIDAD_ROL FR ON F.ID_Funcionalidad = FR.ID_Funcionalidad 
	WHERE FR.ID_Rol IN (SELECT RU.ID_Rol FROM EL_PUNTERO.TL_ROL_USUARIO RU WHERE RU.ID_Usuario = @ID_Usuario)
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetProductos]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_PRODUCTO]
	WHERE Stock > 0
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetProductosParaUnCliente]
@ID_Cliente int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_PRODUCTO] P
	WHERE P.Puntos <= (SELECT C.Millas FROM EL_PUNTERO.TL_CLIENTE C WHERE C.ID_Cliente = @ID_Cliente)
	AND P.Stock > 0
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetClientePorID]
@ID_Cliente int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_Cliente] C
	WHERE C.ID_Cliente = @ID_Cliente
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GenerarCanje]
@ID_Producto int,
@Cantidad int,
@ID_Cliente int
AS
BEGIN
	SET NOCOUNT ON;
	
	--Inserto el canje
	INSERT INTO EL_PUNTERO.TL_CANJE (ID_Producto,Cantidad,Fecha_Canje,ID_Cliente)
	VALUES (@ID_Producto, @Cantidad, GETDATE(), @ID_Cliente)

	--Modifico las millas del cliente
	UPDATE C
	SET C.Millas -= (SELECT P.Puntos FROM EL_PUNTERO.TL_PRODUCTO P WHERE P.ID_Producto = @ID_Producto)*@Cantidad
	FROM EL_PUNTERO.TL_CLIENTE C
	WHERE C.ID_Cliente = @ID_Cliente

	--Modifico el Stock del producto
	UPDATE P
	SET Stock -= @Cantidad
	FROM EL_PUNTERO.TL_PRODUCTO P
	WHERE P.ID_Producto = @ID_Producto
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetUsuarioPorUsernameYRol]
@User nvarchar(255),
@ID_Rol int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT U.*
	FROM [EL_PUNTERO].[TL_Usuario] U, EL_PUNTERO.TL_ROL_USUARIO RU
	WHERE Username = @User AND RU.ID_Rol = @ID_Rol AND RU.ID_Usuario = U.ID_Usuario
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetProductoMinimo]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT MIN(P.Puntos)
	FROM [EL_PUNTERO].[TL_PRODUCTO] P
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetProductoPorID]
@ID_Producto int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_PRODUCTO] P
	WHERE P.ID_Producto = @ID_Producto
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetDestinosConMasPasajesComprados]
@Fecha_Desde datetime,
@Fecha_Hasta datetime
AS
BEGIN
	SELECT TOP 5 C.Nombre_Ciudad AS Parametro,COUNT(P.ID_Pasaje) AS Valor
	FROM EL_PUNTERO.TL_CIUDAD C
	INNER JOIN EL_PUNTERO.TL_RUTA R ON R.ID_Ciudad_Destino = C.ID_Ciudad
	INNER JOIN EL_PUNTERO.TL_VIAJE V ON V.ID_Ruta = R.ID_Ruta
	INNER JOIN EL_PUNTERO.TL_PASAJE P ON P.ID_Viaje = V.ID_Viaje
	WHERE V.Fecha_Salida BETWEEN @Fecha_Desde AND @Fecha_Hasta
	GROUP BY C.Nombre_Ciudad
	ORDER BY 2 DESC
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetDestinosConMasAeronavesVacias]
@Fecha_Desde datetime,
@Fecha_Hasta datetime
AS
BEGIN
	SELECT TOP 5 C.Nombre_Ciudad AS Parametro,
	COUNT(*) AS Valor
	FROM EL_PUNTERO.TL_CIUDAD C
	INNER JOIN EL_PUNTERO.TL_RUTA R ON R.ID_Ciudad_Destino = C.ID_Ciudad
	INNER JOIN EL_PUNTERO.TL_VIAJE V ON V.ID_Ruta = R.ID_Ruta
	INNER JOIN EL_PUNTERO.TL_AERONAVE A ON A.ID_Aeronave = V.ID_Aeronave
	INNER JOIN EL_PUNTERO.TL_BUTACA B ON B.ID_Aeronave = A.ID_Aeronave
	WHERE V.Fecha_Salida BETWEEN @Fecha_Desde AND @Fecha_Hasta
	AND B.ID_Butaca NOT IN (SELECT P1.ID_Butaca 
						    FROM EL_PUNTERO.TL_PASAJE P1
						    WHERE P1.ID_Viaje = V.ID_Viaje)
	GROUP BY C.Nombre_Ciudad
	ORDER BY 2 DESC
END
GO


CREATE FUNCTION [EL_PUNTERO].[ObtenerMillasCanje](@ID_Cliente int, @Fecha datetime)
RETURNS int
AS
BEGIN
DECLARE @resul int

	SELECT @resul = SUM(J.Cantidad*P.Puntos) 
					 FROM EL_PUNTERO.TL_CANJE J 
					 INNER JOIN EL_PUNTERO.TL_PRODUCTO P ON P.ID_Producto = J.ID_Producto
					 WHERE J.ID_Cliente = @ID_Cliente
					 AND J.Fecha_Canje < @Fecha
	IF (@resul is null)
	BEGIN
	RETURN 0
	END
	RETURN @resul
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetClientesConMasPuntosAcumulados]
@Fecha_Desde datetime,
@Fecha_Hasta datetime
AS
BEGIN
	SELECT TOP 5 UPPER(C.Apellido) + ' ' + UPPER(C.Nombre) AS Parametro,
	SUM(R.Millas) - [EL_PUNTERO].[ObtenerMillasCanje](C.ID_Cliente,@Fecha_Hasta) AS Valor
	FROM EL_PUNTERO.TL_CLIENTE C
	INNER JOIN EL_PUNTERO.TL_REGISTRO_MILLAS R ON R.ID_Cliente = C.ID_Cliente
	WHERE R.Fecha_Inicio < @Fecha_Hasta
	AND DATEDIFF(DAY, Fecha_Inicio, @Fecha_Hasta) <= 366
	GROUP BY C.Apellido,C.Nombre, C.ID_Cliente
	ORDER BY 2 DESC 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetDestinosConMasPasajesCancelados]
@Fecha_Desde datetime,
@Fecha_Hasta datetime
AS
BEGIN
	SELECT TOP 5 C.Nombre_Ciudad AS Parametro,COUNT(P.ID_Pasaje) AS Valor
	FROM EL_PUNTERO.TL_CIUDAD C
	INNER JOIN EL_PUNTERO.TL_RUTA R ON R.ID_Ciudad_Destino = C.ID_Ciudad
	INNER JOIN EL_PUNTERO.TL_VIAJE V ON V.ID_Ruta = R.ID_Ruta
	INNER JOIN EL_PUNTERO.TL_PASAJE P ON P.ID_Viaje = V.ID_Viaje
	WHERE V.Fecha_Salida BETWEEN @Fecha_Desde AND @Fecha_Hasta
	AND P.ID_Pasaje IN (SELECT DP.ID_Pasaje FROM EL_PUNTERO.TL_DEVOLUCION_PASAJE DP)
	GROUP BY C.Nombre_Ciudad
	ORDER BY 2 DESC
END
GO


CREATE FUNCTION [EL_PUNTERO].[CantFueraDeServicio](@ID_Baja int,@Fecha_Desde datetime,@Fecha_Hasta datetime)
RETURNS int
AS
BEGIN
DECLARE @resul int
DECLARE @bajaDesde datetime
DECLARE @bajaHasta datetime

	SELECT @bajaDesde = BS.Fecha_Fuera_De_Servicio FROM EL_PUNTERO.TL_BAJA_SERVICIO_AERONAVE BS WHERE BS.ID_Baja_Servicio = @ID_Baja
	SELECT @bajaHasta = BS.Fecha_Reinicio_Servicio FROM EL_PUNTERO.TL_BAJA_SERVICIO_AERONAVE BS WHERE BS.ID_Baja_Servicio = @ID_Baja

	IF((@bajaDesde<@Fecha_Desde) AND (@bajaHasta>@Fecha_Hasta))
	BEGIN
		SET @resul = DATEDIFF(DAY, @Fecha_Desde, @Fecha_Hasta)
	END
	
	IF((@bajaDesde<@Fecha_Desde) AND (@bajaHasta<@Fecha_Hasta))
	BEGIN
		SET @resul = DATEDIFF(DAY, @Fecha_Desde, @bajaHasta)
	END

	IF((@bajaDesde>@Fecha_Desde) AND (@bajaHasta>@Fecha_Hasta))
	BEGIN
		SET @resul = DATEDIFF(DAY, @bajaDesde, @Fecha_Hasta)
	END

	IF((@bajaDesde>@Fecha_Desde) AND (@bajaHasta<@Fecha_Hasta))
	BEGIN
		SET @resul = DATEDIFF(DAY, @bajaDesde, @bajaHasta)
	END

	RETURN @resul
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetAeronavesConMayorCantDeDiasFueraDeServicio]
@Fecha_Desde datetime,
@Fecha_Hasta datetime
AS
BEGIN
	SELECT TOP 5 A.Matricula AS Parametro,MAX( [EL_PUNTERO].[CantFueraDeServicio](B.ID_Baja_Servicio,@Fecha_Desde,@Fecha_Hasta)) AS Valor
	FROM EL_PUNTERO.TL_AERONAVE A
	INNER JOIN EL_PUNTERO.TL_BAJA_SERVICIO_AERONAVE B ON B.ID_Aeronave=A.ID_Aeronave
	
	GROUP BY A.Matricula
	ORDER BY 2 DESC
END
GO
COMMIT