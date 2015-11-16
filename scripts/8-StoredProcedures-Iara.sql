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

CREATE PROCEDURE [EL_PUNTERO].[GetAeronaves]
AS
BEGIN
	SET NOCOUNT ON;
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

------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [EL_PUNTERO].[ObtenerEncomiendasFuturas]
@ID_Cliente int
AS 
BEGIN
	SELECT * 
	FROM EL_PUNTERO.TL_ENCOMIENDA E 
	INNER JOIN EL_PUNTERO.TL_COMPRA C ON C.ID_Compra = E.ID_Compra
	WHERE C.ID_Cliente = @ID_Cliente 
		  AND (SELECT V.Fecha_Salida 
				FROM EL_PUNTERO.TL_VIAJE V
				WHERE E.ID_Viaje = V.ID_Viaje) > GETDATE()
END
GO
CREATE PROCEDURE [EL_PUNTERO].[ObtenerPasajesFuturos]
@ID_Cliente int
AS 
BEGIN
	SELECT * 
	FROM EL_PUNTERO.TL_PASAJE p 
	INNER JOIN EL_PUNTERO.TL_COMPRA C ON C.ID_Compra = P.ID_Compra
	WHERE C.ID_Cliente = @ID_Cliente 
		  AND (SELECT V.Fecha_Salida 
				FROM EL_PUNTERO.TL_VIAJE V
				WHERE P.ID_Viaje = V.ID_Viaje) > GETDATE()
	ORDER BY P.Codigo_Pasaje
END
GO
CREATE PROCEDURE [EL_PUNTERO].ObtenerRutaDeEncomienda
@ID_Encomienda int
AS
BEGIN
	SELECT * 
	FROM [EL_PUNTERO].[TL_RUTA] R
	INNER JOIN EL_PUNTERO.TL_VIAJE V ON V.ID_Ruta = R.ID_Ruta
	INNER JOIN EL_PUNTERO.TL_ENCOMIENDA E ON V.ID_Viaje = E.ID_Viaje
	WHERE  E.ID_Encomienda = @ID_Encomienda
	ORDER BY E.Codigo_Encomienda
END
GO
CREATE PROCEDURE [EL_PUNTERO].ObtenerFechaSalidaDeEncomienda
@ID_Encomienda int
AS
BEGIN
	SELECT * 
	FROM EL_PUNTERO.TL_VIAJE V
	INNER JOIN EL_PUNTERO.TL_ENCOMIENDA E ON E.ID_Viaje = V.ID_Viaje
	WHERE  E.ID_Encomienda = @ID_Encomienda
END
GO
CREATE PROCEDURE [EL_PUNTERO].ObtenerRutaDePasaje
@ID_Pasaje int
AS
BEGIN
	SELECT * 
	FROM [EL_PUNTERO].[TL_RUTA] R
	INNER JOIN EL_PUNTERO.TL_VIAJE V ON V.ID_Ruta = R.ID_Ruta
	INNER JOIN EL_PUNTERO.TL_PASAJE P ON V.ID_Viaje = P.ID_Viaje
	WHERE  P.ID_Pasaje = @ID_Pasaje
END
GO
CREATE PROCEDURE [EL_PUNTERO].ObtenerFechaSalidaDePasaje
@ID_Pasaje int
AS
BEGIN
	SELECT * 
	FROM EL_PUNTERO.TL_VIAJE V
	INNER JOIN EL_PUNTERO.TL_PASAJE P ON V.ID_Viaje = P.ID_Viaje
	WHERE  P.ID_Pasaje = @ID_Pasaje
END
GO

CREATE PROCEDURE SPObtenerNombreClientePorID
@ID_Cliente int
AS 
BEGIN
	SELECT *
	FROM EL_PUNTERO.TL_CLIENTE C
	WHERE C.ID_Cliente = @ID_Cliente
END
GO

DROP PROCEDURE [EL_PUNTERO].[ObtenerPasajesFuturos]
DROP PROCEDURE [EL_PUNTERO].[ObtenerEncomiendasFuturas]

COMMIT