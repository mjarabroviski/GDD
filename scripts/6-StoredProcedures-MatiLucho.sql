
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

	--Inserto los id_pasaje del viaje de la ruta que viene por parametro 
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION_PASAJE] (ID_Pasaje)
	SELECT P.ID_Pasaje FROM TL_PASAJE P WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Ruta=@ID_Ruta)
	AND P.ID_Pasaje NOT IN (SELECT D.ID_Pasaje FROM EL_PUNTERO.TL_DEVOLUCION_PASAJE D)

	--Se llenan la fecha, el motivo y el usuario de los pasajes
	UPDATE [EL_PUNTERO].TL_DEVOLUCION_PASAJE
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;
	
	--Inserto los id_encomienda del viaje de la ruta que viene por parametro 
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION_ENCOMIENDA] (ID_Encomienda)
	SELECT E.ID_Encomienda FROM TL_ENCOMIENDA E WHERE ID_Viaje IN  (SELECT ID_Viaje FROM TL_VIAJE WHERE ID_Ruta=@ID_Ruta)
	AND E.ID_Encomienda NOT IN (SELECT D.ID_Encomienda FROM EL_PUNTERO.TL_DEVOLUCION_ENCOMIENDA D)

	--Se llenan la fecha, el motivo y el usuario de las encomiendas
	UPDATE [EL_PUNTERO].TL_DEVOLUCION_ENCOMIENDA
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;

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

CREATE PROCEDURE [EL_PUNTERO].[ObtenerButacasDisponibles]
@ID_Viaje int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ButacasTotales int
	DECLARE @ButacasOcupadas int
	DECLARE @ButacasDevueltas int
	
		CREATE TABLE [EL_PUNTERO].[TL_BUTACAAUX](
			[ID_ButacaAux] int IDENTITY(1,1),
			[ButacasDisponibles] int
		);

		SET @ButacasTotales = (SELECT COUNT(*) FROM [EL_PUNTERO].TL_BUTACA B WHERE B.ID_Aeronave=(SELECT V.ID_Aeronave FROM [EL_PUNTERO].TL_VIAJE V WHERE V.ID_Viaje=@ID_Viaje) AND B.Habilitado=1)

		SET @ButacasOcupadas = (SELECT COUNT(*) FROM [EL_PUNTERO].TL_PASAJE P WHERE P.ID_Viaje=@ID_Viaje)	
		
		SET @ButacasDevueltas = (SELECT COUNT(*) FROM [EL_PUNTERO].TL_DEVOLUCION_PASAJE WHERE ID_Pasaje IN (SELECT ID_Pasaje FROM [EL_PUNTERO].TL_PASAJE WHERE ID_Viaje=@ID_Viaje))

		INSERT INTO [EL_PUNTERO].TL_BUTACAAUX(ButacasDisponibles) VALUES (@ButacasTotales-@ButacasOcupadas+@ButacasDevueltas)
		
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
	DECLARE @KGSDevueltos int

	SET @KGSTOTALES = (SELECT A.KG_TOTALES From [EL_PUNTERO].TL_AERONAVE A WHERE A.ID_Aeronave = (SELECT V.ID_Aeronave FROM [EL_PUNTERO].TL_VIAJE V WHERE ID_Viaje=@ID_Viaje))
	SET @KGSOcupados = (SELECT SUM(E.KG) FROM [EL_PUNTERO].TL_ENCOMIENDA E WHERE E.ID_Viaje=@ID_Viaje)
	SET @KGSDevueltos = (SELECT COUNT(*) FROM [EL_PUNTERO].TL_ENCOMIENDA E WHERE E.ID_Encomienda IN (SELECT DE.ID_Encomienda FROM [EL_PUNTERO].TL_DEVOLUCION_ENCOMIENDA DE) AND E.ID_Viaje=@ID_Viaje)

	IF (@KGSDevueltos>0)
	BEGIN
		SET @KGSDevueltos = (SELECT SUM(E.KG) FROM [EL_PUNTERO].TL_ENCOMIENDA E WHERE E.ID_Encomienda IN (SELECT DE.ID_Encomienda FROM [EL_PUNTERO].TL_DEVOLUCION_ENCOMIENDA DE) AND E.ID_Viaje=@ID_Viaje)
	END

	CREATE TABLE [EL_PUNTERO].[TL_ENCOMIENDAAUX](
		[ID_EncomiendaAux] int IDENTITY(1,1),
		[KGSDisponibles] int
	)

	INSERT INTO  [EL_PUNTERO].[TL_ENCOMIENDAAUX] (KGSDisponibles) VALUES (@KGSTotales-@KGSOcupados+@KGSDevueltos)

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

		INSERT INTO [EL_PUNTERO].TL_BUTACAAUX(ID_Butaca) ((SELECT B.ID_Butaca FROM [EL_PUNTERO].TL_BUTACA B WHERE B.ID_Aeronave = (SELECT V.ID_Aeronave FROM [EL_PUNTERO].TL_VIAJE V WHERE V.ID_Viaje=@ID_Viaje) AND B.Habilitado=1))

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
@Telefono nvarchar(255),
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

CREATE PROCEDURE [EL_PUNTERO].[GetAllTipoTarjeta]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_TIPO_TARJETA] 
END
GO


CREATE PROCEDURE [EL_PUNTERO].[GetRutaPorID]
@ID_Ruta int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [EL_PUNTERO].[TL_RUTA] WHERE ID_Ruta=@ID_Ruta 
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GuardarPasajeros]
	@ID_Deseado int,
	@ID_Viaje int,
	@Precio_Pasajes numeric(18,2)
AS
BEGIN
	DECLARE @Cant int
	DECLARE @Nombre nvarchar(255)
	DECLARE @Apellido nvarchar(255)
	DECLARE @ID_Tipo_Documento int
	DECLARE @Nro_Documento int
	DECLARE @Direccion nvarchar(255)
	DECLARE @Telefono nvarchar(255)
	DECLARE @Fecha_Nacimiento datetime
	DECLARE @ID_Cliente int
	DECLARE @Mail nvarchar(255)
	DECLARE @MaxPasaje int
	DECLARE @ID_Butaca int
	
	SET @Cant = (SELECT COUNT(*) FROM [EL_PUNTERO].[TL_CLIENTE] WHERE 
							Nro_Documento = (SELECT CA.Nro_Documento FROM [EL_PUNTERO].[TL_CLIENTE_AUX] CA WHERE CA.ID=@ID_Deseado) AND
							Apellido = (SELECT CA.Apellido FROM [EL_PUNTERO].[TL_CLIENTE_AUX] CA WHERE CA.ID=@ID_Deseado) AND
							Nombre = (SELECT CA.Nombre FROM [EL_PUNTERO].[TL_CLIENTE_AUX] CA WHERE CA.ID=@ID_Deseado))
	
	SET @Nombre = (SELECT Nombre FROM [EL_PUNTERO].[TL_CLIENTE_AUX] WHERE ID=@ID_Deseado)
	SET @Apellido = (SELECT Apellido FROM [EL_PUNTERO].[TL_CLIENTE_AUX] WHERE ID=@ID_Deseado)
	SET @ID_Tipo_Documento = (SELECT ID_Tipo_Documento FROM [EL_PUNTERO].[TL_CLIENTE_AUX] WHERE ID=@ID_Deseado)
	SET @Nro_Documento = (SELECT Nro_Documento FROM [EL_PUNTERO].[TL_CLIENTE_AUX] WHERE ID=@ID_Deseado)
	SET @Direccion = (SELECT Direccion FROM [EL_PUNTERO].[TL_CLIENTE_AUX] WHERE ID=@ID_Deseado)
	SET @Telefono = (SELECT Telefono FROM [EL_PUNTERO].[TL_CLIENTE_AUX] WHERE ID=@ID_Deseado)
	SET @Fecha_Nacimiento = (SELECT Fecha_Nacimiento FROM [EL_PUNTERO].[TL_CLIENTE_AUX] WHERE ID=@ID_Deseado)
	SET @Mail = (SELECT Mail FROM [EL_PUNTERO].[TL_CLIENTE_AUX] WHERE ID=@ID_Deseado)

	SET @ID_Cliente = (SELECT ID_Cliente FROM [EL_PUNTERO].[TL_CLIENTE] WHERE 
			Nro_Documento = (SELECT CA.Nro_Documento FROM [EL_PUNTERO].[TL_CLIENTE_AUX] CA WHERE CA.ID=@ID_Deseado) AND
			Apellido = (SELECT CA.Apellido FROM [EL_PUNTERO].[TL_CLIENTE_AUX] CA WHERE CA.ID=@ID_Deseado) AND
			Nombre = (SELECT CA.Nombre FROM [EL_PUNTERO].[TL_CLIENTE_AUX] CA WHERE CA.ID=@ID_Deseado))
	
	IF(@Cant=1)
	BEGIN
		--Actualizo al pasajero si existe en la tabla principal
		UPDATE [EL_PUNTERO].[TL_CLIENTE] SET Direccion=@Direccion,Telefono=@Telefono,Fecha_Nacimiento=@Fecha_Nacimiento,Mail=@Mail
		WHERE ID_Cliente = @ID_Cliente
	END

	IF(@Cant=0) 
	BEGIN
		--Inserto al pasajero si no existe en la tabla principal
		INSERT INTO [EL_PUNTERO].[TL_CLIENTE] (Nombre,Apellido,ID_Tipo_Documento,Nro_Documento,Direccion,Telefono,Fecha_Nacimiento,Mail)
			VALUES (@Nombre,@Apellido,@ID_Tipo_Documento,@Nro_Documento,@Direccion,@Telefono,@Fecha_Nacimiento,@Mail)		

		SET @ID_Cliente = (SELECT ID_Cliente FROM [EL_PUNTERO].[TL_CLIENTE] WHERE 
			Nro_Documento = (SELECT CA.Nro_Documento FROM [EL_PUNTERO].[TL_CLIENTE_AUX] CA WHERE CA.ID=@ID_Deseado) AND
			Apellido = (SELECT CA.Apellido FROM [EL_PUNTERO].[TL_CLIENTE_AUX] CA WHERE CA.ID=@ID_Deseado) AND
			Nombre = (SELECT CA.Nombre FROM [EL_PUNTERO].[TL_CLIENTE_AUX] CA WHERE CA.ID=@ID_Deseado))
	END
	
	--Creo el nuevo pasaje con el ID_Compra en NULL
	SET @MaxPasaje = (SELECT MAX(Codigo_Pasaje) FROM [EL_PUNTERO].[TL_PASAJE])
	SET @ID_Butaca = (SELECT ID_Butaca FROM [EL_PUNTERO].[TL_CLIENTE_AUX] WHERE ID=@ID_Deseado)
	
	INSERT INTO [EL_PUNTERO].[TL_PASAJE] (Codigo_Pasaje,ID_Viaje,ID_Butaca,ID_Cliente,Precio)
		VALUES (@MaxPasaje+1,@ID_Viaje,@ID_Butaca,@ID_Cliente,@Precio_Pasajes)
	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GuardarAlQuePaga]
@Apellido nvarchar(255),
@Direccion nvarchar(255),
@Fecha_Nacimiento datetime,
@ID_Tipo_Documento int,
@Mail nvarchar(255),
@Nombre nvarchar(255),
@Nro_Documento int,
@Telefono nvarchar(255)

AS
BEGIN
	DECLARE @Cant int
	SET @Cant = (SELECT COUNT(*) FROM [EL_PUNTERO].[TL_CLIENTE] WHERE Nombre=@Nombre AND Apellido=@Apellido AND Nro_Documento=@Nro_Documento)

	IF (@Cant=0)
	BEGIN
		INSERT INTO [EL_PUNTERO].[TL_CLIENTE] (Nombre,Apellido,ID_Tipo_Documento,Nro_Documento,Direccion,Telefono,Fecha_Nacimiento,Mail)
			VALUES (@Nombre,@Apellido,@ID_Tipo_Documento,@Nro_Documento,@Direccion,@Telefono,@Fecha_Nacimiento,@Mail)	
	END
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GuardarTarjetaYCompra]
@Apellido nvarchar(255),
@Nombre nvarchar(255),
@Nro_Documento int,
@ID_Tipo_Tarjeta int,
@Nro_Tarjeta int,
@Cant_Cuotas int,
@ID_Viaje int,
@KG int,
@Precio_Encomienda numeric(18,2),
@ID_Usuario int
AS
BEGIN
	DECLARE @ID_Cliente int
	DECLARE @Cant int
	DECLARE @ID_Tarjeta int
	DECLARE @MaxEncomienda int
	DECLARE @ID_Compra int
	SET @ID_Cliente = (SELECT ID_Cliente FROM [EL_PUNTERO].[TL_CLIENTE] WHERE Nombre=@Nombre AND Apellido=@Apellido AND Nro_Documento=@Nro_Documento)
	SET @Cant = (SELECT COUNT(*) FROM [EL_PUNTERO].[TL_TARJETA] WHERE Nro_Tarjeta=@Nro_Tarjeta AND @ID_Cliente=ID_Cliente AND @ID_Tipo_Tarjeta=ID_Tipo_Tarjeta)

	IF(@Cant=0)
	BEGIN
		INSERT INTO [EL_PUNTERO].[TL_TARJETA] (Nro_Tarjeta,ID_Cliente,ID_Tipo_Tarjeta)
			VALUES (@Nro_Tarjeta,@ID_Cliente,@ID_Tipo_Tarjeta)
	END

	SET @ID_Tarjeta = (SELECT ID_Tarjeta FROM [EL_PUNTERO].[TL_TARJETA] WHERE Nro_Tarjeta=@Nro_Tarjeta AND @ID_Cliente=ID_Cliente AND @ID_Tipo_Tarjeta=ID_Tipo_Tarjeta)

	INSERT INTO [EL_PUNTERO].[TL_COMPRA] (ID_Cliente,Fecha_Compra,ID_Tarjeta,ID_Usuario,Cantidad_Cuotas)
		VALUES(@ID_Cliente,GETDATE(),@ID_Tarjeta,@ID_Usuario,@Cant_Cuotas)

	UPDATE EL_PUNTERO.TL_COMPRA
		SET PNR = ID_Compra 

	SET @MaxEncomienda = (SELECT MAX(Codigo_Encomienda) FROM [EL_PUNTERO].[TL_ENCOMIENDA])
	SET @ID_Compra = (SELECT MAX(ID_Compra) FROM [EL_PUNTERO].[TL_COMPRA])

	IF(@KG>0)
	BEGIN
		INSERT INTO [EL_PUNTERO].[TL_ENCOMIENDA] (Codigo_Encomienda,ID_Compra,ID_Viaje,KG,Precio)
			VALUES(@MaxEncomienda+1,@ID_Compra,@ID_Viaje,@KG,@Precio_Encomienda)
	END

	UPDATE EL_PUNTERO.TL_PASAJE SET ID_Compra=@ID_Compra
	WHERE ID_Compra is NULL

END
GO

CREATE PROCEDURE [EL_PUNTERO].[GuardarCompraEnEfectivo]
@Apellido nvarchar(255),
@Nombre nvarchar(255),
@Nro_Documento int,
@ID_Viaje int,
@KG int,
@Precio_Encomienda numeric(18,2),
@ID_Usuario int
AS
BEGIN
	DECLARE @ID_Cliente int
	DECLARE @MaxEncomienda int
	DECLARE @ID_Compra int

	SET @ID_Cliente = (SELECT ID_Cliente FROM [EL_PUNTERO].[TL_CLIENTE] WHERE Nombre=@Nombre AND Apellido=@Apellido AND Nro_Documento=@Nro_Documento)

	INSERT INTO [EL_PUNTERO].[TL_COMPRA] (ID_Cliente,Fecha_Compra,ID_Usuario)
		VALUES(@ID_Cliente,GETDATE(),@ID_Usuario)

	UPDATE EL_PUNTERO.TL_COMPRA
		SET PNR = ID_Compra 

	SET @MaxEncomienda = (SELECT MAX(Codigo_Encomienda) FROM [EL_PUNTERO].[TL_ENCOMIENDA])
	SET @ID_Compra = (SELECT MAX(ID_Compra) FROM [EL_PUNTERO].[TL_COMPRA])

	IF(@KG>0)
	BEGIN
		INSERT INTO [EL_PUNTERO].[TL_ENCOMIENDA] (Codigo_Encomienda,ID_Compra,ID_Viaje,KG,Precio)
			VALUES(@MaxEncomienda+1,@ID_Compra,@ID_Viaje,@KG,@Precio_Encomienda)
	END

	UPDATE EL_PUNTERO.TL_PASAJE SET ID_Compra=@ID_Compra
	WHERE ID_Compra is NULL

END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerPNR]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 1 ID_Compra
	FROM [EL_PUNTERO].[TL_COMPRA] 
	ORDER BY PNR DESC
END
GO

COMMIT
