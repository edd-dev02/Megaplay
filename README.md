# Entrega Sprint 6: Docker - Kubernetes / Integración del backend en el front

## Descripción: En este sprint logramos comunicar la parte del frontend de la aplicación con el backend mediante los endpoints

## Objetivos: 
1. Conclusión de las funcionabilidades del backend al 100% (Autenticación, protección con JWT, esquema relacional terminado)
2. Consumir los endpoints desde el frontend y manejar las peticiones mediante JWT
3. Creción de los contenedores en docker
4. Primeros pasos con Kubernetes

## Nombre: Eduardo Antonio Sandoval Adame (Proyecto: Megaplay)

## Capturas de pantalla:
- Boceto Meg![Boceto_Megaplay](https://github.com/user-attachments/assets/82b28281-d009-46c8-a869-9f52650cc88f)
aplay

- Modelo E -R 
![Megaplay](https://github.com/user-attachments/assets/dc871469-7c47-4df0-87bd-fede67c1d4e9)

- Containers generados en Docker:
![docker_containers](https://github.com/user-attachments/assets/19e49cab-47d4-437c-8a50-fe307205400f)

- Images generados en docker:
![docker_images](https://github.com/user-attachments/assets/8de371fe-fc18-4f61-9d22-fe3f2910f2be)

- Dockerfile Frontend
![docker_front](https://github.com/user-attachments/assets/615225cd-e6f0-4cc7-9da9-3f756e704c77)

- Dockerfile Backend
![docker_back](https://github.com/user-attachments/assets/d7878f6b-1664-46a3-9342-5c98feecca04)

- Proyecto ejecutandose localmente, implementando toda la funcionabilidad de la base de datos, backend y consumo de endpoints:
1. Pantallas para registrarse e iniciar sesión
![app_login](https://github.com/user-attachments/assets/6adf428b-183b-4614-b37f-25761cea5034)
![app_register](https://github.com/user-attachments/assets/3563e979-26ab-412b-8781-d9b9d6e820c5)

2. Consumo de endpoint para obtener las peliculas creadas.
**Importante:** Al realizar pruebas con la API de manera local, es necesario crear primero 'Generos' y 'Secciones', para que la aplicación pueda separar las peliculas en 3 diferentes secciones, se crean los nombres especificos de 3 diferentes secciones (Hero, Mas_vistos, Recomendados) esto para que el filtrado se lleve correctamente en el Frontend y se creen las 3 diferentes secciones.
Para agilizar pruebas en la herramienta Swagger de .Net del endpoint POST para peliculas se recomienda trabajar con los siguientes datos ya que las imagenes estan subidas en línea, solo cambian los campos 'genreId' y 'sectionId':
{
  "title": "El caballero de la noche",
  "description": "Batman se enfrenta al Joker dentro de la ciudad Gótica",
  "duration": "01:55:15",
  "score": 10,
  "trailer": "https://www.youtube.com/watch?v=EXeTwQWrcwY",
  "posterpath": "https://i.ibb.co/8nrdXspJ/dark-knight.webp",
  "genreId": 1,  
  "sectionId": 4,  
}

{
  "title": "Interstellar",
  "description": "Un grupo de astronautas busca un nuevo hogar para la humanidad.",
  "duration": "02:49",
  "score": 9.3,
  "trailer": "https://www.youtube.com/watch?v=zSWdZVtXT7E",
  "posterpath": "https://i.ibb.co/FL9pWkXJ/interstellar.webp",
  "genreId": 1,
  "sectionId": 1
}

{
  "title": "300",
  "description": "El rey Leónidas lidera a 300 espartanos contra el ejército persa en una batalla épica.",
  "duration": "01:55:17",
  "score": 9.7,
  "trailer": "https://www.youtube.com/watch?v=UrIbxk7idYA",
  "posterpath": "https://i.ibb.co/N62w9sp8/300.jpg",
  "genreId": 1,
  "sectionId": 2
}

Una vez que se insertan los datos necesarios, se podrán visualizar las peliculas filtradas por secciones.
![app_catalogo](https://github.com/user-attachments/assets/4e0adc8b-56da-4b1a-bed2-63d004eca59d)

El JWT se maneja en localStorage, se guarda en automatico al iniciar sesión y con ayuda de un Interceptor en Angular se manda en el header de las peticiones.
![app_jwt](https://github.com/user-attachments/assets/d67184bb-31a8-4c30-b5ff-c24218a7e948)

El Token tiene una fecha de expiración de 2 horas, por lo que pasado ese tiempo el usuario es redirigido al Login para que vuelva a iniciar sesión

***
## Instrucciones para descargar el repo:
1. Clonar el repositorio en una carpeta
2. Ejecutar el comando dotnet run o usar la opción manual en VS Code dentro de la carpeta de API_megaplay para levantar el lado del servidor
![image](https://github.com/user-attachments/assets/52e2bae2-bc6d-4711-ae3e-2092a070c5c3)
3. En otra terminal ejecutar el comando ng serve dentro de la carpeta megaplay para levantar el lado del cliente (Antes realizar pruebas en endpoint's con Postman, ya que para consultar peliculas es necesario mandar en el header el token)
![postman_pruebaGET](https://github.com/user-attachments/assets/2e4da0bb-81ed-48f6-a815-206dbd6dd310)

## Dependencias utilizadas:
.Net:
AutoMapper – v14.0.0
Para el mapeo automático entre entidades y DTOs.

BCrypt.Net-Next – v4.0.3
Para el cifrado seguro de contraseñas con el algoritmo BCrypt.

Microsoft.AspNetCore.Authentication.JwtBearer – v8.0.17
Para la autenticación basada en tokens JWT.

Microsoft.EntityFrameworkCore.Design – v9.0.5
Herramientas de desarrollo para Entity Framework Core (migraciones, scaffolding).

Microsoft.EntityFrameworkCore.SqlServer – v9.0.5
Proveedor de EF Core para trabajar con bases de datos SQL Server.

Microsoft.EntityFrameworkCore.Tools – v9.0.5
Herramientas CLI para EF Core (usadas con dotnet ef).

Swashbuckle.AspNetCore – v6.6.2
Para la generación de documentación interactiva de APIs con Swagger/OpenAPI.

Angular:
{
  "name": "megaplay",
  "version": "0.0.0",
  "scripts": {
    "ng": "ng",
    "start": "ng serve",
    "build": "ng build",
    "watch": "ng build --watch --configuration development",
    "test": "ng test"
  },
  "private": true,
  "dependencies": {
    "@angular/animations": "^17.0.0",
    "@angular/common": "^17.0.0",
    "@angular/compiler": "^17.0.0",
    "@angular/core": "^17.0.0",
    "@angular/forms": "^17.0.0",
    "@angular/platform-browser": "^17.0.0",
    "@angular/platform-browser-dynamic": "^17.0.0",
    "@angular/router": "^17.0.0",
    "rxjs": "~7.8.0",
    "tslib": "^2.3.0",
    "zone.js": "~0.14.2"
  },
  "devDependencies": {
    "@angular-devkit/build-angular": "^17.0.9",
    "@angular/cli": "^17.0.9",
    "@angular/compiler-cli": "^17.0.0",
    "@types/jasmine": "~5.1.0",
    "jasmine-core": "~5.1.0",
    "karma": "~6.4.0",
    "karma-chrome-launcher": "~3.2.0",
    "karma-coverage": "~2.2.0",
    "karma-jasmine": "~5.1.0",
    "karma-jasmine-html-reporter": "~2.1.0",
    "typescript": "~5.2.2"
  }
}
## ¿Cómo se realizó el proyecto?
Se concluyó la construcción total de la API en .Net con una arquitectura que abarca la metodología 'Codefirst' por lo que trabajamos con migraciones. Para hacer pruebas con los endpoints utilizamos DTO's para no usar directamente el modelo principal de las tablas, se realizó la conversión mediante AutoMapper. Implementamos repositorios para manejar las acciones en la base de datos, se implemento el CORS para proteger rutas y finalmente el uso de autenticación mediante el JWT, después se consumieron los endpoints desde el Frontend logrando un correcto funcionamiento. Finalmente se subieron las carpetas tanto de la API como de la aplicación de Angular en Docker.

## Problemas conocidos:
1. Manejo de rxjs para implementar correctamente los endpoints
2. Dificultad para gestionar el JWT mediante un interceptor
3. Problemas en la terminal de comandos para implementar Docker

## Retrospectiva.
### ¿Qué hice bien?
La API quedó 100% funcional, con una arquitectura profesional y segura, el frontend está modularizado y su mantenimiento es sencillo.
### ¿Qué no salió bien?
Por los recortes de tiempo de entrega del sprint algunas funcionabilidades no se lograron implementar en el lado del Frontend
### ¿Qué puedo hacer diferente?
Especializarme en un rol en especifico, fue verdaderamente un reto abarcar tecnologías tanto frontend como backend en este proyecto, mas que nada por los tiempos recortados para aprender e ir aplicando todo, sin embargo aprendí mucho.

    
