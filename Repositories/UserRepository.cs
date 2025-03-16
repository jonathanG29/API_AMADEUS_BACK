using API_AMADEUS.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API_AMADEUS.Data
{
    public class UserRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext context) 
        {
            db = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await db.User.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await db.User.FirstOrDefaultAsync(User => User.Id == id);
        }

        //Funcion para crear un usuario
        public async Task<User> CreateUser(User User)
        {
            db.User.Add(User);
            await db.SaveChangesAsync();
            return User;
        }
    }
}