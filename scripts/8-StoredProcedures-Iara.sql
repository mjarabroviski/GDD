BEGIN TRANSACTION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [EL_PUNTERO].[InsertarCiudad]
@Nombre_Ciudad nvarchar(20)
AS
BEGIN

	INSERT INTO [EL_PUNTERO].[TL_CIUDAD](Nombre_Ciudad)
	VALUES(@Nombre_Ciudad)
	
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ActualizarCiudad]
@Nombre_Ciudad nvarchar(20),
@ID_Ciudad int
AS
BEGIN

	UPDATE [EL_PUNTERO].[TL_CIUDAD]
	SET Nombre_Ciudad = @Nombre_Ciudad
	WHERE ID_Ciudad = @iD_Ciudad; 
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

CREATE PROCEDURE [EL_PUNTERO].[GetCiudades]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [EL_PUNTERO].[TL_Ciudad]
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
	ORDER BY Nombre;
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


CREATE PROCEDURE [EL_PUNTERO].[ObtenerIDPorNombreDeCiudad]
@Nombre_Ciudad nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].[TL_CIUDAD]  
	WHERE Nombre_Ciudad = @Nombre_Ciudad
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
	INSERT INTO [EL_PUNTERO].[TL_VIAJE] (Fecha_Llegada,Fecha_Salida,Fecha_Llegada_Estimada,ID_Ruta,ID_Aeronave)
	VALUES (@Fecha_Llegada,@Fecha_Salida,@Fecha_Llegada_Estimada,@ID_Ruta,@ID_Aeronave);
END
GO

COMMIT
