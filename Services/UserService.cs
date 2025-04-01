using API_AMADEUS.Models;
using API_AMADEUS.Data;
// using Microsoft.EntityFrameworkCore;

namespace API_AMADEUS.Services
{
    public class UserService(ApplicationDbContext context)
    {
        private readonly UserRepository UserRepository= new(context);


        public async Task<List<User>> GetAllUsers()
        {
            return await UserRepository.GetAllUsers();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await UserRepository.GetUserById(id);
        }

        public async Task<User> CreateUser(User user)
        {
            // Verificar si el correo electrónico está vacío y el nombre
            if (string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.full_name))
            {
            throw new ArgumentException("El correo electrónico y el nombre completo no pueden estar vacíos.");
            }

            var existingUsers = await UserRepository.GetAllUsers();
            var existingUser = existingUsers.FirstOrDefault(u => u.email == user.email);

            // Si el usuario ya existe
            if (existingUser != null)
            {
            // Comparar el full_name enviado con el full_name registrado
            if (existingUser.full_name != user.full_name)
            {
                // Llamar el método para actualizar el nombre
                await UpdateUserFullName(existingUser.Id, user.full_name);
            }

            // Retornar el usuario y mostrar un status code 200
            return existingUser;
            }

            // Crear el nuevo usuario
            return await UserRepository.CreateUser(user);
        }

        public async Task<User?> UpdateUserFullName(int id, string fullName)
        {
            var user = await UserRepository.GetUserById(id);
            if (user == null)
            {
            return null;
            }

            if (user.full_name != fullName)
            {
            user.full_name = fullName;
            await UserRepository.SaveChangesAsync();
            }

            return user;
        }
    }
}