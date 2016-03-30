.NET
	Ventana Clients
		Método GET Clients
			Mensaje de error si no existe ID - Cliente
			Mensaje de error si no hay ningún valor - Cliente
			Método PUT Clients
			No funciona
			Método POST Clients
		Mensaje fallo DNI - Servidor (Devolver mensaje error)/Cliente
			El servidor escoge el ID - Servidor 
			Mensaje ID repetido - Servidor (Primero, solucionar el ID del servidor)
			
	Ventana Contracts
		Método GET Contracts
			Mensaje de error si no existe ID - Cliente
			Mensaje de error si no hay ningún valor - Cliente
		Método PUT Contracts
			No funciona
		Método POST Contracts
			Se crea un nuevo cliente - Servidor
			Se crea una nueva polixa - Servidor
			El servidor escoge el ID - Servidor 
			Mensaje ID repetido - Cliente (Primero, solucionar el ID del servidor)
			Mensaje si no existe id client - Cliente (Primero, solucionar que el servidor crea nuevos clientes)
			Mensaje si no existe id poliza - Cliente (Primero, solucionar que el servidor crea nuevas polizas)
			
	Ventana Bills
		Método GET Bills
			Mensaje de error si no existe ID - Cliente
			Mensaje de error si no hay ningín valor - Cliente
		Método PUT Bills
			No funciona - Cliente/Servidor (El diccionario de parámetros contiene una entrada NULL para el parámetro 'id' del tipo que no acepta valores NULL)
		Método POST Bills
			Se crea un nuevo cliente - Servidor
			El servidor escoge el ID - Servidor 
			Mensaje ID repetido - Cliente (Primero, solucionar el ID del servidor)
			Mensaje si no existe id client - Cliente (Primero, solucionar que el servidor crea nuevos clientes)