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