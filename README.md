# Aplicación de Lazy Loading, creación de Base de datos y primeros pasos con los Guards

## Descripción: En esta entrega se hizo una refactorización en la estructura del proyecto comenzando con las rutas y eliminando un módulo el cual más tarde indexamos su funcionabilidad en el módulo principal llamado Catalog. Implementamos el Lazy Loading en nuestros módulos y manejamos las rutas de manera correcta además de crear Guards que posteriormente nos ayudaran a proteger la sesión del usuario en todos los componentes

## Objetivos: 
1. Refactorizar la estructura proyecto y las rutas
2. Uso de LazyLoading
3. Implementación de Guards sobre las rutas para proteger la aplicación
4. Creación de la BD y su esquema

## Nombre: Eduardo Antonio Sandoval Adame (Proyecto: Megaplay)

## Importante: Se añadio un directorio en la raíz del proyecto llamado 'BD' que contiene el respaldo de mi base de datos, en caso de no poder importarla también se adjuntaron todos los scripts aparte para ejecutarlos al mismo tiempo y tener la misma estructura.

## Captura de pantalla:
Rutas con Lazy Loading en módulos
![image](https://github.com/user-attachments/assets/d68777c8-961f-4a13-b22a-3276754c915b)

Uso de Guards
![image](https://github.com/user-attachments/assets/df82968d-c120-4cf3-85f8-cecd69f748d3)

Esquema de mi base de datos 'Megaplay'
![Modelo_BD](https://github.com/user-attachments/assets/cca61870-37c1-4d82-943c-1def501f3ca3)

Implementación de vista Login
![image](https://github.com/user-attachments/assets/f5870b4e-d5a3-4c18-bc05-d586284f2199)

Guard configurado para que redirija al Login
![image](https://github.com/user-attachments/assets/67db580d-d77f-44f8-941e-29adfe6e16a5)
![image](https://github.com/user-attachments/assets/d220f134-c814-425d-9ef2-f0b2a22d7725)

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
En este sprint se siguio los pasos del challenger para implementar el lazy loading y los guards, asi mismo creamos la BD siguiendo sus consejos para posteriormente trabajar con la API rest que desarrollaremos

## Problemas conocidos:
1. Bugs al refactorizar la estructura del proyecto
2. El Guard no cargaba los componentes al estar mal configurado ya que no redirigia al login

## Retrospectiva.
### ¿Qué hice bien?
Reestructurar mi proyecto e implementar el lazy loading a los módulos
### ¿Qué no salió bien?
Falta de implementación de los test unitarios a mis nuevas funcionabilidades
### ¿Qué puedo hacer diferente?
Comprender el uso de .Net para crear mi API e implementar la lógica necesaria para posteriormente hacer una refactorización de las funciones de los servicios

    
