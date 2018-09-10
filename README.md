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
