using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API_megaplay.Data;
using API_megaplay.Models;
using API_megaplay.Models.Dtos;
using API_megaplay.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API_megaplay.Repository;

public class UserRepository : IUserRepository
{
    // Instancia del contexto
    private readonly ApplicationDbContext _db;

    // Obtener la llave secreta de appsettings.json
    private string? secretKey;

    public UserRepository(ApplicationDbContext db, IConfiguration configuration)
    {
        _db = db;
        secretKey = configuration.GetValue<string>("ApiSettings:SecretKey");
    }

    // Método para obtener un usuario mediante el Id
    public User? GetUser(int id)
    {
        // Validar que el ID sea válido
        if (id <= 0)
        {
            return null;
        }

        return _db.Users.FirstOrDefault(u => u.UserId == id);
    }

    // Método para obtener todos los usuarios
    public ICollection<User> GetUsers()
    {
        return _db.Users.OrderBy(u => u.Username).ToList();
    }

    public bool IsUniqueUser(string email)
    {
        return !_db.Users.Any(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
    }

    public async Task<User> Register(CreateUserDto createUserDto)
    {
        var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);

        var user = new User()
        {
            Email = createUserDto.Email ?? "No E-mail",
            Username = createUserDto.Username,
            Password = encryptedPassword
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto)
    {
        // Verificar si nos mandaron el correo electronico
        if (string.IsNullOrEmpty(userLoginDto.Email))
        {
            return new UserLoginResponseDto()
            {
                Token = "",
                User = null,
                Message = "El Email es requerido"
            };
        }

        var user = await _db.Users.FirstOrDefaultAsync<User>(u => u.Email.ToLower().Trim() == userLoginDto.Email.ToLower().Trim());

        // Verificar que el email exista
        if (user == null)
        {
            return new UserLoginResponseDto()
            {
                Token = "",
                User = null,
                Message = "Email no encontrado"
            };
        }

        // Verificar que el password sea igual al que tenemos guardado en la BD
        if (!BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
        {
            return new UserLoginResponseDto()
            {
                Token = "",
                User = null,
                Message = "Credenciales incorrectas"
            };
        }

        // Crear el token despues de validar el username y el password
        var handlerToken = new JwtSecurityTokenHandler();

        //Codificar el secretKey
        if (string.IsNullOrWhiteSpace(secretKey))
        {
            throw new InvalidOperationException("SecretKey no está configurada");
        }

        var key = Encoding.UTF8.GetBytes(secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.UserId.ToString()),
                new Claim("email", user.Email),
            }),

            // Fecha de expiración
            Expires = DateTime.UtcNow.AddHours(2),

            // Firmar las credenciales
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        // Generar token
        var token = handlerToken.CreateToken(tokenDescriptor);

        return new UserLoginResponseDto()
        {
            Token = handlerToken.WriteToken(token),
            User = new UserRegisterDto()
            {
                Email = user.Email,
                Username = user.Username,
                Password = user.Password ?? ""
            },

            Message = "Usuario logueado correctamente"
        };
    }

    // Método para guardar los cambios en la BD
    public bool Save()
    {
        return _db.SaveChanges() >= 0;
    }

    // Método para actualizar un usuario
    public bool UpdateUser(User user)
    {
        if (user == null)
        {
            return false;
        }

        _db.Users.Update(user);
        return Save();
    }

    // Método para eliminar un usuario
    public bool DeleteUser(User user)
    {
        if (user == null)
        {
            return false;
        }

        _db.Users.Remove(user);
        return Save();
    }

    public User? GetUserByEmail(string email)
    {
        return _db.Users.FirstOrDefault(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
    }
}