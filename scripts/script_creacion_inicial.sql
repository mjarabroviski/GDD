--Creacion del schema y tablas
USE [GD2C2015]
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name='EL _PUNTERO')
BEGIN
EXEC ('CREATE SCHEMA [EL_PUNTERO] AUTHORIZATION [gd]');
END

GO
BEGIN TRANSACTION
CREATE TABLE [EL_PUNTERO].[TL_AERONAVE](
	[ID_Aeronave] int IDENTITY (1,1),
	[Matricula] nvarchar(7) UNIQUE,
	[Fabricante] nvarchar (30) NOT NULL,
	[Modelo] nvarchar(30) NOT NULL,
	[ID_Servicio] int NOT NULL,
	[Baja_Por_Fuera_De_Servicio] bit DEFAULT 0,
	[Baja_Por_Vida_Util] bit DEFAULT 0,
	[Fecha_Baja_Definitiva] datetime, 
	[Fecha_Alta] datetime NOT NULL DEFAULT '01/01/1990',
	[KG_Totales] int NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_BAJA_SERVICIO_AERONAVE](
	[ID_Baja_Servicio] int IDENTITY (1,1),
	[ID_Aeronave] int NOT NULL,
	[Fecha_Fuera_De_Servicio] datetime,
	[Fecha_Reinicio_Servicio] datetime, 
);

CREATE TABLE [EL_PUNTERO].[TL_PASAJE](
	[ID_Pasaje] int IDENTITY (1,1),
	[Codigo_Pasaje] int NOT NULL,
	[ID_Compra] int,
	[Precio] numeric(6,2) NOT NULL,
	[ID_Viaje] int NOT NULL,
	[ID_Butaca] int NOT NULL,
	[ID_Cliente] int NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_VIAJE](
	[ID_Viaje] int IDENTITY (1,1),
	[Fecha_Salida] datetime NOT NULL,
	[Fecha_Llegada] datetime NOT NULL,
	[Fecha_Llegada_Estimada] datetime NOT NULL,
	[ID_Ruta] int NOT NULL,
	[ID_Aeronave] int NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_CLIENTE](
	[ID_Cliente] int IDENTITY (1,1),
	[Nombre] nvarchar(255) NOT NULL,
	[Apellido] nvarchar(255) NOT NULL,
	[ID_Tipo_Documento] int NOT NULL,
	[Nro_Documento] int NOT NULL,
	[Mail] nvarchar(255),
	[Telefono] nvarchar(255) NOT NULL,
	[Direccion] nvarchar(255) NOT NULL,
	[Fecha_Nacimiento] datetime NOT NULL,
	[Millas] int DEFAULT 0
);

CREATE TABLE [EL_PUNTERO].[TL_TIPO_DOCUMENTO] (
	[ID_Tipo_Documento] int IDENTITY (1,1),
	[Descripcion] nvarchar(50) NOT NULL
);

INSERT INTO EL_PUNTERO.TL_TIPO_DOCUMENTO (Descripcion) VALUES ('DNI');
INSERT INTO EL_PUNTERO.TL_TIPO_DOCUMENTO (Descripcion) VALUES ('CI');
INSERT INTO EL_PUNTERO.TL_TIPO_DOCUMENTO (Descripcion) VALUES ('LC');
INSERT INTO EL_PUNTERO.TL_TIPO_DOCUMENTO (Descripcion) VALUES ('LE');

CREATE TABLE [EL_PUNTERO].[TL_USUARIO] (
	[ID_Usuario] int IDENTITY (1,1),
	[Username] nvarchar(255) UNIQUE,
	[Password] nvarchar(64) NOT NULL,
	[Habilitado] bit DEFAULT 1,
	[Cant_Intentos] int DEFAULT 3
);

CREATE TABLE [EL_PUNTERO].[TL_ROL_USUARIO](
	[ID_Rol_Usuario] int IDENTITY (1,1),
	[ID_Rol] int NOT NULL,
	[ID_Usuario] int NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_ROL](
	[ID_Rol] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL,
	[Habilitado] bit DEFAULT 1
);

--Inserto Roles
INSERT INTO EL_PUNTERO.TL_ROL (Descripcion) VALUES ('Cliente');
INSERT INTO EL_PUNTERO.TL_ROL (Descripcion) VALUES ('Administrador');
INSERT INTO EL_PUNTERO.TL_ROL (Descripcion) VALUES ('Administrador General');

--Inserto Usuarios
INSERT INTO EL_PUNTERO.TL_USUARIO (Username,Password,Cant_Intentos)
VALUES ('admin1','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3);
INSERT INTO EL_PUNTERO.TL_USUARIO (Username,Password,Cant_Intentos)
VALUES ('admin2','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3);
INSERT INTO EL_PUNTERO.TL_USUARIO (Username,Password,Cant_Intentos)
VALUES ('admin3','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3);
INSERT INTO EL_PUNTERO.TL_USUARIO (Username,Password,Cant_Intentos)
VALUES ('admin4','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3);
INSERT INTO EL_PUNTERO.TL_USUARIO (Username,Password,Cant_Intentos)
VALUES ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3);

--Inserto Roles por Usuario
INSERT INTO EL_PUNTERO.TL_ROL_USUARIO (ID_Rol,ID_Usuario)
VALUES(2,1)
INSERT INTO EL_PUNTERO.TL_ROL_USUARIO (ID_Rol,ID_Usuario)
VALUES(2,2)
INSERT INTO EL_PUNTERO.TL_ROL_USUARIO (ID_Rol,ID_Usuario)
VALUES(2,3)
INSERT INTO EL_PUNTERO.TL_ROL_USUARIO (ID_Rol,ID_Usuario)
VALUES(2,4)
INSERT INTO EL_PUNTERO.TL_ROL_USUARIO (ID_Rol,ID_Usuario)
VALUES(3,5)

CREATE TABLE [EL_PUNTERO].[TL_FUNCIONALIDAD](
	[ID_Funcionalidad] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL
);

INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('ABM de Rol');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('Registro de Usuario');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('ABM de Ciudad');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('ABM de Ruta Aerea');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('ABM de Aeronave');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('Generacion de Viaje');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('Registro de Llegada a Destino');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('Compra de pasaje/encomienda');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('Devolucion/Cancelacion de pasaje y/o encomienda');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('Consulta de millas de pasajero frecuente');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('Canje de Millas');
INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD(Descripcion) VALUES ('Listado Estadistico');

CREATE TABLE [EL_PUNTERO].[TL_FUNCIONALIDAD_ROL](
	[ID_Funcionalidad_Rol] int IDENTITY (1,1),
	[ID_Funcionalidad] int NOT NULL,
	[ID_Rol] int NOT NULL
);

INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD_ROL (ID_Rol, ID_Funcionalidad) (
		(SELECT ID_Rol, ID_Funcionalidad 
		FROM EL_PUNTERO.TL_Rol, EL_PUNTERO.TL_Funcionalidad
		WHERE EL_PUNTERO.TL_Rol.Descripcion = 'Cliente'
		AND (EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Compra de pasaje/encomienda'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Consulta de millas de pasajero frecuente'))
);

INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD_ROL (ID_Rol, ID_Funcionalidad) (
		(SELECT ID_Rol, ID_Funcionalidad 
		FROM EL_PUNTERO.TL_Rol, EL_PUNTERO.TL_Funcionalidad
		WHERE EL_PUNTERO.TL_Rol.Descripcion = 'Administrador'
		AND (EL_PUNTERO.TL_Funcionalidad.Descripcion = 'ABM de Rol'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Registro de Usuario'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'ABM de Ciudad'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'ABM de Ruta Aerea'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'ABM de Aeronave'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Generacion de Viaje'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Registro de Llegada a Destino'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Compra de pasaje/encomienda'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Devolucion/Cancelacion de pasaje y/o encomienda'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Canje de Millas'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Listado Estadistico'))
);

INSERT INTO EL_PUNTERO.TL_FUNCIONALIDAD_ROL (ID_Rol, ID_Funcionalidad) (
		(SELECT ID_Rol, ID_Funcionalidad 
		FROM EL_PUNTERO.TL_Rol, EL_PUNTERO.TL_Funcionalidad
		WHERE EL_PUNTERO.TL_Rol.Descripcion = 'Administrador General'
		AND (EL_PUNTERO.TL_Funcionalidad.Descripcion = 'ABM de Rol'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Registro de Usuario'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'ABM de Ciudad'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'ABM de Ruta Aerea'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'ABM de Aeronave'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Generacion de Viaje'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Registro de Llegada a Destino'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Compra de pasaje/encomienda'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Devolucion/Cancelacion de pasaje y/o encomienda'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Consulta de millas de pasajero frecuente'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Canje de Millas'
		OR EL_PUNTERO.TL_Funcionalidad.Descripcion = 'Listado Estadistico'))
);

CREATE TABLE [EL_PUNTERO].[TL_SERVICIO](
	[ID_Servicio] int IDENTITY(1,1),
	[Nombre] nvarchar(255) NOT NULL,
	[Porcentaje] numeric(5,2) DEFAULT 0
);

CREATE TABLE [EL_PUNTERO].[TL_RUTA](
	[ID_Ruta] int IDENTITY(1,1),
	[Codigo_Ruta] int NOT NULL,
	[ID_Ciudad_Origen] int NOT NULL,
	[ID_Ciudad_Destino] int NOT NULL,
	[Precio_Base_KG] numeric(18,2),
	[Precio_Base_Pasaje] numeric(18,2),
	[Habilitado] int DEFAULT 1
);

CREATE TABLE [EL_PUNTERO].[TL_SERVICIO_RUTA](
	[ID_Servicio_Ruta] int IDENTITY (1,1),
	[ID_Servicio] int NOT NULL,
	[ID_Ruta] int NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_CIUDAD](
	[ID_Ciudad] int IDENTITY(1,1),
	[Nombre_Ciudad] nvarchar(20) NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_BUTACA](
	[ID_Butaca] int IDENTITY(1,1),
	[Nro_Butaca] int NOT NULL,
	[ID_Tipo_Butaca] int,
	[Piso_Butaca] int DEFAULT 1,
	[ID_Aeronave] int NOT NULL,
	[Habilitado] bit DEFAULT 1
);

CREATE TABLE [EL_PUNTERO].[TL_TIPO_BUTACA](
	[ID_Tipo_Butaca] int IDENTITY(1,1),
	[Descripcion] nvarchar(30) NOT NULL
);

INSERT INTO EL_PUNTERO.TL_TIPO_BUTACA (Descripcion) VALUES ('Ventanilla');
INSERT INTO EL_PUNTERO.TL_TIPO_BUTACA (Descripcion) VALUES ('Pasillo');

CREATE TABLE [EL_PUNTERO].[TL_DEVOLUCION_ENCOMIENDA](
	[ID_Devolucion_Encomienda] int IDENTITY(1,1),
	[ID_Encomienda] int,
	[Fecha_Devolucion] datetime,
	[Motivo] nvarchar(100),
	[ID_Usuario] int,
);

CREATE TABLE [EL_PUNTERO].[TL_DEVOLUCION_PASAJE](
	[ID_Devolucion_Pasaje] int IDENTITY(1,1),
	[ID_Pasaje] int,
	[Fecha_Devolucion] datetime,
	[Motivo] nvarchar(100),
	[ID_Usuario] int,
	
);

CREATE TABLE [EL_PUNTERO].[TL_ENCOMIENDA](
	[ID_Encomienda] int IDENTITY(1,1),
	[Codigo_Encomienda] int NOT NULL,
	[ID_Compra] int NOT NULL,
	[Precio] numeric(18,2) NOT NULL,
	[ID_Viaje] int NOT NULL,
	[KG] int NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_COMPRA](
	[ID_Compra] int IDENTITY(1,1),
	[PNR] int,
	[ID_Cliente] int NOT NULL,
	[Fecha_Compra] datetime NOT NULL,
	[ID_Tarjeta] int,
	[Cantidad_Cuotas] int,
	[ID_Usuario] int,
	[Codigo_Pasaje] int,
	[Codigo_Paquete] int
);

CREATE TABLE [EL_PUNTERO].[TL_REGISTRO_MILLAS](
	[ID_Registro] int IDENTITY(1,1),
	[ID_Cliente] int NOT NULL,
	[Fecha_Inicio] datetime NOT NULL,
	[Codigo_Item] int NOT NULL,
	[Millas] int NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_CANJE](
	[ID_Canje] int IDENTITY(1,1),
	[ID_Producto] int NOT NULL,
	[ID_Cliente] int NOT NULL,
	[Cantidad] int NOT NULL CHECK(Cantidad>0),
	[Fecha_Canje] datetime NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_PRODUCTO](
	[ID_Producto] int IDENTITY(1,1),
	[Descripcion] nvarchar(40) NOT NULL,
	[Stock] int NOT NULL,
	[Puntos] int NOT NULL
);

INSERT INTO EL_PUNTERO.TL_PRODUCTO (Descripcion,Stock,Puntos)
VALUES
('Bicicleta', 10, 50),
('Celular', 8, 75),
('LCD Philips', 10, 100),
('Notebook Toshiba', 6, 150),
('Valija', 20, 50);

CREATE TABLE [EL_PUNTERO].[TL_TARJETA](
	[ID_Tarjeta] int IDENTITY(1,1),
	[Nro_Tarjeta] bigint NOT NULL,
	[ID_Cliente] int NOT NULL,
	[ID_Tipo_Tarjeta] int NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_TIPO_TARJETA](
	[ID_Tipo_Tarjeta] int IDENTITY(1,1),
	[Descripcion] nvarchar(30),
);

INSERT INTO EL_PUNTERO.TL_TIPO_TARJETA (Descripcion) VALUES ('VISA');
INSERT INTO EL_PUNTERO.TL_TIPO_TARJETA (Descripcion) VALUES ('MASTERCARD');
INSERT INTO EL_PUNTERO.TL_TIPO_TARJETA (Descripcion) VALUES ('AMEX');

COMMIT

--Agregar Primary Keys
BEGIN TRANSACTION
ALTER TABLE [EL_PUNTERO].[TL_AERONAVE]
ADD PRIMARY KEY ([ID_Aeronave]);

ALTER TABLE [EL_PUNTERO].[TL_BAJA_SERVICIO_AERONAVE]
ADD PRIMARY KEY([ID_Baja_Servicio]);

ALTER TABLE [EL_PUNTERO].[TL_SERVICIO]
ADD PRIMARY KEY ([ID_Servicio]);

ALTER TABLE [EL_PUNTERO].[TL_RUTA]
ADD PRIMARY KEY ([ID_Ruta]);

ALTER TABLE [EL_PUNTERO].[TL_SERVICIO_RUTA]
ADD PRIMARY KEY ([ID_Servicio_Ruta]);

ALTER TABLE [EL_PUNTERO].[TL_CIUDAD]
ADD PRIMARY KEY ([ID_Ciudad]);

ALTER TABLE [EL_PUNTERO].[TL_TIPO_BUTACA]
ADD PRIMARY KEY ([ID_Tipo_Butaca]);

ALTER TABLE [EL_PUNTERO].[TL_BUTACA]
ADD PRIMARY KEY ([ID_Butaca]);

ALTER TABLE [EL_PUNTERO].[TL_PASAJE]
ADD PRIMARY KEY ([ID_Pasaje]);

ALTER TABLE [EL_PUNTERO].[TL_VIAJE]
ADD PRIMARY KEY ([ID_Viaje]);

ALTER TABLE [EL_PUNTERO].[TL_DEVOLUCION_ENCOMIENDA]
ADD PRIMARY KEY ([ID_Devolucion_Encomienda]);

ALTER TABLE [EL_PUNTERO].[TL_DEVOLUCION_PASAJE]
ADD PRIMARY KEY ([ID_Devolucion_Pasaje]);

ALTER TABLE [EL_PUNTERO].[TL_REGISTRO_MILLAS]
ADD PRIMARY KEY ([ID_Registro]);

ALTER TABLE [EL_PUNTERO].[TL_ENCOMIENDA]
ADD PRIMARY KEY ([ID_Encomienda]);

ALTER TABLE [EL_PUNTERO].[TL_CLIENTE]
ADD PRIMARY KEY ([ID_Cliente]);

ALTER TABLE [EL_PUNTERO].[TL_CANJE]
ADD PRIMARY KEY ([ID_Canje]);

ALTER TABLE [EL_PUNTERO].[TL_COMPRA]
ADD PRIMARY KEY ([ID_Compra]);

ALTER TABLE [EL_PUNTERO].[TL_TIPO_DOCUMENTO]
ADD PRIMARY KEY ([ID_Tipo_Documento]);

ALTER TABLE [EL_PUNTERO].[TL_PRODUCTO]
ADD PRIMARY KEY ([ID_Producto]);

ALTER TABLE [EL_PUNTERO].[TL_TARJETA]
ADD PRIMARY KEY ([ID_Tarjeta]);

ALTER TABLE [EL_PUNTERO].[TL_TIPO_TARJETA]
ADD PRIMARY KEY ([ID_Tipo_Tarjeta]);

ALTER TABLE [EL_PUNTERO].[TL_USUARIO]
ADD PRIMARY KEY ([ID_Usuario]);

ALTER TABLE [EL_PUNTERO].[TL_ROL_USUARIO]
ADD PRIMARY KEY ([ID_Rol_Usuario]);

ALTER TABLE [EL_PUNTERO].[TL_ROL]
ADD PRIMARY KEY ([ID_Rol]);

ALTER TABLE [EL_PUNTERO].[TL_FUNCIONALIDAD_ROL]
ADD PRIMARY KEY ([ID_Funcionalidad_Rol]);

ALTER TABLE [EL_PUNTERO].[TL_FUNCIONALIDAD]
ADD PRIMARY KEY ([ID_Funcionalidad]);

COMMIT

--Migracion
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

--Agregar Foreign Keys
BEGIN TRANSACTION

ALTER TABLE [EL_PUNTERO].[TL_AERONAVE]
ADD FOREIGN KEY ([ID_Servicio])
REFERENCES [EL_PUNTERO].[TL_SERVICIO](ID_Servicio);

ALTER TABLE [EL_PUNTERO].[TL_BAJA_SERVICIO_AERONAVE]
ADD FOREIGN KEY ([ID_Aeronave])
REFERENCES [EL_PUNTERO].[TL_AERONAVE](ID_Aeronave);

ALTER TABLE [EL_PUNTERO].[TL_RUTA]
ADD FOREIGN KEY ([ID_Ciudad_Origen])
REFERENCES [EL_PUNTERO].[TL_CIUDAD](ID_Ciudad);

ALTER TABLE [EL_PUNTERO].[TL_RUTA]
ADD FOREIGN KEY ([ID_Ciudad_Destino])
REFERENCES [EL_PUNTERO].[TL_CIUDAD](ID_Ciudad);

ALTER TABLE [EL_PUNTERO].[TL_SERVICIO_RUTA]
ADD FOREIGN KEY ([ID_Servicio])
REFERENCES [EL_PUNTERO].[TL_Servicio](ID_Servicio);

ALTER TABLE [EL_PUNTERO].[TL_SERVICIO_RUTA]
ADD FOREIGN KEY ([ID_Ruta])
REFERENCES [EL_PUNTERO].[TL_RUTA](ID_Ruta);

ALTER TABLE [EL_PUNTERO].[TL_BUTACA]
ADD FOREIGN KEY ([ID_Tipo_Butaca])
REFERENCES [EL_PUNTERO].[TL_TIPO_BUTACA](ID_Tipo_Butaca);

ALTER TABLE [EL_PUNTERO].[TL_BUTACA]
ADD FOREIGN KEY ([ID_Aeronave])
REFERENCES [EL_PUNTERO].[TL_AERONAVE](ID_Aeronave);

ALTER TABLE [EL_PUNTERO].[TL_VIAJE]
ADD FOREIGN KEY ([ID_Ruta])
REFERENCES [EL_PUNTERO].[TL_RUTA](ID_Ruta);

ALTER TABLE [EL_PUNTERO].[TL_VIAJE]
ADD FOREIGN KEY ([ID_Aeronave])
REFERENCES [EL_PUNTERO].[TL_AERONAVE](ID_Aeronave);

ALTER TABLE [EL_PUNTERO].[TL_DEVOLUCION_ENCOMIENDA]
ADD FOREIGN KEY ([ID_Encomienda])
REFERENCES [EL_PUNTERO].[TL_ENCOMIENDA](ID_Encomienda);

ALTER TABLE [EL_PUNTERO].[TL_DEVOLUCION_ENCOMIENDA]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [EL_PUNTERO].[TL_Usuario](ID_Usuario);

ALTER TABLE [EL_PUNTERO].[TL_DEVOLUCION_PASAJE]
ADD FOREIGN KEY ([ID_Pasaje])
REFERENCES [EL_PUNTERO].[TL_PASAJE](ID_Pasaje);

ALTER TABLE [EL_PUNTERO].[TL_DEVOLUCION_PASAJE]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [EL_PUNTERO].[TL_Usuario](ID_Usuario);

ALTER TABLE [EL_PUNTERO].[TL_REGISTRO_MILLAS]
ADD FOREIGN KEY ([ID_Cliente])
REFERENCES [EL_PUNTERO].[TL_CLIENTE](ID_Cliente);

ALTER TABLE [EL_PUNTERO].[TL_ENCOMIENDA]
ADD FOREIGN KEY ([ID_Compra])
REFERENCES [EL_PUNTERO].[TL_COMPRA](ID_Compra);

ALTER TABLE [EL_PUNTERO].[TL_ENCOMIENDA]
ADD FOREIGN KEY ([ID_Viaje])
REFERENCES [EL_PUNTERO].[TL_VIAJE](ID_Viaje);

ALTER TABLE [EL_PUNTERO].[TL_CLIENTE]
ADD FOREIGN KEY ([ID_Tipo_Documento])
REFERENCES [EL_PUNTERO].[TL_TIPO_DOCUMENTO](ID_Tipo_Documento);

ALTER TABLE [EL_PUNTERO].[TL_CANJE]
ADD FOREIGN KEY ([ID_Producto])
REFERENCES [EL_PUNTERO].[TL_PRODUCTO](ID_Producto);

ALTER TABLE [EL_PUNTERO].[TL_CANJE]
ADD FOREIGN KEY ([ID_Cliente])
REFERENCES [EL_PUNTERO].[TL_Cliente](ID_Cliente);

ALTER TABLE [EL_PUNTERO].[TL_COMPRA]
ADD FOREIGN KEY ([ID_Cliente])
REFERENCES [EL_PUNTERO].[TL_CLIENTE](ID_Cliente);

ALTER TABLE [EL_PUNTERO].[TL_COMPRA]
ADD FOREIGN KEY ([ID_Tarjeta])
REFERENCES [EL_PUNTERO].[TL_TARJETA](ID_Tarjeta);

ALTER TABLE [EL_PUNTERO].[TL_COMPRA]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [EL_PUNTERO].[TL_Usuario](ID_Usuario);

ALTER TABLE [EL_PUNTERO].[TL_TARJETA]
ADD FOREIGN KEY ([ID_Cliente])
REFERENCES [EL_PUNTERO].[TL_CLIENTE](ID_Cliente);

ALTER TABLE [EL_PUNTERO].[TL_TARJETA]
ADD FOREIGN KEY ([ID_Tipo_Tarjeta])
REFERENCES [EL_PUNTERO].[TL_TIPO_TARJETA](ID_Tipo_Tarjeta);

ALTER TABLE [EL_PUNTERO].[TL_ROL_USUARIO]
ADD FOREIGN KEY ([ID_Rol])
REFERENCES [EL_PUNTERO].[TL_Rol](ID_Rol);

ALTER TABLE [EL_PUNTERO].[TL_ROL_USUARIO]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [EL_PUNTERO].[TL_USUARIO](ID_Usuario);

ALTER TABLE [EL_PUNTERO].[TL_FUNCIONALIDAD_ROL]
ADD FOREIGN KEY ([ID_Funcionalidad])
REFERENCES [EL_PUNTERO].[TL_FUNCIONALIDAD](ID_Funcionalidad);

ALTER TABLE [EL_PUNTERO].[TL_FUNCIONALIDAD_ROL]
ADD FOREIGN KEY ([ID_Rol])
REFERENCES [EL_PUNTERO].[TL_ROL](ID_Rol);

ALTER TABLE [EL_PUNTERO].[TL_PASAJE]
ADD FOREIGN KEY ([ID_Compra])
REFERENCES [EL_PUNTERO].[TL_COMPRA](ID_Compra);

ALTER TABLE [EL_PUNTERO].[TL_PASAJE]
ADD FOREIGN KEY ([ID_Viaje])
REFERENCES [EL_PUNTERO].[TL_VIAJE](ID_Viaje);

ALTER TABLE [EL_PUNTERO].[TL_PASAJE]
ADD FOREIGN KEY ([ID_Butaca])
REFERENCES [EL_PUNTERO].[TL_BUTACA](ID_Butaca);

ALTER TABLE [EL_PUNTERO].[TL_PASAJE]
ADD FOREIGN KEY ([ID_Cliente])
REFERENCES [EL_PUNTERO].[TL_CLIENTE](ID_Cliente);

COMMIT

--Store Procedures
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

CREATE PROCEDURE [EL_PUNTERO].[CiudadTieneViajes]
@ID_Ciudad int
AS
BEGIN
	(SELECT * FROM [EL_PUNTERO].[TL_Ruta] WHERE ID_Ciudad_Origen = @ID_Ciudad AND ID_Ruta IN (SELECT ID_Ruta FROM [EL_PUNTERO].[TL_Viaje] WHERE Fecha_Salida >= GETDATE()))
	UNION ALL
	(SELECT * FROM [EL_PUNTERO].[TL_Ruta] WHERE ID_Ciudad_Destino = @ID_Ciudad AND ID_Ruta IN (SELECT ID_Ruta FROM [EL_PUNTERO].[TL_Viaje] WHERE Fecha_Salida >= GETDATE()))
END
GO

CREATE PROCEDURE [EL_PUNTERO].[EliminarCiudad]
@ID_Ciudad int
AS
BEGIN
	DELETE 
	FROM [EL_PUNTERO].[TL_Ciudad]
	WHERE ID_Ciudad = @ID_Ciudad
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
	WHERE Baja_Por_Vida_Util = 0
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


CREATE FUNCTION [EL_PUNTERO].[SeIntersectanFechasFueraDeServicio](@BajaDesde datetime,@BajaHasta datetime,@FechaDesde datetime,@FechaHasta datetime)
RETURNS int
AS
BEGIN
	DECLARE @resul int

	SET @resul = 0
	IF ((@BajaDesde>=@FechaDesde) AND (@BajaDesde<=@FechaHasta)) OR ((@BajaHasta>=@FechaDesde) AND (@BajaHasta<=@FechaHasta))
	BEGIN
		SET @resul = 1
	END
	RETURN @resul
END
GO

CREATE PROCEDURE [EL_PUNTERO].[GetAeronavesConMayorCantDeDiasFueraDeServicio]
@Fecha_Desde datetime,
@Fecha_Hasta datetime
AS
BEGIN
	SELECT TOP 5 A.Matricula AS Parametro,MAX([EL_PUNTERO].[CantFueraDeServicio](B.ID_Baja_Servicio,@Fecha_Desde,@Fecha_Hasta)) AS Valor
	FROM EL_PUNTERO.TL_AERONAVE A
	INNER JOIN EL_PUNTERO.TL_BAJA_SERVICIO_AERONAVE B ON B.ID_Aeronave=A.ID_Aeronave
	WHERE [EL_PUNTERO].[SeIntersectanFechasFueraDeServicio](B.Fecha_Fuera_De_Servicio,B.Fecha_Reinicio_Servicio,@Fecha_Desde,@Fecha_Hasta)=1
	GROUP BY A.Matricula
	ORDER BY 2 DESC
END
GO

COMMIT


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

CREATE PROCEDURE [EL_PUNTERO].[GetClienteEnViaje]
@Documento int,
@Tipo_Doc int,
@ID_Viaje int,
@Apellido nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @FechaDesde datetime
	DECLARE @FechaHasta datetime
	DECLARE @ID_Cliente int
	SET @FechaDesde = (SELECT Fecha_Salida FROM [EL_PUNTERO].TL_VIAJE WHERE ID_Viaje=@ID_Viaje)
	SET @FechaHasta = (SELECT Fecha_Llegada_Estimada FROM [EL_PUNTERO].TL_VIAJE WHERE ID_Viaje=@ID_Viaje)

	SET @ID_Cliente = (SELECT ID_Cliente FROM [EL_PUNTERO].TL_CLIENTE WHERE ID_Tipo_Documento=@Tipo_Doc AND Nro_Documento=@Documento AND Apellido=@Apellido)
	
	SELECT * FROM [EL_PUNTERO].TL_PASAJE WHERE ID_Cliente=@ID_Cliente AND [EL_PUNTERO].[SeIntersectanFechas](ID_Pasaje,@FechaDesde,@FechaHasta)=1
	
END
GO

CREATE FUNCTION [EL_PUNTERO].[SeIntersectanFechas](@ID_Pasaje int,@FechaDesde datetime,@FechaHasta datetime)
RETURNS int
AS
BEGIN
	DECLARE @PasajeDesde datetime
	DECLARE @PasajeHasta datetime
	DECLARE @resul int

	SET @PasajeDesde = (SELECT V.Fecha_Salida FROM [EL_PUNTERO].TL_PASAJE P,[EL_PUNTERO].TL_VIAJE V WHERE V.ID_Viaje=P.ID_Viaje AND P.ID_Pasaje=@ID_Pasaje)

	SET @PasajeHasta = (SELECT V.Fecha_Llegada_Estimada FROM [EL_PUNTERO].TL_PASAJE P,[EL_PUNTERO].TL_VIAJE V WHERE V.ID_Viaje=P.ID_Viaje AND P.ID_Pasaje=@ID_Pasaje)

	SET @resul = 0
	IF ((@PasajeDesde>=@FechaDesde) AND (@PasajeDesde<=@FechaHasta)) OR ((@PasajeHasta>=@FechaDesde) AND (@PasajeHasta<=@FechaHasta))
	BEGIN
		SET @resul = 1
	END
	RETURN @resul
END
GO


COMMIT

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
		   AND E.ID_Encomienda NOT IN (SELECT DE.ID_Encomienda
										FROM EL_PUNTERO.TL_DEVOLUCION_ENCOMIENDA DE
										WHERE DE.ID_Encomienda = E.ID_Encomienda)
	ORDER BY E.Codigo_Encomienda
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

--Trigger
BEGIN TRANSACTION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON																	
GO

CREATE TRIGGER [EL_PUNTERO].[Tr_DeshabilitarUsuariosConRolDeshabilitado]
ON [EL_PUNTERO].[TL_ROL]
AFTER UPDATE
AS BEGIN
	DELETE FROM [EL_PUNTERO].[TL_ROL_USUARIO]
	WHERE ID_Rol in (SELECT ID_Rol FROM [EL_PUNTERO].[TL_ROL] WHERE Habilitado=0) 
END
GO

COMMIT