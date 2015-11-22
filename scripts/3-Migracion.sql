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
 SET Porcentaje = CASE WHEN Nombre = 'Ejecutivo' THEN 50
					   WHEN Nombre = 'Turista' THEN 20
					   WHEN Nombre = 'Primera Clase' THEN 100
END 
COMMIT

BEGIN TRANSACTION
INSERT INTO EL_PUNTERO.TL_AERONAVE (Matricula,Fabricante,Modelo,ID_Servicio,Fecha_Baja_Definitiva,KG_Totales)
(SELECT DISTINCT [Aeronave_Matricula]
	  ,[Aeronave_Fabricante]
	  ,[Aeronave_Modelo]
	  ,(SELECT [ID_Servicio] FROM [EL_PUNTERO].[TL_SERVICIO] WHERE Nombre = gd_esquema.Maestra.Tipo_Servicio)
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
 WHERE gd_esquema.Maestra.Butaca_Tipo is not null AND gd_esquema.Maestra.Pasaje_Codigo != 0);
 COMMIT

 BEGIN TRANSACTION
 INSERT INTO EL_PUNTERO.TL_CIUDAD(Nombre_Ciudad)
 (SELECT SUBSTRING([Ruta_Ciudad_Origen],2,LEN([Ruta_Ciudad_Origen])-1) FROM gd_esquema.Maestra UNION SELECT SUBSTRING([Ruta_Ciudad_Destino],2,LEN([Ruta_Ciudad_Destino])-1) FROM gd_esquema.Maestra);
 COMMIT

 BEGIN TRANSACTION
 INSERT INTO EL_PUNTERO.TL_RUTA(Codigo_Ruta,ID_Ciudad_Origen,ID_Ciudad_Destino)
 (SELECT DISTINCT [Ruta_Codigo],
		 (SELECT ID_Ciudad FROM EL_PUNTERO.TL_CIUDAD WHERE Nombre_Ciudad = SUBSTRING((gd_esquema.Maestra.Ruta_Ciudad_Origen),2,LEN(gd_esquema.Maestra.Ruta_Ciudad_Origen)-1)),
		 (SELECT ID_Ciudad FROM EL_PUNTERO.TL_CIUDAD WHERE Nombre_Ciudad = SUBSTRING((gd_esquema.Maestra.Ruta_Ciudad_Destino),2,LEN(gd_esquema.Maestra.Ruta_Ciudad_Destino)-1))
 FROM gd_esquema.Maestra);
 COMMIT

BEGIN TRANSACTION
INSERT INTO EL_PUNTERO.TL_SERVICIO_RUTA(ID_Servicio,ID_Ruta)
(SELECT DISTINCT (SELECT ID_Servicio FROM EL_PUNTERO.TL_SERVICIO WHERE Nombre = M.Tipo_Servicio),
				  (SELECT ID_Ruta FROM EL_PUNTERO.TL_RUTA R WHERE 
				  (R.ID_Ciudad_Origen = (SELECT ID_Ciudad 
										FROM EL_PUNTERO.TL_CIUDAD C
										WHERE C.Nombre_Ciudad = SUBSTRING((M.Ruta_Ciudad_Origen),2,LEN(M.Ruta_Ciudad_Origen)-1))) 
				  AND R.ID_Ciudad_Destino = (SELECT ID_Ciudad 
											FROM EL_PUNTERO.TL_CIUDAD C
											WHERE C.Nombre_Ciudad = SUBSTRING((M.Ruta_Ciudad_Destino),2,LEN(M.Ruta_Ciudad_Destino)-1)))
 FROM gd_esquema.Maestra M)
COMMIT

BEGIN TRANSACTION
UPDATE EL_PUNTERO.TL_RUTA
 SET Precio_Base_KG = Ruta_Precio_BaseKG FROM gd_esquema.Maestra M, EL_PUNTERO.TL_RUTA
 WHERE		Ruta_Codigo=Codigo_Ruta AND 
			SUBSTRING((M.Ruta_Ciudad_Origen),2,LEN(M.Ruta_Ciudad_Origen)-1) = (SELECT Nombre_Ciudad FROM EL_PUNTERO.TL_CIUDAD WHERE ID_Ciudad = ID_Ciudad_Origen) AND 
			SUBSTRING((M.Ruta_Ciudad_Destino),2,LEN(M.Ruta_Ciudad_Destino)-1) = (SELECT Nombre_Ciudad FROM EL_PUNTERO.TL_CIUDAD WHERE ID_Ciudad = ID_Ciudad_Destino) AND  
			M.Ruta_Precio_BaseKG != 0

UPDATE EL_PUNTERO.TL_RUTA
 SET Precio_Base_Pasaje = Ruta_Precio_BasePasaje FROM gd_esquema.Maestra M, EL_PUNTERO.TL_RUTA
 WHERE		Ruta_Codigo= Codigo_Ruta AND 
			SUBSTRING((M.Ruta_Ciudad_Origen),2,LEN(M.Ruta_Ciudad_Origen)-1) = (SELECT Nombre_Ciudad FROM EL_PUNTERO.TL_CIUDAD WHERE ID_Ciudad = ID_Ciudad_Origen) AND 
			SUBSTRING((M.Ruta_Ciudad_Destino),2,LEN(M.Ruta_Ciudad_Destino)-1) = (SELECT Nombre_Ciudad FROM EL_PUNTERO.TL_CIUDAD WHERE ID_Ciudad = ID_Ciudad_Destino) AND  
			M.Ruta_Precio_BasePasaje != 0

ALTER TABLE EL_PUNTERO.TL_RUTA
ALTER COLUMN Precio_Base_KG 
numeric(18,2) NOT NULL;

ALTER TABLE EL_PUNTERO.TL_RUTA
ALTER COLUMN Precio_Base_Pasaje 
numeric(18,2) NOT NULL;
COMMIT

 BEGIN TRANSACTION
 INSERT INTO EL_PUNTERO.TL_VIAJE (Fecha_Salida,Fecha_Llegada,Fecha_Llegada_Estimada,ID_Aeronave,ID_Ruta)
  (SELECT DISTINCT  [FechaSalida],
					[FechaLLegada],
					[Fecha_LLegada_Estimada],
					(SELECT [ID_Aeronave] FROM EL_PUNTERO.TL_AERONAVE WHERE Matricula= M.Aeronave_Matricula),
					(SELECT [ID_Ruta] FROM EL_PUNTERO.TL_RUTA WHERE M.Ruta_Codigo = Codigo_Ruta AND 
					SUBSTRING((M.Ruta_Ciudad_Origen),2,LEN(M.Ruta_Ciudad_Origen)-1) = (SELECT Nombre_Ciudad FROM EL_PUNTERO.TL_CIUDAD WHERE ID_Ciudad = ID_Ciudad_Origen) AND 
					SUBSTRING((M.Ruta_Ciudad_Destino),2,LEN(M.Ruta_Ciudad_Destino)-1) = (SELECT Nombre_Ciudad FROM EL_PUNTERO.TL_CIUDAD WHERE ID_Ciudad = ID_Ciudad_Destino))
 FROM gd_esquema.Maestra M);
 COMMIT
 
 BEGIN TRANSACTION
 INSERT INTO EL_PUNTERO.TL_COMPRA(ID_Cliente,Fecha_Compra,ID_Usuario,ID_Tarjeta,Cantidad_Cuotas,Codigo_Pasaje,Codigo_Paquete)
 (SELECT (SELECT ID_Cliente FROM EL_PUNTERO.TL_CLIENTE 
			 WHERE Nro_Documento = Cli_Dni AND Apellido = Cli_Apellido AND Nombre = Cli_Nombre),
		 (CASE WHEN Pasaje_FechaCompra = '1900-01-01 00:00:00.000' THEN Paquete_FechaCompra
			 WHEN Paquete_FechaCompra = '1900-01-01 00:00:00.000'  THEN Pasaje_FechaCompra
		  END),
		  1,
		  NULL,
		  NULL,
		 [Pasaje_Codigo],
		 [Paquete_Codigo]
 FROM gd_esquema.Maestra);

 UPDATE EL_PUNTERO.TL_COMPRA
 SET PNR = ID_Compra 
COMMIT

BEGIN TRANSACTION
INSERT INTO EL_PUNTERO.TL_ENCOMIENDA(Codigo_Encomienda,Precio,ID_Compra,ID_Viaje,KG)
(SELECT DISTINCT [Paquete_Codigo],
				 [Paquete_Precio],
				 (SELECT ID_Compra FROM EL_PUNTERO.TL_COMPRA C WHERE C.Codigo_Paquete = Paquete_Codigo),
				 (SELECT TOP 1 ID_Viaje FROM EL_PUNTERO.TL_VIAJE WHERE ID_Aeronave = (SELECT ID_Aeronave FROM EL_PUNTERO.TL_AERONAVE WHERE Matricula = Aeronave_Matricula AND Fecha_Salida = FechaSalida)),
				 [Paquete_KG]				 
FROM gd_esquema.Maestra
WHERE Paquete_Codigo != 0);
COMMIT

BEGIN TRANSACTION
INSERT INTO EL_PUNTERO.TL_PASAJE(Codigo_Pasaje,Precio,ID_Cliente,ID_Butaca,ID_Viaje,Id_Compra)
(SELECT DISTINCT [Pasaje_Codigo],
				 [Pasaje_Precio],
				 (SELECT ID_Cliente FROM EL_PUNTERO.TL_CLIENTE WHERE Nro_Documento = Cli_Dni AND Nombre = Cli_Nombre AND Apellido = Cli_Apellido),
				 (SELECT TOP 1 ID_Butaca FROM EL_PUNTERO.TL_BUTACA WHERE ID_Aeronave = 
					(SELECT TOP 1 ID_Aeronave FROM EL_PUNTERO.TL_AERONAVE WHERE Pasaje_Codigo != 0 AND Matricula = Aeronave_Matricula AND Nro_Butaca = Butaca_Nro)),
				 (SELECT TOP 1 ID_Viaje FROM EL_PUNTERO.TL_VIAJE WHERE ID_Aeronave = 
					(SELECT TOP 1 ID_Aeronave FROM EL_PUNTERO.TL_AERONAVE WHERE Matricula = Aeronave_Matricula AND Fecha_Salida = FechaSalida)),
				 (SELECT ID_Compra FROM EL_PUNTERO.TL_COMPRA C WHERE C.Codigo_Pasaje = Pasaje_Codigo)
FROM gd_esquema.Maestra
WHERE Pasaje_Codigo != 0);
COMMIT

BEGIN TRANSACTION
ALTER TABLE EL_PUNTERO.TL_COMPRA
DROP COLUMN Codigo_Pasaje

ALTER TABLE EL_PUNTERO.TL_COMPRA
DROP COLUMN Codigo_Paquete
COMMIT

 




