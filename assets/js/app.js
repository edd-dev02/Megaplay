import { peliculas } from "./data.js";

document.addEventListener('DOMContentLoaded', loadMovies);

function loadMovies() {
    const seccionTrend = document.getElementById('contenedor-trend');
    const seccionMasVistos = document.getElementById('contenedor-masVistos');
    const seccionRecomendados = document.getElementById('contenedor-recomendados');

    // Iterar sobre cada categoria
    for (let categoria in peliculas) {

        const cardsPeliculas = crearCardsPeliculas(peliculas[categoria]);

        switch (categoria) {
            case 'hero':
                // Mostrar solo una pelicula en la sección trend
                cardsPeliculas.forEach(card => seccionTrend.appendChild(card));
                break;

            case 'mas_vistas':
                cardsPeliculas.forEach(card => seccionMasVistos.appendChild(card));
                break;

            case 'recomendados':
                cardsPeliculas.forEach(card => seccionRecomendados.appendChild(card));

            default:
                console.log(`Categoría desconocida: ${categoria}`);
        }

    }
}

function crearCardsPeliculas(listaPeliculas) {

    return listaPeliculas.map(pelicula => {

        // Contenedor pelicula
        const contenedorPelicula = document.createElement('div');
        contenedorPelicula.classList.add('pelicula', 'my-5');

        // Contenedor imagen de la pelicula
        const contenedorImagen = document.createElement('div');
        contenedorPelicula.classList.add('contenedorImagen');

        // Imagen
        const imagen = document.createElement('img');
        imagen.src = `./assets/${pelicula.imagen}`;
        imagen.alt = 'Imagen de la pelicula';

        contenedorImagen.appendChild(imagen); // AGREGAR A PELICULA

        contenedorPelicula.appendChild(contenedorImagen);

        // Contenedor datos de las peliculas
        const datosPelicula = document.createElement('div');
        datosPelicula.classList.add('datos-pelicula');

        // Contenedor detalles de la pelicula
        const detallesPelicula = document.createElement('div');
        detallesPelicula.classList.add('detalles-pelicula');

        // Párrafos de los detalles
        const elementoDuracion = document.createElement('p');
        elementoDuracion.classList.add('text-light');
        const spanElementoDuracion = document.createElement('span');
        spanElementoDuracion.classList.add('fw-bold');
        spanElementoDuracion.textContent = 'Duración: ';
        elementoDuracion.appendChild(spanElementoDuracion);
        elementoDuracion.append(pelicula.duracion);

        const elementoGenero = document.createElement('p');
        elementoGenero.classList.add('text-light');
        const spanElementoGenero = document.createElement('span');
        spanElementoGenero.classList.add('fw-bold');
        spanElementoGenero.textContent = 'Genero: ';
        elementoGenero.appendChild(spanElementoGenero);
        elementoGenero.append(pelicula.genero);

        detallesPelicula.appendChild(elementoDuracion);
        detallesPelicula.appendChild(elementoGenero);

        datosPelicula.appendChild(detallesPelicula);

        // Contenedor información de la pelicula
        const informacionPelicula = document.createElement('div');
        informacionPelicula.classList.add('informacion-pelicula');

        // Titulo
        const tituloPelicula = document.createElement('h3');
        tituloPelicula.classList.add('text-light');
        tituloPelicula.textContent = pelicula.titulo;
        informacionPelicula.appendChild(tituloPelicula);

        // Descripcion
        const descripcionPelicula = document.createElement('p');
        descripcionPelicula.classList.add('text-light');
        descripcionPelicula.textContent = pelicula.descripcion;
        informacionPelicula.appendChild(descripcionPelicula);

        // Calificacion
        const calificacionPelicula = document.createElement('p');
        calificacionPelicula.classList.add('calificacion');
        const iconoCalificacion = document.createElement('i');
        iconoCalificacion.classList.add('fa-solid', 'fa-star');
        calificacionPelicula.appendChild(iconoCalificacion);
        const spanCalificacion = document.createElement('span');
        spanCalificacion.textContent = ' Calificación: ';
        calificacionPelicula.append(spanCalificacion);
        calificacionPelicula.append(pelicula.calificacion);
        informacionPelicula.appendChild(calificacionPelicula);

        // Contenedor de las acciones (Va dentro de informacionPelicula también)
        const contenedorAcciones = document.createElement('div');
        contenedorAcciones.classList.add('acciones');

        // Botones de acciones
        const verAhoraBtn = document.createElement('button');
        verAhoraBtn.classList.add('ver-ahora', 'fw-bold');
        const icono_verAhotaBtn = document.createElement('i');
        icono_verAhotaBtn.classList.add('fa-solid', 'fa-film');
        verAhoraBtn.appendChild(icono_verAhotaBtn);
        verAhoraBtn.append(' Ver ahora');
        contenedorAcciones.appendChild(verAhoraBtn);

        const agregarFavBtn = document.createElement('button');
        agregarFavBtn.classList.add('favorito', 'fw-bold');
        const icono_agregarFavBtn = document.createElement('i');
        icono_agregarFavBtn.classList.add('fa-solid', 'fa-heart');
        agregarFavBtn.appendChild(icono_agregarFavBtn);
        agregarFavBtn.append(' Favoritos');

        contenedorAcciones.appendChild(agregarFavBtn);

        informacionPelicula.appendChild(contenedorAcciones);

        datosPelicula.appendChild(informacionPelicula);

        contenedorPelicula.appendChild(datosPelicula);

        return contenedorPelicula;

    });
}
