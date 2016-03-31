#.NET
# AseguradoraRESTUI
	-- Mejoras en el cliente
	Ventana Clients
		Método GET Clients
			-- Mensaje de error si no existe ID - Cliente
			-- Mensaje de error si no hay ningún valor - Cliente
		Método PUT Clients
			No funciona - Falla la validación del DNI (Si pongo get no sucede). El error que envía el servidor aparece en la cajita del DNI
		Método POST Clients
			Mensaje fallo DNI - Si pongo el mal el DNI, Visual Studio indica el error. Debería haber algún método que si el DNI está mal devuelva un mensaje de error
			
	Ventana Contracts
		Método GET Contracts
			-- Mensaje de error si no existe ID - Cliente
			-- Mensaje de error si no hay ningún valor - Cliente
		Método PUT Contracts
			No funciona - El error que envía el servidor aparece en la cajita del ID Client
		Método POST Contracts
			Se crea un nuevo cliente - No se debería crear un cliente, simplemente comprobar que el id del cliente  existe
			Se crea una nueva poliza - No se debería crear una poliza, simplemente comprobar que el id de la poliza  existe
			-- Mensaje si no existe id client - Cliente
			-- Mensaje si no existe id poliza - Cliente
			
	Ventana Bills
		Método GET Bills
			-- Mensaje de error si no existe ID - Cliente
			-- Mensaje de error si no hay ningín valor - Cliente
		Método PUT Bills
			No funciona - El error que envía el servidor aparece en la cajita del ID Client
		Método POST Bills
			Se crea un nuevo cliente - No se debería crear un cliente, simplemente comprobar que el id del cliente  existe
			-- Mensaje ID repetido - Cliente
			-- Mensaje si no existe id client - Cliente