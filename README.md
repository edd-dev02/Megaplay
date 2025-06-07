# Aplicación API Megaplay, arquitectura Repository.

## Descripción: Este Sprint sentó las bases la API de megaplay para poder consumir los servicios de peliculas, añadir a favoritos y autenticación

## Objetivos: 
1. Crear un proyecto con .Net 8 y Entity Framework
2. Ligero rediseño en la BD implementando la metodología Code First
3. Crear y ejecutar las migraciones
4. Utilizar buenas prácticas implementando una lógica de 5 capas para las tablas implicadas (modelo, DTO, mapping, repositorio, controlador)
5. Probar los endpoints con Swagger

## Nombre: Eduardo Antonio Sandoval Adame (Proyecto: Megaplay)

## Captura de pantalla:
- Modelo E -R 
![Megaplay](https://github.com/user-attachments/assets/dc871469-7c47-4df0-87bd-fede67c1d4e9)

- Arquitectura de la API
![ArquitecturaAPI](https://github.com/user-attachments/assets/3c56175d-b508-46e6-b702-06b52f830eb0)

- Probando el Endpoint Get de la entidad Pelicula que involucra a las otras dos entidades
![PruebaAPI1](https://github.com/user-attachments/assets/8c98933d-21cb-45b0-ad5b-8c95270e05d4)
![PruebaAPI2](https://github.com/user-attachments/assets/7d63686f-df2c-4ff9-8401-6a4278c8479b)
![PruebaAPI3](https://github.com/user-attachments/assets/eb8cba90-a41f-4c51-b983-85f2686a73ab)


***
## Instrucciones para descargar el repo:
1. Clonar el repositorio en una carpeta
2. Ejecutar el comando dotnet run o usar la opción manual en VS Code
![image](https://github.com/user-attachments/assets/52e2bae2-bc6d-4711-ae3e-2092a070c5c3)
3. Probar los diferentes endpoints y sus 4 acciones en el panel de Swagger

## Dependencias utilizadas:
.Net:
AutoMapper — v14.0.0
Microsoft.EntityFrameworkCore.Design — v9.0.5
Microsoft.EntityFrameworkCore.SqlServer — v9.0.5
Microsoft.EntityFrameworkCore.Tools — v9.0.5
Swashbuckle.AspNetCore — v6.6.2

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
En este sprint creamos un proyecto en .Net 8 haciendo uso de buenas prácticas de código, implementando la metodología Code First para crear la BD mediante migraciones, se trabajo con 5 capas de lógica principalmente (modelo, DTO, mapping, repositorio, controlador) y para asegurar el funcionamiento se probaron todos los endpoints en Swagger

## Problemas conocidos:
1. Aprender C# desde cero y el framework de .Net en el tiempo de un Sprint
2. Relacionar modelos entre si para crear correctamente las capas de lógica de la API para seguir buenas prácticas
3. Mostrar los datos de géneros y secciones en las consultas de una pelicula
4. Falta de tiempo para terminar al 100% la API
5. Falta de conocimiento para llevar a cabo la autenticación tanto en el backend como en el frontend

## Retrospectiva.
### ¿Qué hice bien?
Crear la API con buenas prácticas y dejar funcionando correctamente los avances, poco más del 50% de totalidad de los requerimientos del Backend
### ¿Qué no salió bien?
No se logró terminar al 100% las funcionabilidades del backend ni tampoco lo integramos con el frontend
### ¿Qué puedo hacer diferente?
Investigar y poner en práctica lo necesario para terminar mi API y proceder a integrar todo con mi frontend

    
