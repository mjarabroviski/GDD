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
	SELECT DISTINCT * 
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
	SELECT S.*
	FROM [EL_PUNTERO].[TL_SERVICIO] S, [EL_PUNTERO].[TL_SERVICIO_RUTA] SR
	WHERE S.ID_Servicio = SR.ID_Servicio
	AND SR.ID_Ruta = (SELECT R.ID_Ruta FROM EL_PUNTERO.TL_RUTA R WHERE R.ID_Ciudad_Destino = @ID_Ciudad_Destino AND R.ID_Ciudad_Origen = @ID_Ciudad_Origen)
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

CREATE FUNCTION [EL_PUNTERO].[ValidarFechasViaje](@ID_Viaje int,@FechaDesde datetime,@FechaHasta datetime)
RETURNS int
AS
BEGIN
	DECLARE @ViajeDesde datetime
	DECLARE @ViajeHasta datetime
	DECLARE @resul int

	SET @ViajeDesde = (SELECT V.Fecha_Salida FROM [EL_PUNTERO].TL_VIAJE V WHERE V.ID_Viaje=@ID_Viaje)

	SET @ViajeHasta = (SELECT V.Fecha_Llegada_Estimada FROM [EL_PUNTERO].TL_VIAJE V WHERE V.ID_Viaje=@ID_Viaje)

	SET @resul = 0
	IF ((@ViajeDesde>=@FechaDesde) AND (@ViajeDesde<=@FechaHasta)) OR ((@ViajeHasta>=@FechaDesde) AND (@ViajeHasta<=@FechaHasta))
	BEGIN
		SET @resul = 1
	END
	RETURN @resul
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
	WHERE V.ID_Aeronave = @ID_Aeronave
	AND EL_PUNTERO.ValidarFechasViaje(V.ID_Viaje,@Fecha_Salida,@Fecha_Llegada_Estimada) = 1

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
	WHERE DATEPART(year,V.Fecha_Salida) = DATEPART(year, @Fecha_Salida) 
    and DATEPART(month, V.Fecha_Salida) = DATEPART(month, @Fecha_Salida) 
    and DATEPART(day,V.Fecha_Salida)= DATEPART(day, @Fecha_Salida) 
	and DATEPART(hour,V.Fecha_Salida)= DATEPART(hour, @Fecha_Salida) 
	and DATEPART(minute,V.Fecha_Salida)= DATEPART(minute, @Fecha_Salida) 
	and DATEPART(second ,V.Fecha_Salida)= DATEPART(second, @Fecha_Salida) AND V.ID_Ruta = @ID_Ruta
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
	WHERE DATEPART(year,V.Fecha_Salida) = DATEPART(year, @Fecha_Salida) 
    and DATEPART(month, V.Fecha_Salida) = DATEPART(month, @Fecha_Salida) 
    and DATEPART(day,V.Fecha_Salida)= DATEPART(day, @Fecha_Salida) 
	and DATEPART(hour,V.Fecha_Salida)= DATEPART(hour, @Fecha_Salida) 
	and DATEPART(minute,V.Fecha_Salida)= DATEPART(minute, @Fecha_Salida) 
	and DATEPART(second ,V.Fecha_Salida)= DATEPART(second, @Fecha_Salida) 
	and V.ID_Ruta = @ID_Ruta 
	AND V.ID_Aeronave = @ID_Aeronave
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
@ID_Cliente int,
@Fecha_Sistema datetime
AS 
BEGIN
	SELECT * 
	FROM EL_PUNTERO.TL_ENCOMIENDA E 
	INNER JOIN EL_PUNTERO.TL_COMPRA C ON C.ID_Compra = E.ID_Compra
	WHERE C.ID_Cliente = @ID_Cliente 
		  AND (SELECT V.Fecha_Salida 
				FROM EL_PUNTERO.TL_VIAJE V
				WHERE E.ID_Viaje = V.ID_Viaje) > @Fecha_Sistema
		   AND E.ID_Encomienda NOT IN (SELECT DE.ID_Encomienda
										FROM EL_PUNTERO.TL_DEVOLUCION_ENCOMIENDA DE
										WHERE DE.ID_Encomienda = E.ID_Encomienda)
	ORDER BY E.Codigo_Encomienda
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ObtenerPasajesFuturos]
@ID_Cliente int,
@Fecha_Sistema datetime
AS 
BEGIN
	SELECT * 
	FROM EL_PUNTERO.TL_PASAJE p 
	INNER JOIN EL_PUNTERO.TL_COMPRA C ON C.ID_Compra = P.ID_Compra
	WHERE C.ID_Cliente = @ID_Cliente 
		  AND (SELECT V.Fecha_Salida 
				FROM EL_PUNTERO.TL_VIAJE V
				WHERE P.ID_Viaje = V.ID_Viaje) > @Fecha_Sistema
	AND P.ID_Pasaje NOT IN (SELECT DP.ID_Pasaje
								FROM EL_PUNTERO.TL_DEVOLUCION_PASAJE DP
								WHERE DP.ID_Pasaje = P.ID_Pasaje)
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

CREATE PROCEDURE [EL_PUNTERO].ObtenerNombreClientePorID
@ID_Cliente int
AS 
BEGIN
	SELECT *
	FROM EL_PUNTERO.TL_CLIENTE C
	WHERE C.ID_Cliente = @ID_Cliente
END
GO

CREATE PROCEDURE [EL_PUNTERO].ObtenerServicioAeronave
@ID_Aeronave int
AS 
BEGIN
	SELECT S.*
	FROM EL_PUNTERO.TL_SERVICIO S, EL_PUNTERO.TL_AERONAVE A
	WHERE A.ID_Servicio= S.ID_Servicio AND A.ID_Aeronave= @ID_Aeronave
END
GO

CREATE PROCEDURE [EL_PUNTERO].ObtenerCiudadesOrigenParaUnServicio
@ID_Servicio int
AS 
BEGIN
	SELECT DISTINCT C.*
	FROM EL_PUNTERO.TL_SERVICIO_RUTA SR, EL_PUNTERO.TL_CIUDAD C, EL_PUNTERO.TL_RUTA R
	WHERE SR.ID_Servicio = @ID_Servicio 
	      AND SR.ID_Ruta = R.ID_Ruta
		  AND R.ID_Ciudad_Origen = C.ID_Ciudad
	ORDER BY C.Nombre_Ciudad
END
GO

CREATE PROCEDURE [EL_PUNTERO].InsertarDevolucionEncomienda
@ID_Encomienda int,
@Motivo varchar(100),
@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;
	
	--Inserto los id_encomienda del viaje de la ruta que viene por parametro 
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION_ENCOMIENDA] (ID_Encomienda,Fecha_Devolucion,Motivo,ID_Usuario)
	VALUES (@ID_Encomienda,GETDATE(),@Motivo,@ID_Usuario)
END
GO

CREATE PROCEDURE [EL_PUNTERO].InsertarDevolucionPasaje
@ID_Pasaje int,
@Motivo varchar(100),
@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;
	
	--Inserto los id_encomienda del viaje de la ruta que viene por parametro 
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION_PASAJE] (ID_Pasaje,Fecha_Devolucion,Motivo,ID_Usuario)
	VALUES (@ID_Pasaje,GETDATE(),@Motivo,@ID_Usuario)
END
GO

CREATE PROCEDURE [EL_PUNTERO].DevolverTodosLosPasajes
@ID_Cliente int,
@Motivo varchar(100),
@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;

	--Inserto los id_encomienda del viaje de la ruta que viene por parametro 
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION_PASAJE] (ID_Pasaje)
	SELECT P.ID_Pasaje
	FROM EL_PUNTERO.TL_PASAJE P
	INNER JOIN EL_PUNTERO.TL_COMPRA C ON C.ID_Compra = P.ID_Compra
	WHERE C.ID_Cliente = @ID_Cliente 
		  AND (SELECT V.Fecha_Salida 
				FROM EL_PUNTERO.TL_VIAJE V
				WHERE P.ID_Viaje = V.ID_Viaje) > GETDATE()
	AND P.ID_Pasaje NOT IN (SELECT DP.ID_Pasaje
								FROM EL_PUNTERO.TL_DEVOLUCION_PASAJE DP
								WHERE DP.ID_Pasaje = P.ID_Pasaje)

	--Se llenan la fecha, el motivo y el usuario de los pasajes
	UPDATE [EL_PUNTERO].TL_DEVOLUCION_PASAJE
	SET Fecha_Devolucion=GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;

END
GO

CREATE PROCEDURE [EL_PUNTERO].DevolverTodasLasEncomiendas
@ID_Cliente int,
@Motivo varchar(100),
@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;

	--Inserto los id_encomienda del viaje de la ruta que viene por parametro 
	INSERT INTO [EL_PUNTERO].[TL_DEVOLUCION_ENCOMIENDA] (ID_Encomienda)
	(SELECT E.ID_Encomienda
	FROM EL_PUNTERO.TL_ENCOMIENDA E 
	INNER JOIN EL_PUNTERO.TL_COMPRA C ON C.ID_Compra = E.ID_Compra
	WHERE C.ID_Cliente = @ID_Cliente 
	AND (SELECT V.Fecha_Salida 
		 FROM EL_PUNTERO.TL_VIAJE V
		 WHERE E.ID_Viaje = V.ID_Viaje) > GETDATE()
	AND E.ID_Encomienda NOT IN (SELECT DE.ID_Encomienda
								FROM EL_PUNTERO.TL_DEVOLUCION_ENCOMIENDA DE
								WHERE DE.ID_Encomienda = E.ID_Encomienda))

	--Se llenan la fecha, el motivo y el usuario de las encomiendas
	UPDATE [EL_PUNTERO].TL_DEVOLUCION_ENCOMIENDA
	SET Fecha_Devolucion= GETDATE(),
		Motivo=@Motivo,
		ID_Usuario=@ID_Usuario
	WHERE Fecha_Devolucion is NULL;
END
GO

COMMIT