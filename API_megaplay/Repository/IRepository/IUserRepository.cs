using System;
using API_megaplay.Models;

namespace API_megaplay.Repository.IRepository;

public interface IUserRepository
{
    // Devuelve todos los usuarios
    ICollection<User> GetUsers();

    // Recibe un ID y devuelve un solo usuario o null si no se encuentra
    User? GetUser(int id);

    // Recibe un email y devuelve un solo usuario o null si no se encuentra
    User? GetUserByEmail(string email);

    // Recibe un id y devuelve un bool indicando si existe el usuario
    bool UserExists(int id);

    // Recibe un email y devuelve un bool indicando si existe el usuario
    bool UserExists(string email);

    // Recibe una contraseña en texto y la encripta
    string Encrypt(string password);

    // Recibe una contraseña encriptada y la devuelve desencriptada
    string Decrypt(string password);

    // Recibe un objeto tipo User y devuelve un bool indicando si la creación fue exitosa
    bool CreateUser(User user);

    // Recibe un objeto tipo User y devuelve un bool indicando si la actualización fue exitosa
    bool UpdateUser(User user);

    // Recibe un objeto tipo User y devuelve un bool indicando si la eliminación fue exitosa
    bool DeleteUser(User user);

    bool Save();

}
