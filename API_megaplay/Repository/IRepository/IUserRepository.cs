using System;
using API_megaplay.Models;
using API_megaplay.Models.Dtos;

namespace API_megaplay.Repository.IRepository;

public interface IUserRepository
{
    // Devuelve todos los usuarios
    ICollection<User> GetUsers();

    // Recibe un ID y devuelve un solo usuario o null si no se encuentra
    User? GetUser(int id);

    // Recibe un nombre de usuario y devuelve un bool indicando si el nombre de usuario es único.
    bool IsUniqueUser(string username);

    // Recibe un objeto UserLoginDto y devuelve un UserLoginResponseDto de forma asíncrona (Task)
    Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);

    // Recibe un objeto CreateUserDto y devuelve un objeto User de forma asíncrona (Task).
    Task<User> Register(CreateUserDto createUserDto);

    // Recibe un objeto tipo User y devuelve un bool indicando si la actualización fue exitosa
    bool UpdateUser(User user);

    // Recibe un objeto tipo User y devuelve un bool indicando si la eliminación fue exitosa
    bool DeleteUser(User user);
}
