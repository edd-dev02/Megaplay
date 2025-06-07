using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using API_megaplay.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_megaplay.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepo;
    private readonly IGenreRepository _genreRepo;
    private readonly ISectionRepository _sectionRepo;
    private readonly IMapper _mapper;

    public MoviesController(IMovieRepository movieRepo, IGenreRepository genreRepo, ISectionRepository sectionRepo, IMapper mapper)
    {
        _movieRepo = movieRepo;
        _genreRepo = genreRepo;
        _sectionRepo = sectionRepo;
        _mapper = mapper;
    }

    // Endpoint obtener peliculas
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<MovieDto>> GetMovies()
    {
        var movies = _movieRepo.GetMovies();
        var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(movies);
        return Ok(moviesDto);
    }

    [HttpGet("{id:int}", Name = "GetMovie")]
    public ActionResult<MovieDto> GetMovie(int id)
    {
        var movie = _movieRepo.GetMovie(id);
        if (movie == null)
        {
            return NotFound($"La pelicula con el ID {id} no existe");
        }

        var movieDto = _mapper.Map<MovieDto>(movie);
        return Ok(movieDto);
    }

    // Endpoint para crear una pelicula nueva
    [HttpPost]
    public ActionResult CreateMovie([FromBody] CreateMovieDto createDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (!_genreRepo.GenreExists(createDto.GenreId))
            return BadRequest("El género especificado no existe.");

        // 🔍 Verificación de la sección
        if (!_sectionRepo.SectionExists(createDto.SectionId))
            return BadRequest("La sección especificada no existe.");

        if (_movieRepo.MovieExists(createDto.Title))
        {
            ModelState.AddModelError("Title", "Ya existe una película con ese título.");
            return Conflict(ModelState);
        }

        var movie = _mapper.Map<Movie>(createDto);

        if (!_movieRepo.CreateMovie(movie))
        {
            ModelState.AddModelError("", "Algo salió mal al guardar la película.");
            return StatusCode(500, ModelState);
        }

        var movieDto = _mapper.Map<MovieDto>(movie);

        return CreatedAtRoute("GetMovie", new { id = movie.Id }, movieDto);
    }


    [HttpPut("{id:int}")]
    public IActionResult UpdateMovie(int id, [FromBody] CreateMovieDto updateDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var movie = _movieRepo.GetMovie(id);
        if (movie == null) return NotFound();

        _mapper.Map(updateDto, movie);

        if (!_movieRepo.UpdateMovie(movie))
        {
            ModelState.AddModelError("", "Error al actualizar la película.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _movieRepo.GetMovie(id);
        if (movie == null) return NotFound();

        if (!_movieRepo.DeleteMovie(movie))
        {
            ModelState.AddModelError("", "Error al eliminar la película.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }
}
