using System;
using System.Security.Cryptography;
using System.Text;
using API_megaplay.Data;
using API_megaplay.Models;
using API_megaplay.Repository.IRepository;

namespace API_megaplay.Repository;

public class UserRepository : IUserRepository
{

    // Instancia del contexto
    private readonly ApplicationDbContext _db;

    // Variables de apoyo necesarias para encriptar
    private byte[] _Key = Encoding.UTF8.GetBytes("jW*Zq4t7w!z%C*F-JaNdRgUkXp2s5u8x");
    private byte[] _IV = Encoding.UTF8.GetBytes("q3&9z$q31*_t6?z$");

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    // Método para encriptar la contraseña
    public string Encrypt(string password)
    {
        using Aes aes = Aes.Create();
        aes.Key = _Key;
        aes.IV = _IV;

        ICryptoTransform encryptor = aes.CreateEncryptor();

        using MemoryStream msEncrypt = new();
        using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
        using (StreamWriter swEncrypt = new(csEncrypt))
        {
            swEncrypt.Write(password);
        }

        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    // Método para desencriptar la contraseña
    public string Decrypt(string cipheredPassword)
    {
        using Aes aes = Aes.Create();
        aes.Key = _Key;
        aes.IV = _IV;

        ICryptoTransform decryptor = aes.CreateDecryptor();

        byte[] cipheredBytes = Convert.FromBase64String(cipheredPassword);
        using MemoryStream msEncrypt = new(cipheredBytes);
        using CryptoStream csEncrypt = new(msEncrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new(csEncrypt);

        return srDecrypt.ReadToEnd();
    }

    // Método para crear un usuario
    public bool CreateUser(User user)
    {
        // Validación por si el usuario esta vacío
        if (user == null)
        {
            return false;
        }

        // Encriptar la contraseña al momento de crear el usuario ANTES de mandarlo a la BD
        user.password = Encrypt(user.password);

        // Guardar usuario
        user.CreatedAt = DateTime.Now;
        _db.Users.Add(user);
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

    // Método para ver si un usuario existe mediante el ID
    public bool UserExists(int id)
    {
        if (id <= 0)
        {
            return false;
        }

        return _db.Users.Any(u => u.UserId == id);
    }

    // Método para ver si un usuario existe mediante el email
    public bool UserExists(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        return _db.Users.Any(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
    }

}