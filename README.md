# Megaplay
Plataforma en línea que permite reproducir títulos de peliculas populares separadas por secciones, esta aplicación puede agregar titulos a una sección de favoritos, tanto esta como otras caracteristicas de momento se encuentran en desarrollo y son funcionalidades consideradas para el Backlog.

Imagenes de la aplicación.
![login_megaplay](https://github.com/user-attachments/assets/88f90298-b511-4cb5-9fd8-988a5a166846)

![megaplay_ss1](https://github.com/user-attachments/assets/8cde88d0-e336-43e5-9a1e-e0c8f4a8bec8)

![megaplay_ss2](https://github.com/user-attachments/assets/bda3f4c1-de1f-49b0-a327-218033e12658)

![megaplay_ss3](https://github.com/user-attachments/assets/158c7f5b-e8bf-482f-82d2-01122ce8f484)

Mockup

![mockup_megaplay](https://github.com/user-attachments/assets/a35c84eb-0420-44a2-8c8b-0cb9a8c44900)

Instrucciones para levantar este proyecto:
1. En VSC crear una carpeta vacía
2. Iniciar con un 'git init'
3. utilizar el comando git clone 'url_repositorio.git'
4. Visualizar el index.html con la extensión 'live-server'

¿Cómo se hizo esta versión del proyecto?
Trabajamos con las tecnologías base de HTML, CSS Y JavaScript. Asi mismo, nos apoyamos de la libreria de Bootstrap para componentes tales como la barra de navegación y en los próximos commits haremos uso de otros componentes para nuevas funcionabilidades, también usamos la librería font awesome para los iconos en la interfaz.
Nuestro archivo principal de JS es de tipo módulo para utilizar las funcionabilidades de import's y export's esto para poder modularizar nuestra aplicación en diferentes archivos y que sea de fácil mantenimiento.
La lógica de la app consiste en recorrer un objeto principal que contiene arreglos de categorías de diferentes secciones de la app, cada sección contiene sus peliculas.
Mediante DOM Scripting y el apoyo de diferentes estructuras de iteración vamos creando y mostrando componentes tipo Card para cada pelicula.

Problemas conocidos:
El DOM Scripting fue un poco confuso ya que se ocupo aprender en que situaciones usar appendChild() o append() esto para no sobreescribir elementos y poder mostrar todo correctamente.
No se logro emular primeramente el archivo login.html para después acceder a la vista principal (index.html)

¿Qué hice bien?
Considero que los puntos fuertes son que el diseño esta usable, bien adaptado y no queda mucho pendiente para terminar el responsive de manera adecuada.
También el separar mi aplicación por funciones y módulos la hace más mantenible con el tiempo
Emplear librerías me ahorra un poco de trabajo para el diseño y componentes.
Utilice el DOM Scripting para mostrar los elementos HTML de manera segura y poder evitar inyecciones de JS

¿Qué no salió bien?
No logré emular el login como primera vista, se tiene que acceder a él de momento siguiendo la ruta del directorio

¿Qué puedo hacer diferente?
Se puede mejorar el diseño y la usabilidad, debido a falta de conocimientos en UX/UI.
