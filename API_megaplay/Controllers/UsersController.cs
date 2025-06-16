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


        // Endpoint de Authentication
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return BadRequest("Email y contraseña son requeridos.");
            }

            // Buscar el usuario por su email
            var userFromDb = _userRepository.GetUserByEmail(loginDto.Email);

            if (userFromDb == null)
            {
                return Unauthorized("Credenciales inválidas.");
            }

            // Encriptar la contraseña proporcionada y compararla
            var encryptedInputPassword = _userRepository.Encrypt(loginDto.Password);

            if (userFromDb.Password != encryptedInputPassword)
            {
                return Unauthorized("Credenciales inválidas.");
            }

            // ========================
            // Generar el token JWT
            // ========================

            // 🔐 Esto en la vida real debería venir de appsettings.json
            var key = "clave-super-secreta-para-token-jwt-1234567890";
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Puedes agregar más claims si lo deseas
            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, userFromDb.UserId.ToString()),
        new Claim(ClaimTypes.Email, userFromDb.Email),
        new Claim(ClaimTypes.Name, userFromDb.Username),
    };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            // Devolver el token al frontend
            return Ok(new
            {
                token = jwt,
                username = userFromDb.Username,
                email = userFromDb.Email,
                userId = userFromDb.UserId
            });
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)] // El usuario no está autorizado a acceder a este recurso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // Realizó mala petición
        [ProducesResponseType(StatusCodes.Status201Created)] // Se creó correctamente
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Error en el servidor
        public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            // Verificar que no sea nulo
            if (createUserDto == null)
            {
                return BadRequest(ModelState);
            }

            // Verificar que no exista el usuario que se quiere crear mediante el Email
            if (_userRepository.UserExists(createUserDto.Email))
            {
                ModelState.AddModelError("CustomError", $"El correo {createUserDto.Email} ya está registrado");
                return BadRequest(ModelState);
            }

            // Convertir la entidad del DTO en una entidad de dominio
            var user = _mapper.Map<User>(createUserDto);

            if (!_userRepository.CreateUser(user))
            {
                ModelState.AddModelError("CustomError", $"Algo salió mal al guardar el registro {user.Username}");
                return StatusCode(500, ModelState);
            }

            // Si todo salió bien
            return CreatedAtRoute("GetUser", new { userId = user.UserId }, user);
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