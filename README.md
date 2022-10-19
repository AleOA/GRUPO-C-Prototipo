*Aspectos generales del Sistema (Prototipo)*

- Cada vez que se cierra el programa, vuelve a su estado inicial.
- El sistema funciona solo con un usuario:  
-Usuario: cai  
-Contraseña: cai  
- El usuario SIEMPRE debe iniciar sesión para utilizar el sistema.
- Para aquellas funcionalidades no implementadas, el sistema lanza un mensaje: "No Implementado".

*Solicitud/Cancelación de Servicio*
- Estado Inicial:  
No hay pedidos cargados.
- Únicamente funciona para Tipos de Envio Nacionales.
- Se cargaron Ciudades de prueba tanto de origen como de destino.
- A las Ciudades de Destino cargadas se les asigno una tarifa.
- Se puede generar una solicitud de servicio.
- Se pueden cancelar las solicitudes de servicio generadas.

*Estado del Servicio*
- Estado Inicial:  
Se le cargaron 3 envios de prueba:  
-Envio 1 con estado: Recibida  
-Envio 2 con estado: En Transito.  
-Envio 3 con estado: Cerrada.  
- Se puede consultar el estado de cualquiera de los 3 envios cargados.

*Estado de Cuenta*
- Estado Inicial:  
Se cargaron:  
-2 facturas pagadas.  
-2 facturas pendientes de pago.  
-1 envio pendiente de facturar.  
- Para cada factura se puede visualizar su número y su monto.
- Se pueden pagar las facturas seleccionadas.
- Se puede visualizar el saldo de la cuenta:   
-Si el usuario tiene facturas pendientes de pago, se puede visualizar el saldo total de facturas a pagar.  
-Si el usuario tiene todas sus facturas pagas, se puede visualizar un mensaje "No tiene facturas pendientes de pago".