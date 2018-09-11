# Web-Api-Core-Example

Vamos a crear un proyecto de Web Api Core paso a paso.

## 1) Primer paso será crear la carpeta y luego el proyecto de Web Api Core
- mkdir WAC.WebAPI
- cd WAC.WebAPI
- dotnet new webapi -au None --no-https

## 2) Abrimos la carpeta con Visual Studio Code
- cd ..
- start .
- Open With Visual Studio Code
- Añadimos las Extensiones de C# a WAC.WebApi cuando nos pregunte

## 3) Crearemos un espacio de trabajo o workspace en VSCode
- File/Save Workspace As... WAC

## 4) Crearemos un proyecto de Test para la WebAPI
- mkdir WAC.WebAPI.Tests
- dotnet new mstest
- Agregamos la referencia desde WAC.WebAPI.Tests a WAC.WebAPI
```
    dotnet add WAC.WebAPI.Tests/WAC.WebAPI.Tests.csproj reference WAC.WebAPI/WAC.WebAPI.csproj
```

## 5) Vamos a crear un Test para crear un Recurso Usuario 
- Definir el test unitario
- Crear una implementación básica 
- Creamos un UserCreationTest y definimos un primer método de Test
```C#
	[TestMethod]
	public void CreateValidUserTest()
	{
			//Arrange
            var modelIn = new UserModelIn() { Username = "Alberto", Password = "pass", Age = 2 }; 
            var controller = new UsersController();
            var result = controller.Post(modelIn);

            //Act
            var createdResult = result as CreatedAtRouteResult;
            var modelOut = createdResult.Value as UserModelOut;

            //Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("GetById", createdResult.RouteName);
            Assert.AreEqual(201, createdResult.StatusCode);
            Assert.AreEqual(modelIn.Username, modelOut.Username);
	}
```
- Agreguemos a el proyecto de tests la referencia a AspNetCore.Mvc.Core
```
	cd  WAC.WebAPI.Test
	dotnet add package  Microsoft.AspNetCore.Mvc.Core
```

## 6) Vamos a crear una implementación básica para que la prueba pase.
- Primero debemos crear un controller WebAPI, UsersController, podemos ya hacerlo con las operaciones por defecto. Luego si no usamos alguna podemos borrarlas.
- Cambiar los tipos de retorno a IActionResult
- Creamos una carpeta Models dentro del proyecto de WebAPI. Las clases dentro de está carpeta suelen llevar el namespace 
```C#
	namespace WAC.WebAPI.Models { }
```
- Estos modelos son las represetanción de nuestros recursos para los clientes de la API REST. El cliente hablará con la WebAPI REST por medio de estos modelos. 
**¿Podríamos usar las clases del dominio del negocio para esto?**
Poder podemos, pero estamos dando un motivo de cambio nuevo al dominio, esto va contra SRP. Las clases del dominio no deberían cambiar por motivos referentes a la implementación de REST ni por la comunicación cliente-servidor. Otra ventaja extra es que podemos tener distintas representaciones del recurso dependiendo de la petición (ej: in y out), o podemos ocultar cierta información (UserModelOut sin campo Password), entre otros. Sin embargo, debemos considerar que de cambiar el negocio y las clases del dominio, esto genera seguramente genere un impacto en los modelos.
- Crear los modelos UserModelIn y UserModelOut 
- Implementaremos la operación POST de forma muy básica en el controller utilizando los modelos creados.
	- Usaremos el Attribute [HttpPost] sobre el método Post (De forma similar existen HttpGet, HttpPut, HttpDelete, HttpPatch)
	- Recibiremos por parámetros desde el Body HTTP un UserModelIn. Para eso definiremos el método Post de la siguiente manera:
	```C#
		...Post([FromBody] UserModelIn user) {}
	```
	- Podemos usar [FromUri] [FromQuery] (entre otros) dependiendo de cómo queremos que el cliente envíe la información. 
	En caso de ser en la URL, específicamente en la URI, podemos usar el primero:
	```
		api/Users/{id} => api/Users/1
		//También podemos especificar condiciones
		api/Users/{id:min(18)}
	```
	- Si queremos que envíen ciertos parámetros como query "URI?param=1&param=2" podemos usar el segundo.
	- Usaremos para post un método ofrecido por ControllerBase llamado CreatedAtRoute:
	
	```C#
		return CreatedAtRoute("GetById", new { id = addedUser.Id }, addedUser);
	```
	
	- El primer parámetro referencia al Attribute del método get por id [HttpGet], como ven el mismo está definido de la siguiente forma:

	```C#
		[HttpGet("{id}", Name="GetById")]
	```
		
	- El segundo parámetro es el Id a colocar en la ruta del Get
	- El tercer parámetro es el objeto a devolver en el Body de la Response Http, UserModelOut.
	Utilizar CreatedAtRoute de esta forma, hará que la respuesta tenga un Header llamado **Location**, el cual tendrá el valor con la URL del Get referenciado. De esta forma sabemos como acceder al recurso una vez creado. 

