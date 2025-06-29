using API_megaplay.Constants;
using API_megaplay.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_megaplay.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(PolicyNames.AllowSpecificOrigin)] // Habilitar CORS para proteger este controlador
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesRepository _favoritesRepository;
        private readonly IMapper _mapper;

        public FavoritesController(IFavoritesRepository favoritesRepository, IMapper mapper)
        {
            _favoritesRepository = favoritesRepository;
            _mapper = mapper;
        }



        // Endpoint obtener las peliculas favoritas de un usuario mediante el ID
        [HttpGet("movies")]
        public async Task<IActionResult> GetFavoriteMoviesByUser()
        {
            // Obtener el ID del usuario desde el token
            var userIdClaim = User.FindFirst("id")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized("No se pudo validar el usuario.");
            }

            var favorites = await _favoritesRepository.GetFavoriteMoviesByUser(userId);

            if (favorites == null || !favorites.Any())
            {
                return NotFound($"El usuario no tiene películas favoritas.");
            }

            return Ok(favorites);
        }


        // Endpoint para agregar favoritos a un determinado usuario
        [HttpPost("add")]
        public IActionResult AddToFavorites([FromQuery] int movieId)
        {
            var userIdClaim = User.FindFirst("id")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized("No se pudo validar el usuario.");
            }

            var userExists = _favoritesRepository.UserExists(userId);
            var movieExists = _favoritesRepository.MovieExists(movieId);
            var alreadyFavorite = _favoritesRepository.IsFavorite(userId, movieId);

            if (!userExists)
                return NotFound($"El usuario con ID {userId} no existe.");

            if (!movieExists)
                return NotFound($"La película con ID {movieId} no existe.");

            if (alreadyFavorite)
                return Conflict("La película ya está en favoritos.");

            var result = _favoritesRepository.AddToFavorites(userId, movieId);

            if (!result)
                return StatusCode(500, "Error al agregar la película a favoritos.");

            return Ok("Película agregada a favoritos correctamente.");
        }


        // Endpoint para eliminar favoritos de un usuario
        [HttpDelete("remove")]
        public IActionResult RemoveFromFavorites([FromQuery] int movieId)
        {
            var userIdClaim = User.FindFirst("id")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized("No se pudo validar el usuario.");
            }

            var result = _favoritesRepository.RemoveFromFavorites(userId, movieId);

            if (!result)
            {
                return NotFound("No se encontró esa película en los favoritos del usuario.");
            }

            return Ok("Película eliminada de favoritos correctamente.");
        }

    }
}