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
            return await db.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await db.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> CreateUser(User user)
        {
            var newuser = db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }
    }
}