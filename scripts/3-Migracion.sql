 BEGIN TRANSACTION
 INSERT INTO EL_PUNTERO.TL_CLIENTE (Nombre,Apellido,ID_Tipo_Documento,Nro_Documento,Mail,Telefono,Direccion,Fecha_Nacimiento)
	  (SELECT DISTINCT [Cli_Nombre]
	  ,[Cli_Apellido]
	  ,1
	  ,[Cli_Dni]
      ,[Cli_Mail]
      ,[Cli_Telefono]
      ,[Cli_Dir]
      ,[Cli_Fecha_Nac]
 FROM gd_esquema.Maestra);
 COMMIT

 BEGIN TRANSACTION
 INSERT INTO EL_PUNTERO.TL_SERVICIO (Nombre)
	  (SELECT DISTINCT [Tipo_Servicio]
		FROM gd_esquema.Maestra);

 UPDATE EL_PUNTERO.TL_SERVICIO
 SET Porcentaje = CASE WHEN Nombre = 'Cama' THEN 10
					   WHEN Nombre = 'Semi-Cama' THEN 5
					   WHEN Nombre = 'Ejecutivo' THEN 15
					   WHEN Nombre = 'Premium' THEN 20
					   WHEN Nombre = 'Común' THEN 0
END 
COMMIT

BEGIN TRANSACTION
INSERT INTO EL_PUNTERO.TL_AERONAVE (Matricula,Fabricante,Modelo,ID_Servicio,Baja_Por_Fuera_De_Servicio,Baja_Por_Vida_Util,Fecha_Fuera_De_Servicio,Fecha_Reinicio_Servicio,Fecha_Baja_Defenitiva,Fecha_Alta,KG_Totales)
(SELECT DISTINCT [Aeronave_Matricula]
	  ,[Aeronave_Fabricante]
	  ,[Aeronave_Modelo]
	  ,(SELECT [ID_Servicio] FROM [EL_PUNTERO].[TL_SERVICIO] WHERE Nombre = gd_esquema.Maestra.Tipo_Servicio)
      ,NULL
      ,NULL
      ,NULL
      ,NULL
	  ,NULL
	  ,NULL
	  ,[Aeronave_KG_Disponibles]
 FROM gd_esquema.Maestra);
 COMMIT

 BEGIN TRANSACTION
 INSERT INTO EL_PUNTERO.TL_BUTACA(Nro_Butaca,ID_Tipo_Butaca,Piso_Butaca,ID_Aeronave)
	  (SELECT DISTINCT [Butaca_Nro]
	  ,(SELECT TOP 1 [ID_Tipo_Butaca] FROM [EL_PUNTERO].[TL_TIPO_BUTACA] WHERE Descripcion = gd_esquema.Maestra.Butaca_Tipo)
	  ,[Butaca_Piso]
	  ,(SELECT [ID_Aeronave] FROM [EL_PUNTERO].[TL_AERONAVE] WHERE Matricula = gd_esquema.Maestra.Aeronave_Matricula)
 FROM gd_esquema.Maestra
 WHERE gd_esquema.Maestra.Butaca_Nro != 0);

 COMMIT


