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