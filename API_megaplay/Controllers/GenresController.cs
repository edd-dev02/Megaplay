using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using API_megaplay.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_megaplay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        // Inyección de dependencias
        public GenresController(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        // Endpoint para obtener todos los géneros
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetGenres()
        {
            var genres = _genreRepository.GetGenres();
            var genresDto = new List<GenreDto>();

            foreach (var genre in genres)
            {
                genresDto.Add(_mapper.Map<GenreDto>(genre));
            }

            return Ok(genresDto);
        }

        // Endpoint para obtener un género mediante el id
        [HttpGet("{id:int}", Name = "GetGenre")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Categoria no encontrada
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetGenre(int id) // El nombre del parametro debe ser igual al reflejado en la ruta de la propiedad
        {
            var genre = _genreRepository.GetGenre(id);

            if (genre == null)
            {
                return NotFound($"El género con el ID {id} no existe");
            }

            var genreDto = _mapper.Map<GenreDto>(genre);

            return Ok(genreDto);
        }

        // Endpoint crear un nuevo género
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status201Created)] // Se creó correctamente
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Error en el servidor
        public IActionResult CreateGenre([FromBody] CreateGenreDto createGenreDto)
        {
            if (createGenreDto == null)
            {
                return BadRequest(ModelState);
            }

            // Verificar que no exista el género que se quiere crear
            if (_genreRepository.GenreExists(createGenreDto.GenreName))
            {
                ModelState.AddModelError("CustomError", "El género ya existe");
                return BadRequest(ModelState);
            }

            // Convertir la entidad del DTO en una entidad de dominio
            var genre = _mapper.Map<Genre>(createGenreDto);

            if (!_genreRepository.CreateGenre(genre))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al guardar el registro {genre}");
                return StatusCode(500, ModelState);
            }

            // Si todo salió bien
            return CreatedAtRoute("GetGenre", new { id = genre.Id }, genre);
        }

        // Endpoint para actualizar un Genre
        [HttpPatch("{id:int}", Name = "UpdateGenre")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Categoria no encontrada
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Error en el servidor
        public IActionResult UpdateGenre(int id, [FromBody] CreateGenreDto updateGenreDto)
        {
            // Verificar si existe la categoría
            if (!_genreRepository.GenreExists(id))
            {
                return NotFound($"El género con el ID {id} no existe");
            }

            // Verificar que no sea nulo
            if (updateGenreDto == null)
            {
                return BadRequest(ModelState);
            }

            // Convertir la entidad del DTO en una entidad de dominio
            var genre = _mapper.Map<Genre>(updateGenreDto);

            genre.Id = id;

            if (!_genreRepository.UpdateGenre(genre))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al actualizar el registro {genre.GenreName}");
                return StatusCode(500, ModelState);
            }

            // Si todo salió bien
            return NoContent();
        }

        // Endpoint eliminar un genre
        [HttpDelete("{id:int}", Name = "DeleteGenre")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Categoria no encontrada
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Error en el servidor
        public IActionResult DeleteGenre(int id)
        {
            // Verificar si existe el género
            if (!_genreRepository.GenreExists(id))
            {
                return NotFound($"El género con el ID {id} no existe");
            }

            var genre = _genreRepository.GetGenre(id);

            // Validar que no sea nulo
            if (genre == null)
            {
                return NotFound($"El género con el ID {id} no existe");
            }

            genre.Id = id;

            if (!_genreRepository.DeleteGenre(genre))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al eliminar el registro {genre.GenreName}");
                return StatusCode(500, ModelState);
            }

            // Si todo salió bien
            return NoContent();
        }
    }
}
