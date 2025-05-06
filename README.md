# Implementación de la funcionabilidad agregar y quitar a favoritos, mejoras en la lógica del servicio y testing unitario.

## Descripción: En esta entrega se trabajó en la funcionabilidad para agregar o quitar peliculas en favoritos, se implementaron las rutas y se trabajó con localStorage en la ruta de favoritos y toda su funcionabilidad implicada

## Objetivos: 
1. Crear las rutas necesarias del proyecto (principalmente home y favorites)
2. Implementar el router
3. Crear nuevo módulo para las peliculas añadidas en favoritos
4. Implementar nuevas funcionabilidades en el servicio de la pelicula principal
5. Trabajar en la lógica para agregar, eliminar y mostrar las peliculas del localStorage

## Nombre: Eduardo Antonio Sandoval Adame (Proyecto: Megaplay)

## Captura de pantalla:
Aplicación mostrando la funcionabilidad de favoritos.
![app1](https://github.com/user-attachments/assets/985c70c8-e743-48d2-a631-de326cc83b69)
![app2](https://github.com/user-attachments/assets/c2f99fff-3c7b-45db-9e9b-70d378163bc6)
*** 
Reportes de test´s unitarios.
![testing1](https://github.com/user-attachments/assets/18a2bbb9-5951-4794-9bdc-1af5678ee9c7)
![testing2](https://github.com/user-attachments/assets/92003ef9-95c3-4359-9a00-7a3df756409c)
![testing3](https://github.com/user-attachments/assets/0f41be68-0f1b-45f8-825e-5871c4b55752)
![testing4](https://github.com/user-attachments/assets/84fa2e9f-4355-42e3-abcd-26c9885bef9f)
***
## Instrucciones para descargar el repo:
1. Clonar el repositorio en una carpeta
2. Ejecutar el comando 'npm install' para que se cree el node_modules
3. Levantar el servidor con 'ng serve -o'

## Dependencias utilizadas:
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
A medida que he ido adquiriendo nuevos conocimientos y ganado mas experiencia con Angular, hice una ligera re-estructuración del proyecto, primero me asegure de crear un nuevo módulo para favoritos y posteriormente implementar toda la funcionabilidad para utilizar el router, después hice modificaciones en mi intarfaz de la pelicula para añadir ID's ya que estos me permitieron trabajar con el localStorage de manera sencilla.
Después comence a trabajar en la funcionabilidad para añadir a favoritos, hice modificaciones en mi componente de la card de la pelicula principal para que ciertas partes del contenido sea dinámico como por ejemplo cambiar los estilos del botón para añadir o quitar una pelicula, después trabajamos en los servicios de ambos módulos para que toda la lógica funcione perfectamente y finalmente mostrar una vista 

## Problemas conocidos:
1. Trabajar el router con diferentes módulos, se contempla la posibilidad de usar rutas hijas en un futuro.
2. Aplicación de test unitarios
3. Dificultad para que la lógica del localStorage funcione bien.

## Retrospectiva.
### ¿Qué hice bien?
Modularizar mejor mi aplicación, hacer mejoras en mi interfaz, implementar y documentar una lógica sencilla para agregar a favoritos
### ¿Qué no salió bien?
Los test unitarios no son correctos debido a la falta de conocimiento, no pude dedicar tanto tiempo a aprender testing ya que aun me encuentro en la curva de aprendizaje para comprender Angular
### ¿Qué puedo hacer diferente?
Dedicar mas tiempo de estudio a los test unitarios

    
