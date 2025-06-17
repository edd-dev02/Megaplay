using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using API_megaplay.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_megaplay.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace API_megaplay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // Endpoint obtener los usuarios
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            var usersDto = _mapper.Map<List<UserDto>>(users);

            return Ok(usersDto);
        }

        // Endpoint para obterner un usuario mediante el ID
        [HttpGet("{userId:int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Usuario no encontrado
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUser(int userId) // El nombre del parametro debe ser igual al reflejado en la ruta de la propiedad
        {
            var user = _userRepository.GetUser(userId);

            if (user == null)
            {
                return NotFound($"El usuario con el ID {userId} no existe");
            }

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        // Endpoint para crear un usuario
        [HttpPost(Name = "RegisterUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status201Created)] // Se creó correctamente
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Error en el servidor
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto createUserDto)
        {
            if (createUserDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(createUserDto.Email))
            {
                return BadRequest("El email es requerido");
            }

            if (!_userRepository.IsUniqueUser(createUserDto.Email))
            {
                return BadRequest($"El email '{createUserDto.Email} ya está registrado");
            }

            var result = await _userRepository.Register(createUserDto);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al registrar el usuario");
            }

            return CreatedAtRoute("GetUser", new { userId = result.UserId }, result);
        }

        // Endpoint para iniciar sesión mediante credenciales
        [HttpPost("Login", Name = "LoginUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status200OK)] // Se creó correctamente
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Error en el servidor
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto userLoginDto)
        {
            if (userLoginDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepository.Login(userLoginDto);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }

        // Endpoint para actualizar un usuario
        [HttpPut("{userId:int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status204NoContent)] // Se actualizó correctamente
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateUser(int userId, [FromBody] UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null)
            {
                return BadRequest(ModelState);
            }

            var existingUser = _userRepository.GetUser(userId);
            if (existingUser == null)
            {
                ModelState.AddModelError("CustomError", $"El usuario con el ID {userId} no existe");
                return BadRequest(ModelState);
            }

            // Actualizar solo los campos que vienen en el DTO
            existingUser.Username = updateUserDto.Username;
            existingUser.Email = updateUserDto.Email;

            if (!_userRepository.UpdateUser(existingUser))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al actualizar el registro {existingUser.Username}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        // Endpoint eliminar un usuario
        [HttpDelete("{userId:int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Usuario no encontrado
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteUser(int userId) // El nombre del parametro debe ser igual al reflejado en la ruta de la propiedad
        {
            if (userId == 0)
            {
                return BadRequest(ModelState);
            }

            var user = _userRepository.GetUser(userId);

            if (user == null)
            {
                return NotFound($"El usuario con el ID {userId} no existe");
            }

            if (!_userRepository.DeleteUser(user))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al eliminar el registro {user.Username}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}