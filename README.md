# Web-Api-Core-Example

Vamos a crear un proyecto de Web Api Core paso a paso.

1) Primer paso será crear la carpeta y luego el proyecto de Web Api Core
- mkdir WAC.WebAPI
- cd WAC.WebAPI
- dotnet new webapi -au None --no-https

2) Abrimos la carpeta con Visual Studio Code
- cd ..
- start .
- Open With Visual Studio Code
- Añadimos las Extensiones de C# a WAC.WebApi cuando nos pregunte

3) Crearemos un espacio de trabajo o workspace en VSCode
- File/Save Workspace As... WAC

4) Crearemos un proyecto de Test para la WebAPI
- mkdir WAC.WebAPI.Tests
- dotnet new mstest
- Agregamos la referencia desde WAC.WebAPI.Tests a WAC.WebAPI
```
    dotnet add WAC.WebAPI.Tests/WAC.WebAPI.Tests.csproj reference WAC.WebAPI/WAC.WebAPI.csproj
```

5) Vamos a crear un Test para crear un Recurso Usuario 
- Definir el test unitario
- Crear una implementación básica 
- Creamos un UserCreationTest y definimos un primer método de Test
```
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