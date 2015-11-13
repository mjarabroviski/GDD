CREATE SCHEMA [EL_PUNTERO] AUTHORIZATION [gd];

--Creaacion de schema y tablas
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
	[ID_Compra] int NOT NULL,
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
	[ID_Rol] int NOT NULL,
	[Username] nvarchar(255) UNIQUE,
	[Password] nvarchar(64) NOT NULL,
	[Habilitado] bit DEFAULT 1,
	[Cant_Intentos] int DEFAULT 3
);

CREATE TABLE [EL_PUNTERO].[TL_ROL](
	[ID_Rol] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL,
	[Habilitado] bit DEFAULT 1
);

INSERT INTO EL_PUNTERO.TL_ROL (Descripcion) VALUES ('Cliente');
INSERT INTO EL_PUNTERO.TL_ROL (Descripcion) VALUES ('Administrador');
INSERT INTO EL_PUNTERO.TL_ROL (Descripcion) VALUES ('Administrador General');

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
	[ID_Servicio] int NOT NULL,
	[ID_Ciudad_Origen] int NOT NULL,
	[ID_Ciudad_Destino] int NOT NULL,
	[Precio_Base_KG] numeric(18,2),
	[Precio_Base_Pasaje] numeric(18,2),
	[Habilitado] int DEFAULT 1
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

/*tipo item: 1:pasaje 0:encomienda*/
CREATE TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO](
	[ID_Item_Devuelto] int IDENTITY(1,1),
	[ID_Encomienda] int,
	[ID_Pasaje] int,
	[ID_Devolucion] int 
);

CREATE TABLE [EL_PUNTERO].[TL_DEVOLUCION](
	[ID_Devolucion] int IDENTITY(1,1),
	[Fecha_Devolucion] datetime,
	[Motivo] nvarchar(100),
	[ID_Compra] int NOT NULL,
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
	[ID_Cliente] int NOT NULL,
	[Monto] numeric(18,2) NOT NULL,
	[Fecha_Compra] datetime NOT NULL,
	[ID_Tarjeta] int,
	[ID_Usuario] int NOT NULL,
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

CREATE TABLE [EL_PUNTERO].[TL_TARJETA](
	[ID_Tarjeta] int IDENTITY(1,1),
	[Nro_Tarjeta] bigint NOT NULL,
	[ID_Cliente] int NOT NULL,
	[ID_Tipo_Tarjeta] int NOT NULL
);

CREATE TABLE [EL_PUNTERO].[TL_TIPO_TARJETA](
	[ID_Tipo_Tarjeta] int IDENTITY(1,1),
	[Descripcion] nvarchar(30),
	[Cantidad_Cuotas] int NOT NULL
);

INSERT INTO EL_PUNTERO.TL_TIPO_TARJETA (Descripcion,Cantidad_Cuotas) VALUES ('VISA',12);
INSERT INTO EL_PUNTERO.TL_TIPO_TARJETA (Descripcion,Cantidad_Cuotas) VALUES ('MASTERCARD',6);
INSERT INTO EL_PUNTERO.TL_TIPO_TARJETA (Descripcion,Cantidad_Cuotas) VALUES ('AMEX',3);

COMMIT

--Agregar primary keys
BEGIN TRANSACTION
ALTER TABLE [EL_PUNTERO].[TL_AERONAVE]
ADD PRIMARY KEY ([ID_Aeronave]);

ALTER TABLE [EL_PUNTERO].[TL_BAJA_SERVICIO_AERONAVE]
ADD PRIMARY KEY([ID_Baja_Servicio]);

ALTER TABLE [EL_PUNTERO].[TL_SERVICIO]
ADD PRIMARY KEY ([ID_Servicio]);

ALTER TABLE [EL_PUNTERO].[TL_RUTA]
ADD PRIMARY KEY ([ID_Ruta]);

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

ALTER TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO]
ADD PRIMARY KEY ([ID_Item_Devuelto]);

ALTER TABLE [EL_PUNTERO].[TL_DEVOLUCION]
ADD PRIMARY KEY ([ID_Devolucion]);

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
 INSERT INTO EL_PUNTERO.TL_RUTA(Codigo_Ruta,ID_Servicio,ID_Ciudad_Origen,ID_Ciudad_Destino)
 (SELECT DISTINCT [Ruta_Codigo],
		 (SELECT ID_Servicio FROM EL_PUNTERO.TL_SERVICIO WHERE Nombre = gd_esquema.Maestra.Tipo_Servicio),
		 (SELECT ID_Ciudad FROM EL_PUNTERO.TL_CIUDAD WHERE Nombre_Ciudad = SUBSTRING((gd_esquema.Maestra.Ruta_Ciudad_Origen),2,LEN(gd_esquema.Maestra.Ruta_Ciudad_Origen)-1)),
		 (SELECT ID_Ciudad FROM EL_PUNTERO.TL_CIUDAD WHERE Nombre_Ciudad = SUBSTRING((gd_esquema.Maestra.Ruta_Ciudad_Destino),2,LEN(gd_esquema.Maestra.Ruta_Ciudad_Destino)-1))
 FROM gd_esquema.Maestra);
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
 INSERT INTO EL_PUNTERO.TL_USUARIO (ID_Rol,Username,Password,Cant_Intentos)
 VALUES (2,'admin1','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3);

 INSERT INTO EL_PUNTERO.TL_USUARIO (ID_Rol,Username,Password,Cant_Intentos)
 VALUES (2,'admin2','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3);

 INSERT INTO EL_PUNTERO.TL_USUARIO (ID_Rol,Username,Password,Cant_Intentos)
 VALUES (2,'admin3','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3);

 INSERT INTO EL_PUNTERO.TL_USUARIO (ID_Rol,Username,Password,Cant_Intentos)
 VALUES (2,'admin4','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3);

 INSERT INTO EL_PUNTERO.TL_USUARIO (ID_Rol,Username,Password,Cant_Intentos)
 VALUES (3,'admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3);
 COMMIT
 
 BEGIN TRANSACTION
 INSERT INTO EL_PUNTERO.TL_COMPRA(ID_Cliente,Fecha_Compra,ID_Tarjeta,ID_Usuario,Monto,Codigo_Pasaje,Codigo_Paquete)
 (SELECT (SELECT ID_Cliente FROM EL_PUNTERO.TL_CLIENTE 
			 WHERE Nro_Documento = Cli_Dni AND Apellido = Cli_Apellido AND Nombre = Cli_Nombre),
		 (CASE WHEN Pasaje_FechaCompra = '1900-01-01 00:00:00.000' THEN Paquete_FechaCompra
			 WHEN Paquete_FechaCompra = '1900-01-01 00:00:00.000'  THEN Pasaje_FechaCompra
		  END),
		  NULL,
		  1,
		 Paquete_Precio + Pasaje_Precio,
		 [Pasaje_Codigo],
		 [Paquete_Codigo]
 FROM gd_esquema.Maestra);
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

 --Agregar foreing keys
 BEGIN TRANSACTION

ALTER TABLE [EL_PUNTERO].[TL_AERONAVE]
ADD FOREIGN KEY ([ID_Servicio])
REFERENCES [EL_PUNTERO].[TL_SERVICIO](ID_Servicio);

ALTER TABLE [EL_PUNTERO].[TL_BAJA_SERVICIO_AERONAVE]
ADD FOREIGN KEY ([ID_Aeronave])
REFERENCES [EL_PUNTERO].[TL_AERONAVE](ID_Aeronave);

ALTER TABLE [EL_PUNTERO].[TL_RUTA]
ADD FOREIGN KEY ([ID_Servicio])
REFERENCES [EL_PUNTERO].[TL_SERVICIO](ID_Servicio);

ALTER TABLE [EL_PUNTERO].[TL_RUTA]
ADD FOREIGN KEY ([ID_Ciudad_Origen])
REFERENCES [EL_PUNTERO].[TL_CIUDAD](ID_Ciudad);

ALTER TABLE [EL_PUNTERO].[TL_RUTA]
ADD FOREIGN KEY ([ID_Ciudad_Destino])
REFERENCES [EL_PUNTERO].[TL_CIUDAD](ID_Ciudad);

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


ALTER TABLE [EL_PUNTERO].[TL_DEVOLUCION]
ADD FOREIGN KEY ([ID_Compra])
REFERENCES [EL_PUNTERO].[TL_COMPRA](ID_Compra);

ALTER TABLE [EL_PUNTERO].[TL_DEVOLUCION]
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

ALTER TABLE [EL_PUNTERO].[TL_USUARIO]
ADD FOREIGN KEY ([ID_Rol])
REFERENCES [EL_PUNTERO].[TL_ROL](ID_Rol);

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


ALTER TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO]
ADD FOREIGN KEY ([ID_Pasaje])
REFERENCES [EL_PUNTERO].[TL_PASAJE](ID_Pasaje);

ALTER TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO]
ADD FOREIGN KEY ([ID_Encomienda])
REFERENCES [EL_PUNTERO].[TL_ENCOMIENDA](ID_Encomienda);

ALTER TABLE [EL_PUNTERO].[TL_ITEM_DEVUELTO]
ADD FOREIGN KEY ([ID_Devolucion])
REFERENCES [EL_PUNTERO].[TL_DEVOLUCION](ID_Devolucion);

COMMIT

--Procedures y functions 
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
	FROM [EL_PUNTERO].[TL_Aeronave]
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
	--Agrego Pasajes
	INSERT INTO EL_PUNTERO.TL_REGISTRO_MILLAS (ID_Cliente,Codigo_Item,Fecha_Inicio,Millas)
	(SELECT DISTINCT ID_Cliente,Codigo_Pasaje, GETDATE(), (Precio/10) FROM EL_PUNTERO.TL_PASAJE WHERE ID_Viaje = @ID_Viaje
	AND ID_Pasaje NOT IN (SELECT ID_Pasaje FROM EL_PUNTERO.TL_ITEM_DEVUELTO))

	--Agrego Encomiendas
	INSERT INTO [EL_PUNTERO].[TL_REGISTRO_MILLAS] (ID_Cliente,Codigo_Item,Fecha_Inicio,Millas)
	(SELECT DISTINCT ID_Cliente,Codigo_Encomienda, GETDATE(), (Precio/10) FROM EL_PUNTERO.TL_ENCOMIENDA E INNER JOIN EL_PUNTERO.TL_COMPRA C ON C.ID_Compra = E.ID_Compra  
	WHERE ID_Viaje = @ID_Viaje AND ID_Encomienda NOT IN (SELECT ID_Pasaje FROM EL_PUNTERO.TL_ITEM_DEVUELTO))

	--Sumo las millas del cliente
	UPDATE C
	SET C.Millas += (SELECT SUM(R.Millas) FROM EL_PUNTERO.TL_REGISTRO_MILLAS R  WHERE R.ID_Cliente = C.ID_Cliente) 
	FROM EL_PUNTERO.TL_CLIENTE C
END
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
	  AND (((SELECT Nombre FROM [EL_PUNTERO].TL_SERVICIO S WHERE S.ID_Servicio = R.ID_Servicio) = @Tipo_Servicio) OR (@Tipo_Servicio is NULL)) 
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

CREATE PROCEDURE [EL_PUNTERO].[InsertarRuta]
	@Codigo int,
	@ID_Ciudad_Destino int,
	@ID_Ciudad_Origen int,
	@ID_Servicio int,
	@Precio_Base_KG numeric(18,2),
	@Precio_Base_Pasaje numeric(18,2),
	@Habilitado bit
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [EL_PUNTERO].[TL_Ruta] (Codigo_Ruta,ID_Ciudad_Origen,ID_Ciudad_Destino,Precio_Base_KG,Precio_Base_Pasaje,ID_Servicio,Habilitado)
	OUTPUT inserted.ID_Ruta
	VALUES (@Codigo, @ID_Ciudad_Origen,@ID_Ciudad_Destino,@Precio_Base_KG,@Precio_Base_Pasaje,@ID_Servicio,@Habilitado)
END
GO

CREATE PROCEDURE [EL_PUNTERO].[ModificarRuta]
	@ID_Ruta int,
	@Codigo int,
	@ID_Ciudad_Destino int,
	@ID_Ciudad_Origen int,
	@ID_Servicio int,
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
		ID_Servicio = @ID_Servicio,
		Precio_Base_KG = @Precio_Base_KG,
		Precio_Base_Pasaje = @Precio_Base_Pasaje,
		Habilitado = @Habilitado
	WHERE ID_Ruta = @ID_Ruta
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

CREATE PROCEDURE [EL_PUNTERO].[ServicioPorIDRuta]
@ID_Ruta int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT *
	FROM [EL_PUNTERO].TL_SERVICIO
	WHERE ID_Servicio = (SELECT ID_Servicio FROM TL_RUTA WHERE ID_Ruta=@ID_Ruta)
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

--Triggers
BEGIN TRANSACTION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [EL_PUNTERO].[Tr_DeshabilitarUsuariosConRolDeshabilitado]
ON [EL_PUNTERO].[TL_ROL]
AFTER UPDATE
AS BEGIN
	UPDATE [EL_PUNTERO].[TL_USUARIO] SET Habilitado = 0
	WHERE ID_Rol in (SELECT ID_Rol FROM [EL_PUNTERO].[TL_ROL] WHERE Habilitado=0) 
END
GO

COMMIT