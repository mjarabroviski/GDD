CREATE SCHEMA [EL_PUNTERO] AUTHORIZATION [gd];
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
VALUES ('admin1','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',2);
INSERT INTO EL_PUNTERO.TL_USUARIO (Username,Password,Cant_Intentos)
VALUES ('admin2','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',2);
INSERT INTO EL_PUNTERO.TL_USUARIO (Username,Password,Cant_Intentos)
VALUES ('admin3','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',2);
INSERT INTO EL_PUNTERO.TL_USUARIO (Username,Password,Cant_Intentos)
VALUES ('admin4','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',2);
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