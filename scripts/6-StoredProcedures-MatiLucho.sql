BEGIN TRANSACTION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [EL_PUNTERO].[GetRolPorNombreComo]
@Descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_ROL] R
	WHERE R.Descripcion LIKE '%' + LOWER(@Descripcion) + '%'
END
GO

CREATE PROCEDURE [EL_PUNTERO].[InsertarFuncionalidadPorRol]
	@ID_Funcionalidad int,
	@ID_Rol int
AS
BEGIN
	INSERT INTO [EL_PUNTERO].[TL_Funcionalidad_Rol] (ID_Funcionalidad, ID_Rol)
	VALUES (@ID_Funcionalidad, @ID_Rol)
END
GO


CREATE PROCEDURE [EL_PUNTERO].[EliminarFuncionalidadesPorRol]
	@ID_Rol int
AS
BEGIN
	DELETE FROM [EL_PUNTERO].[TL_Funcionalidad_Rol] 
	WHERE [ID_Rol] = @ID_Rol 
END	
GO

CREATE PROCEDURE [EL_PUNTERO].[InsertarRol]
	@Descripcion nvarchar(255),
	@Habilitado bit
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [EL_PUNTERO].[TL_Rol] (Descripcion,Habilitado)
	OUTPUT inserted.ID_Rol
	VALUES (@Descripcion, @Habilitado)
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ActualizarRolPorID]
	@ID_Rol int,
	@Descripcion nvarchar(255),
	@Habilitado bit
AS
BEGIN
	UPDATE [EL_PUNTERO].[TL_Rol]
	SET Descripcion = @Descripcion, Habilitado = @Habilitado
	WHERE ID_Rol = @ID_Rol
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetFuncionalidades]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].TL_FUNCIONALIDAD
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetAllRoles]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_ROL]
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetAllRutas]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_RUTA]
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetCiudadPorID]
@ID_Ciudad int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_CIUDAD]
	WHERE @ID_Ciudad = ID_Ciudad
END
GO

CREATE PROCEDURE [EL_PUNTERO].[FiltrarRutas]
@Codigo_Ruta int = NULL,
@Ciudad_Origen nvarchar(255) = NULL,
@Ciudad_Destino nvarchar(255) = NULL,
@Desde_Kg numeric(18,2) = NULL,
@Hasta_Kg numeric(18,2) = NULL,
@Desde_Pasaje numeric(18,2) = NULL,
@Hasta_Pasaje numeric(18,2) = NULL,
@Tipo_Servicio nvarchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].TL_RUTA R
	WHERE ((Codigo_Ruta = @Codigo_Ruta) OR (@Codigo_Ruta is NULL)) 
	  AND ((@Desde_Kg <= Precio_Base_KG) OR (@Desde_Kg is NULL)) 
	  AND ((Precio_Base_KG <= @Hasta_Kg) OR (@Hasta_Kg is NULL))
	  AND ((@Desde_Pasaje <= Precio_Base_Pasaje) OR (@Desde_Pasaje is NULL)) 
	  AND ((Precio_Base_Pasaje <= @Hasta_Pasaje) OR (@Hasta_Pasaje is NULL)) 
	  AND ((@Tipo_Servicio IN (SELECT Nombre FROM [EL_PUNTERO].TL_SERVICIO S, EL_PUNTERO.TL_SERVICIO_RUTA SR WHERE S.ID_Servicio = SR.ID_Servicio AND SR.ID_Ruta = R.ID_Ruta)) OR (@Tipo_Servicio is NULL)) 
	  AND (((SELECT Nombre_Ciudad FROM [EL_PUNTERO].TL_CIUDAD C WHERE C.ID_Ciudad = R.ID_Ciudad_Origen) = @Ciudad_Origen) OR (@Ciudad_Origen is NULL)) 
	  AND (((SELECT Nombre_Ciudad FROM [EL_PUNTERO].TL_CIUDAD C WHERE C.ID_Ciudad = R.ID_Ciudad_Destino) = @Ciudad_Destino) OR (@Ciudad_Destino is NULL))
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerIDPorNombreDeCiudad]
@Nombre_Ciudad nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].TL_CIUDAD
	WHERE Nombre_Ciudad = @Nombre_Ciudad
END
GO

CREATE PROCEDURE [EL_PUNTERO].[CancelarPasajesYEncomiendasConRutaInhabilitada]
	@ID_Ruta int,
	@Motivo varchar(255),
	@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;

   /*Insertar los id_compra, fecha y motivo en la tabla de devolución*/
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION] (ID_Compra)
	  (SELECT DISTINCT ID_Compra FROM [EL_PUNTERO].TL_PASAJE WHERE ID_Viaje IN (SELECT ID_Viaje FROM [EL_PUNTERO].TL_VIAJE WHERE (ID_Ruta=@ID_Ruta) AND (Fecha_Salida>=GETDATE())));

	UPDATE [EL_PUNTERO].TL_DEVOLUCION
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;
	
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION] (ID_Compra)
	  (SELECT DISTINCT ID_Compra FROM [EL_PUNTERO].TL_ENCOMIENDA WHERE ID_Viaje IN (SELECT ID_Viaje FROM [EL_PUNTERO].TL_VIAJE WHERE (ID_Ruta=@ID_Ruta) AND (Fecha_Salida>=GETDATE())));

	UPDATE [EL_PUNTERO].TL_DEVOLUCION
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;

	/*Insertar los id_pasaje, id_encomienda y id_devolucion en la tabla de item_devuelto*/ 
	INSERT INTO [EL_PUNTERO].[TL_ITEM_DEVUELTO] (ID_Pasaje)
	SELECT ID_Pasaje FROM TL_PASAJE WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Ruta=@ID_Ruta);
	
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

	
	--Encomienda
	INSERT INTO [EL_PUNTERO].[TL_ITEM_DEVUELTO] (ID_Encomienda)
	SELECT ID_Encomienda FROM TL_ENCOMIENDA WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE (ID_Ruta=@ID_Ruta)  AND (Fecha_Salida>=GETDATE()));

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

CREATE FUNCTION [EL_PUNTERO].[CompraAPartirDePasaje](@ID_Pasaje int)
RETURNS int
AS
BEGIN
	RETURN (SELECT ID_Compra FROM [EL_PUNTERO].TL_PASAJE WHERE ID_Pasaje=@ID_Pasaje)
END
GO

CREATE FUNCTION [EL_PUNTERO].[CompraAPartirDeEncomienda](@ID_Encomienda int)
RETURNS int
AS
BEGIN
	RETURN (SELECT ID_Compra FROM [EL_PUNTERO].TL_ENCOMIENDA WHERE ID_Encomienda=@ID_Encomienda)
END
GO


CREATE PROCEDURE [EL_PUNTERO].[TraerLosPasajesDevueltos]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].TL_ITEM_DEVUELTO
	WHERE ID_Pasaje IS NOT NULL;
END
GO

CREATE PROCEDURE [EL_PUNTERO].[InsertarIDDevolucion]
@ID_Item_Devuelto int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [EL_PUNTERO].TL_ITEM_DEVUELTO SET ID_Devolucion = [EL_PUNTERO].DevolucionAPartirDePasaje(ID_Pasaje)
	WHERE ID_Item_Devuelto = @ID_Item_Devuelto
END
GO

CREATE PROCEDURE [EL_PUNTERO].[FiltrarViajes]
@Fecha_Salida dateTime,
@Ciudad_Origen varchar(255),
@Ciudad_Destino varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].TL_VIAJE V
	WHERE DAY(V.Fecha_Salida) = DAY(@Fecha_Salida)
	  AND MONTH(V.Fecha_Salida) = MONTH(@Fecha_Salida)
	  AND YEAR(V.Fecha_Salida) = YEAR(@Fecha_Salida)
	  AND (((SELECT Nombre_Ciudad FROM [EL_PUNTERO].TL_CIUDAD C WHERE C.ID_Ciudad = (SELECT ID_Ciudad_Origen FROM TL_RUTA R WHERE R.ID_Ruta = V.ID_Ruta)) = @Ciudad_Origen) OR (@Ciudad_Origen is NULL)) 
	  AND (((SELECT Nombre_Ciudad FROM [EL_PUNTERO].TL_CIUDAD C WHERE C.ID_Ciudad = (SELECT ID_Ciudad_Destino FROM TL_RUTA R WHERE R.ID_Ruta = V.ID_Ruta)) = @Ciudad_Destino) OR (@Ciudad_Destino is NULL))
END
GO

CREATE PROCEDURE [EL_PUNTERO].[CiudadOrigenPorIDRuta]
@ID_Ruta int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
	FROM [EL_PUNTERO].TL_CIUDAD C
	WHERE C.ID_Ciudad = (SELECT R.ID_Ciudad_Origen FROM [EL_PUNTERO].TL_RUTA R WHERE R.ID_Ruta=@ID_Ruta)
END
GO


CREATE PROCEDURE [EL_PUNTERO].[CiudadDestinoPorIDRuta]
@ID_Ruta int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
	FROM [EL_PUNTERO].TL_CIUDAD C
	WHERE C.ID_Ciudad = (SELECT R.ID_Ciudad_Destino FROM [EL_PUNTERO].TL_RUTA R WHERE R.ID_Ruta=@ID_Ruta)
END
GO

--Acordarse de descomentar
CREATE PROCEDURE [EL_PUNTERO].[ObtenerButacasDisponibles]
@ID_Viaje int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ButacasTotales int
	DECLARE @ButacasOcupadas int
	
		CREATE TABLE [EL_PUNTERO].[TL_BUTACAAUX](
			[ID_ButacaAux] int IDENTITY(1,1),
			[ButacasDisponibles] int
		);

		SET @ButacasTotales = (SELECT COUNT(*) FROM [EL_PUNTERO].TL_BUTACA B WHERE B.ID_Aeronave=(SELECT V.ID_Aeronave FROM [EL_PUNTERO].TL_VIAJE V WHERE V.ID_Viaje=@ID_Viaje)) /*AND B.Habilitado=1*/

		SET @ButacasOcupadas = (SELECT COUNT(*) FROM [EL_PUNTERO].TL_PASAJE P WHERE P.ID_Viaje=@ID_Viaje)	
		
		INSERT INTO [EL_PUNTERO].TL_BUTACAAUX(ButacasDisponibles) VALUES (@ButacasTotales-@ButacasOcupadas)
		

		SELECT ButacasDisponibles FROM [EL_PUNTERO].TL_BUTACAAUX WHERE ID_ButacaAux = 1

		DROP TABLE [EL_PUNTERO].[TL_BUTACAAUX]
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerKGSDisponibles]
@ID_Viaje int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @KGSTotales int
	DECLARE @KGSOcupados int

	
	SET @KGSTOTALES = (SELECT A.KG_TOTALES From [EL_PUNTERO].TL_AERONAVE A WHERE A.ID_Aeronave = (SELECT V.ID_Aeronave FROM [EL_PUNTERO].TL_VIAJE V WHERE ID_Viaje=@ID_Viaje))
	SET @KGSOcupados = (SELECT SUM(E.KG) FROM [EL_PUNTERO].TL_ENCOMIENDA E WHERE E.ID_Viaje=@ID_Viaje)

	CREATE TABLE [EL_PUNTERO].[TL_ENCOMIENDAAUX](
		[ID_EncomiendaAux] int IDENTITY(1,1),
		[KGSDisponibles] int
	)

	INSERT INTO  [EL_PUNTERO].[TL_ENCOMIENDAAUX] (KGSDisponibles) VALUES (@KGSTotales-@KGSOcupados)

	SELECT KGSDisponibles FROM [EL_PUNTERO].TL_ENCOMIENDAAUX WHERE ID_EncomiendaAux=1

	DROP TABLE [EL_PUNTERO].TL_ENCOMIENDAAUX
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerViajes]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].TL_VIAJE
END
GO

-----------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [EL_PUNTERO].[CrearTablaAuxiliarPasajeros]
AS
BEGIN
	SET NOCOUNT ON;
	CREATE TABLE [EL_PUNTERO].[TL_CLIENTE_AUX](
	[ID] int IDENTITY (1,1),
	[Nombre] nvarchar(255) NOT NULL,
	[Apellido] nvarchar(255) NOT NULL,
	[NombreYApellido] nvarchar(255) NOT NULL,
	[ID_Tipo_Documento] int NOT NULL,
	[Nro_Documento] int NOT NULL,
	[Mail] nvarchar(255),
	[Telefono] nvarchar(255) NOT NULL,
	[Direccion] nvarchar(255) NOT NULL,
	[Fecha_Nacimiento] datetime NOT NULL,
	[ID_Butaca] int NOT NULL
	);
END
GO

CREATE PROCEDURE [EL_PUNTERO].[BorrarTablaAuxiliarPasajeros]
AS
BEGIN
	SET NOCOUNT ON;
	DROP TABLE [EL_PUNTERO].[TL_CLIENTE_AUX];
END
GO


CREATE PROCEDURE [EL_PUNTERO].[ObtenerInfoButacasDisponibles]
@ID_Viaje int
AS
BEGIN
	SET NOCOUNT ON;
		
		CREATE TABLE [EL_PUNTERO].[TL_BUTACAAUX](
			[ID_ButacaAux] int IDENTITY(1,1),
			[ID_Butaca] int
		);

		INSERT INTO [EL_PUNTERO].TL_BUTACAAUX(ID_Butaca) ((SELECT B.ID_Butaca FROM [EL_PUNTERO].TL_BUTACA B WHERE B.ID_Aeronave = (SELECT V.ID_Aeronave FROM [EL_PUNTERO].TL_VIAJE V WHERE V.ID_Viaje=@ID_Viaje))) /*AND B.Habilitado=1*/

		SELECT * FROM [EL_PUNTERO].TL_BUTACA WHERE ID_Butaca IN 
		(SELECT ID_Butaca
		FROM  [EL_PUNTERO].TL_BUTACAAUX
		WHERE ID_Butaca NOT IN ((SELECT ID_Butaca FROM [EL_PUNTERO].TL_PASAJE P WHERE P.ID_Viaje=@ID_Viaje))  )
		AND ID_Butaca NOT IN (SELECT C.ID_Butaca FROM [EL_PUNTERO].TL_CLIENTE_AUX C)


		DROP TABLE [EL_PUNTERO].[TL_BUTACAAUX]
END
GO

CREATE PROCEDURE [EL_PUNTERO].[CargarTablaAuxiliarPasajeros]
@Tipo_Doc nvarchar(255),
@Nro_Doc int,
@Apellidos nvarchar(255),
@Nombres nvarchar(255),
@Calle nvarchar(255),
@Nro_Calle nvarchar(255),
@Telefono int,
@Fecha_Nacimiento dateTime,
@Mail nvarchar(255),
@ID_Butaca int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID_Tipo_Doc int;
	DECLARE @Direccion varchar(255);
	SET @ID_Tipo_Doc = (SELECT ID_Tipo_Documento FROM TL_TIPO_DOCUMENTO WHERE Descripcion = @Tipo_Doc);
	SET @Direccion = @Calle + @Nro_Calle;

	INSERT INTO [EL_PUNTERO].[TL_CLIENTE_AUX](Nombre,Apellido,NombreYApellido,ID_Tipo_Documento,Nro_Documento,Mail,Telefono,Direccion,Fecha_Nacimiento,ID_Butaca)
		                              VALUES (@Nombres,@Apellidos,@Apellidos + ', ' + @Nombres,@ID_Tipo_Doc,@Nro_Doc,@Mail,@Telefono,@Direccion,@Fecha_Nacimiento,@ID_Butaca);
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerClientePorDoc]
@Tipo_Doc nvarchar(255),
@Nro_Doc int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID_Tipo_Doc int;
	SET @ID_Tipo_Doc = (SELECT ID_Tipo_Documento FROM TL_TIPO_DOCUMENTO WHERE Descripcion = @Tipo_Doc);

	SELECT *
	FROM TL_CLIENTE
	WHERE ID_Tipo_Documento=@ID_Tipo_Doc AND Nro_Documento=@Nro_Doc

END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetClientesAuxiliares]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM TL_CLIENTE_AUX
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetServiciosPorIDRuta]
@ID_Ruta int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT S.*
	FROM [EL_PUNTERO].TL_SERVICIO S, EL_PUNTERO.TL_SERVICIO_RUTA SR
	WHERE S.ID_Servicio = SR.ID_Servicio
	AND @ID_Ruta = SR.ID_Ruta
END
GO

CREATE PROCEDURE [EL_PUNTERO].[InsertarRuta]
	@Codigo int,
	@ID_Ciudad_Destino int,
	@ID_Ciudad_Origen int,
	@Precio_Base_KG numeric(18,2),
	@Precio_Base_Pasaje numeric(18,2),
	@Habilitado bit
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [EL_PUNTERO].[TL_Ruta] (Codigo_Ruta,ID_Ciudad_Origen,ID_Ciudad_Destino,Precio_Base_KG,Precio_Base_Pasaje,Habilitado)
	OUTPUT inserted.ID_Ruta
	VALUES (@Codigo, @ID_Ciudad_Origen,@ID_Ciudad_Destino,@Precio_Base_KG,@Precio_Base_Pasaje,@Habilitado)
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ModificarRuta]
	@ID_Ruta int,
	@Codigo int,
	@ID_Ciudad_Destino int,
	@ID_Ciudad_Origen int,
	@Precio_Base_KG numeric(18,2),
	@Precio_Base_Pasaje numeric(18,2),
	@Habilitado bit
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [EL_PUNTERO].[TL_RUTA]
	SET Codigo_Ruta = @Codigo, 
		ID_Ciudad_Destino = @ID_Ciudad_Destino,
		ID_Ciudad_Origen = @ID_Ciudad_Origen,
		Precio_Base_KG = @Precio_Base_KG,
		Precio_Base_Pasaje = @Precio_Base_Pasaje,
		Habilitado = @Habilitado
	WHERE ID_Ruta = @ID_Ruta
END
GO

CREATE PROCEDURE [EL_PUNTERO].[EliminarServiciosPorRuta]
	@ID_Ruta int
AS
BEGIN
	DELETE FROM [EL_PUNTERO].[TL_SERVICIO_RUTA]
	WHERE @ID_Ruta=ID_Ruta
END 
GO

CREATE PROCEDURE [EL_PUNTERO].[InsertarServiciosPorRuta]
	@ID_Servicio int,
	@ID_Ruta int
AS
BEGIN
	INSERT INTO [EL_PUNTERO].[TL_SERVICIO_RUTA] (ID_Servicio,ID_Ruta)
	VALUES (@ID_Servicio,@ID_Ruta)
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetClientePorNombreYApellido]
@NombreYApellido nvarchar(255)
AS
BEGIN
	SELECT *
	FROM TL_CLIENTE_AUX
	WHERE @NombreYApellido=NombreYApellido
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerTipoDocumentoPorID]
@ID_Tipo_Documento int
AS
BEGIN
	SELECT * 
	FROM TL_Tipo_Documento
	WHERE @ID_Tipo_Documento = ID_Tipo_Documento
END
GO
COMMIT
