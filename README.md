# WebAppUsers

## Descripción

**WebAppUsers** es un sistema de gestión de usuarios desarrollado con .NET Core 8, que sigue los principios de la arquitectura MVC. Esta aplicación permite registrar, editar y eliminar usuarios. Además, se utiliza ASP.NET Core MVC para la capa de presentación, ASP.NET Core Web API para el manejo de servicios, SQL Server como base de datos y Entity Framework Core para el acceso a datos. La seguridad de las contraseñas se gestiona mediante encriptación.

## Características

- **Gestión de Usuarios**: Registro, edición y eliminación de usuarios.
- **Arquitectura MVC**: Separación de preocupaciones con modelos, vistas y controladores.
- **API RESTful**: Interfaz API para operaciones CRUD.
- **Seguridad**: Contraseñas encriptadas.
- **Swagger**: Documentación automática de la API.
- **Bootstrap**: Interfaz de usuario moderna y responsiva.

## Elementos usados

- .NET Core 8 SDK
- SQL Server
- Visual Studio 2022 

## Configuración del Proyecto

1. **Clonar el Repositorio**
   ```bash
   git clone https://github.com/tu-usuario/WebAppUsers.git
   cd WebAppUsers


**Configurar la Cadena de Conexión
Edita el archivo appsettings.json para configurar la cadena de conexión a tu base de datos SQL Server.

*Restaurar Dependencias y Compilar
*Aplicar Migraciones y Crear la Base de Datos
se puede realizar mediante el siguiente comando: dotnet ef database update


Uso de Swagger
Swagger está integrado para facilitar la documentación y prueba de la API. Para acceder a la interfaz de Swagger, navega a:
https://localhost:puerto/api-docs

Estructura del Proyecto
Controllers: Contiene los controladores MVC y API.
Models: Define los modelos de datos.
Views: Contiene las vistas MVC.
Services: Contiene los servicios de negocio. aunque con el fin de no complejisar el proyecto se trabajo sobre el proyecto inicial se puede realizar la separacion de toda esta logica a una estructura de librerias
DataContext: Contexto de la base de datos y configuración de Entity Framework Core.
Inyección de Dependencias:
El proyecto utiliza la inyección de dependencias para gestionar la vida útil de los servicios y el contexto de la base de datos. Esto esta configurado en Program.cs.
el proyecto sigue los principios SOLID para asegurar un código mantenible y extensible.

Contribuciones
Las contribuciones son siempre bienvenidas.

Uso de Docker

se realizo la dokerizacion tanto de la bd como del proyecto como tal se realizo la creacion tanto del archivo dockerfile como del dockerCompose
en donde encontraran las especificaciones de lo que se esta dokerizando, al ejecutar dockercompose se realizara la creacion de 2 contenedores el contenedor de bd 
y el contenedor de la apliacicion asi como sus respectivas imagenes usando sql server como bd, y una aplicacion Net core 8.
para la creacion esta como pre requisito el que la bd este areriba asi como que sea accesible por el contenedor de la app adicionalmente la aplicacion ejecutara las migraciones de manera automatica una vez se inicie la aplicacion

Contacto
Autor: Jeison
Email: Jeison2023@yahoo.es
LinkedIn:https://www.linkedin.com/in/jeison-vargas-b66a78b4