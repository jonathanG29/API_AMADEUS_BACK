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
            var existingUsers = await UserRepository.GetAllUsers();
            var existingUser = existingUsers.FirstOrDefault(u => u.email == user.email);

            if (existingUser != null)
            {
                // Devolver la información del usuario existente 
                return existingUser;
            }

            // Crear el nuevo usuario
            return await UserRepository.CreateUser(user);
        }
    }
}