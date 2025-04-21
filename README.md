# Migración de 'MegaPlay" hacia Angular

## Descripción: En esta entrega del Sprint logramos migrar el proyecto a una versión actualizada de Angular utilizando módulos y el resultado fue idéntico a a lo trabajado con la versión Vanilla.

## Objetivos: 
1. Migrar el proyecto Vanilla a una rama Legacy
2. Comprender los fundamentales de Angular para lograr la migración
3. Establecer una estructura modular en la arquitectura del proyecto
4. Dividir en componentes nuestra aplicación
5. Implementar un servicio para simular el consumo de una API y lograr iterar sobre las películas

## Nombre: Eduardo Antonio Sandoval Adame

## Captura de pantalla:
![image](https://github.com/user-attachments/assets/c74989dd-b461-4707-8d6d-92596ce137b3)
## Instrucciones para descargar el repo:
1. Clonar el repositorio en una carpeta
2. Ejecutar el comando 'npm install' para que se cree el node_modules
3. Levantar el servidor con 'ng serve -o'

## Dependencias utilizadas:
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
## ¿Cómo se realizó el proyecto?
Se optó por crear un proyecto con módulos, por lo cual los componentes Standalone no están activados en el proyecto, esto ya que considero que una estructura modular ayuda bastante a comprender la arquitectura de un proyecto en Angular.
Se tiene principalmente el módulo 'catalog' donde por el momento solo se tiene la barra de navegación y el componente que muestra las películas.
Asi mismo, ese componente utiliza un servicio para iterar sobre el JSON que contiene todas las películas.

## Problemas conocidos:
1. Las importaciones marcaron cierta dificultad al momento de ir completando cada funcionabilidad, sin embargo, con apoyo de mis compañeros logré solucionar la mayoría de errores rápidamente.

## Retrospectiva.
### ¿Qué hice bien?
Considero que el haber comprendido bien el como funcionan los módulos en Angular me ayuda a mantener una arquitectura limpia y fácil de comprender, asi mismo el apoyo del servicio y el uso de directivas me ayudaron a lograr mi objetivo de iterar rápidamente sobre las películas.
### ¿Qué no salió bien?
La curva de aprendizaje de Angular resultó ser complicada al principio ya que tuve que aprender rápidamente TypeScript, asi mismo antes de comenzar la migración tuve que estudiar y prácticar todos los temas anteriormente mencionados.
Al haber dedicado mucho tiempo al aprendizaje de esta nueva herramienta no pude completar satisfactoriamente las funcionabilidades pendientes: Agregar a favoritos, Inicio de sesión simulado y manejo de rutas.
Por último, aún faltan detalles que afinar del diseño.
### ¿Qué puedo hacer diferente?
Definitivamente ahora que ya comprendo las bases puedo avanzar más rápido y aprender conceptos nuevos sin tener tantas complicaciones.

    
