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
	
	SELECT *
	FROM [EL_PUNTERO].[TL_Rol]
	WHERE ID_Rol = (SELECT ID_Rol FROM TL_Usuario WHERE ID_Usuario = @ID_User);
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
	
	INSERT INTO [EL_PUNTERO].[TL_Usuario](Id_Rol,Username,Password,Habilitado,Cant_Intentos)
	VALUES(@ID_Rol,@Username,@Password,1,3)
	
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
	FROM [EL_PUNTERO].[TL_Aeronave] A
	ORDER BY A.Matricula
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

   /*Insertar los id_compra, fecha y motivo en la tabla de devolución*/
   --Pasajes
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION] (ID_Compra)
	  (SELECT DISTINCT ID_Compra FROM [EL_PUNTERO].TL_PASAJE WHERE ID_Viaje IN (SELECT ID_Viaje FROM [EL_PUNTERO].TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND (Fecha_Salida>=GETDATE())));
	
	--Encomiendas
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION] (ID_Compra)
	  (SELECT DISTINCT ID_Compra FROM [EL_PUNTERO].TL_ENCOMIENDA WHERE ID_Viaje IN (SELECT ID_Viaje FROM [EL_PUNTERO].TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND (Fecha_Salida>=GETDATE())));

	UPDATE [EL_PUNTERO].TL_DEVOLUCION
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;

	/*Insertar los id_pasaje, id_encomienda y id_devolucion en la tabla de item_devuelto*/ 
	--Pasajes
	INSERT INTO [EL_PUNTERO].[TL_ITEM_DEVUELTO] (ID_Pasaje)
	SELECT ID_Pasaje FROM TL_PASAJE WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND Fecha_Salida>=GETDATE());
	
	CREATE TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO2](
	[ID_Item_Devuelto] int IDENTITY(1,1),
	[ID_Pasaje] int,
	[ID_Devolucion] int
	);

	INSERT INTO [EL_PUNTERO].[TL_ITEM_DEVUELTO2] (ID_Pasaje)
	(SELECT ID_Pasaje FROM  [EL_PUNTERO].[TL_ITEM_DEVUELTO]);

	UPDATE [EL_PUNTERO].TL_ITEM_DEVUELTO SET ID_Devolucion = (SELECT ID_Devolucion FROM [EL_PUNTERO].TL_DEVOLUCION WHERE ID_Compra = [EL_PUNTERO].CompraAPartirDePasaje(I2.ID_Pasaje))
	FROM [EL_PUNTERO].TL_ITEM_DEVUELTO I1 JOIN [EL_PUNTERO].TL_ITEM_DEVUELTO2 I2
	ON I1.ID_Item_Devuelto = I2.ID_Item_Devuelto;

	DROP TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO2];
	
	--Encomiendas
	INSERT INTO [EL_PUNTERO].[TL_ITEM_DEVUELTO] (ID_Encomienda)
	SELECT ID_Encomienda FROM TL_ENCOMIENDA WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND (Fecha_Salida>=GETDATE()));

	CREATE TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO2](
	[ID_Item_Devuelto] int IDENTITY(1,1),
	[ID_Encomienda] int,
	[ID_Devolucion] int
	);

	INSERT INTO [EL_PUNTERO].[TL_ITEM_DEVUELTO2] (ID_Encomienda)
	(SELECT ID_Encomienda FROM  [EL_PUNTERO].[TL_ITEM_DEVUELTO]);

	UPDATE [EL_PUNTERO].TL_ITEM_DEVUELTO SET ID_Devolucion = (SELECT ID_Devolucion FROM [EL_PUNTERO].TL_DEVOLUCION WHERE ID_Compra = [EL_PUNTERO].CompraAPartirDeEncomienda(I2.ID_Encomienda))
	FROM [EL_PUNTERO].TL_ITEM_DEVUELTO I1 JOIN [EL_PUNTERO].TL_ITEM_DEVUELTO2 I2
	ON I1.ID_Item_Devuelto = I2.ID_Item_Devuelto
	WHERE ID_Pasaje IS NULL;

	DROP TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO2];

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

   /*Insertar los id_compra, fecha y motivo en la tabla de devolución*/
   --Pasajes
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION] (ID_Compra)
	  (SELECT DISTINCT ID_Compra FROM [EL_PUNTERO].TL_PASAJE WHERE ID_Viaje IN (SELECT ID_Viaje FROM [EL_PUNTERO].TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND (Fecha_Salida>=@Comienzo AND Fecha_Salida<@Reinicio)));
	
	--Encomiendas
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION] (ID_Compra)
	  (SELECT DISTINCT ID_Compra FROM [EL_PUNTERO].TL_ENCOMIENDA WHERE ID_Viaje IN (SELECT ID_Viaje FROM [EL_PUNTERO].TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND (Fecha_Salida>=@Comienzo AND Fecha_Salida<@Reinicio)));

	UPDATE [EL_PUNTERO].TL_DEVOLUCION
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;

	/*Insertar los id_pasaje, id_encomienda y id_devolucion en la tabla de item_devuelto*/ 
	--Pasajes
	INSERT INTO [EL_PUNTERO].[TL_ITEM_DEVUELTO] (ID_Pasaje)
	SELECT ID_Pasaje FROM TL_PASAJE WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND (Fecha_Salida>=@Comienzo AND Fecha_Salida<@Reinicio));
	
	CREATE TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO2](
	[ID_Item_Devuelto] int IDENTITY(1,1),
	[ID_Pasaje] int,
	[ID_Devolucion] int
	);

	INSERT INTO [EL_PUNTERO].[TL_ITEM_DEVUELTO2] (ID_Pasaje)
	(SELECT ID_Pasaje FROM  [EL_PUNTERO].[TL_ITEM_DEVUELTO]);

	UPDATE [EL_PUNTERO].TL_ITEM_DEVUELTO SET ID_Devolucion = (SELECT ID_Devolucion FROM [EL_PUNTERO].TL_DEVOLUCION WHERE ID_Compra = [EL_PUNTERO].CompraAPartirDePasaje(I2.ID_Pasaje))
	FROM [EL_PUNTERO].TL_ITEM_DEVUELTO I1 JOIN [EL_PUNTERO].TL_ITEM_DEVUELTO2 I2
	ON I1.ID_Item_Devuelto = I2.ID_Item_Devuelto;

	DROP TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO2];
	
	--Encomiendas
	INSERT INTO [EL_PUNTERO].[TL_ITEM_DEVUELTO] (ID_Encomienda)
	SELECT ID_Encomienda FROM TL_ENCOMIENDA WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Aeronave=@ID_Aeronave AND (Fecha_Salida>=@Comienzo AND Fecha_Salida<@Reinicio));

	CREATE TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO2](
	[ID_Item_Devuelto] int IDENTITY(1,1),
	[ID_Encomienda] int,
	[ID_Devolucion] int
	);

	INSERT INTO [EL_PUNTERO].[TL_ITEM_DEVUELTO2] (ID_Encomienda)
	(SELECT ID_Encomienda FROM  [EL_PUNTERO].[TL_ITEM_DEVUELTO]);

	UPDATE [EL_PUNTERO].TL_ITEM_DEVUELTO SET ID_Devolucion = (SELECT ID_Devolucion FROM [EL_PUNTERO].TL_DEVOLUCION WHERE ID_Compra = [EL_PUNTERO].CompraAPartirDeEncomienda(I2.ID_Encomienda))
	FROM [EL_PUNTERO].TL_ITEM_DEVUELTO I1 JOIN [EL_PUNTERO].TL_ITEM_DEVUELTO2 I2
	ON I1.ID_Item_Devuelto = I2.ID_Item_Devuelto
	WHERE ID_Pasaje IS NULL;

	DROP TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO2];

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















CREATE PROCEDURE [EL_PUNTERO].[InsertarCiudad]
@Nombre_Ciudad nvarchar(20)
AS
BEGIN
	INSERT INTO [EL_PUNTERO].[TL_CIUDAD](Nombre_Ciudad)
	VALUES(@Nombre_Ciudad);	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ActualizarCiudad]
@Nombre_Ciudad nvarchar(20),
@ID_Ciudad int
AS
BEGIN
	UPDATE [EL_PUNTERO].[TL_CIUDAD]
	SET Nombre_Ciudad = @Nombre_Ciudad
	WHERE ID_Ciudad = @ID_Ciudad; 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerTodasLasCiudadesConOrigen]
@ID_Origen int
AS
BEGIN
	SET NOCOUNT ON;	
	SELECT * 
	FROM [EL_PUNTERO].[TL_CIUDAD] C
	INNER JOIN [EL_PUNTERO].[TL_RUTA] R ON C.ID_Ciudad = R.ID_Ciudad_Destino
	WHERE R.ID_Ciudad_Origen = @ID_Origen
	ORDER BY Nombre_Ciudad; 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerCiudadPorId_Ciudad]
@ID_Ciudad int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_CIUDAD]
	WHERE @ID_Ciudad = ID_Ciudad;
END
GO


CREATE PROCEDURE [EL_PUNTERO].[ObtenerAeronavesHabilitadas]
AS
BEGIN
	SET NOCOUNT ON;
	EXECUTE [EL_PUNTERO].[HabilitarAeronavesQueVolvieronDeBajaServicio];
	SELECT *
	FROM [EL_PUNTERO].[TL_Aeronave]
	WHERE Baja_Por_Fuera_De_Servicio = 0 AND Baja_Por_Vida_Util=0
	ORDER BY Matricula;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerServiciosDeRuta]
@ID_Ciudad_Origen int,
@ID_Ciudad_Destino int,
@Matricula nvarchar(7)

AS
BEGIN
	SET NOCOUNT ON;
	SELECT S.ID_Servicio,S.Nombre,S.Porcentaje
	FROM [EL_PUNTERO].[TL_SERVICIO] S,[EL_PUNTERO].[TL_AERONAVE] A, [EL_PUNTERO].[TL_RUTA] R
	WHERE @ID_Ciudad_Origen = R.ID_Ciudad_Origen 
			AND @ID_Ciudad_Destino =R.ID_Ciudad_Destino 
			AND @Matricula = A.Matricula
			AND A.ID_Servicio = R.ID_Servicio
	ORDER BY Nombre
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerRutaPorOrigenYDestino]
@ID_Ciudad_Origen int,
@ID_Ciudad_Destino int

AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM  [EL_PUNTERO].[TL_RUTA] R
	WHERE @ID_Ciudad_Origen = R.ID_Ciudad_Origen 
		   AND @ID_Ciudad_Destino =R.ID_Ciudad_Destino;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerIDPorNombreDeCiudad]
@Nombre_Ciudad nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_CIUDAD]  
	WHERE Nombre_Ciudad = @Nombre_Ciudad;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GenerarViaje]
@Fecha_Llegada datetime,
@Fecha_Salida datetime,
@Fecha_Llegada_Estimada datetime,
@ID_Ruta int,
@ID_Aeronave int

AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [EL_PUNTERO].[TL_VIAJE] (Fecha_Llegada,Fecha_Salida,Fecha_Llegada_Estimada,ID_Ruta,ID_Aeronave)
	VALUES (@Fecha_Llegada,@Fecha_Salida,@Fecha_Llegada_Estimada,@ID_Ruta,@ID_Aeronave);
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ValidarHorarioDeAeronave]
@Fecha_Salida datetime,
@Fecha_Llegada_Estimada datetime,
@ID_Aeronave int

AS
BEGIN

	SELECT *
	FROM [EL_PUNTERO].[TL_VIAJE] V
	WHERE V.Fecha_Salida= @Fecha_Salida 
			AND V.Fecha_Llegada_Estimada = @Fecha_Llegada_Estimada
			AND V.ID_Aeronave = @ID_Aeronave
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ValidarAeronaveDelViaje]
@Fecha_Salida datetime,
@ID_Ruta int,
@ID_Aeronave int

AS 
BEGIN
	SELECT *
	FROM [EL_PUNTERO].[TL_AERONAVE] A
	INNER JOIN [EL_PUNTERO].[TL_VIAJE] V ON A.ID_Aeronave = V.ID_Aeronave
	WHERE V.Fecha_Salida = @Fecha_Salida AND V.ID_Ruta = @ID_Ruta
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerViaje]
@Fecha_Salida datetime,
@ID_Ruta int,
@ID_Aeronave int

AS 
BEGIN
	SELECT *
	FROM [EL_PUNTERO].[TL_VIAJE] V
	WHERE V.Fecha_Salida = @Fecha_Salida AND V.ID_Ruta = @ID_Ruta AND V.ID_Aeronave = @ID_Aeronave
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ActualizarFechaLlegada]
@ID int,
@FechaLlegada datetime
AS
BEGIN
	UPDATE [EL_PUNTERO].[TL_VIAJE]
	SET Fecha_Llegada = @FechaLlegada
	WHERE ID_Viaje = @ID; 
END
GO

COMMIT