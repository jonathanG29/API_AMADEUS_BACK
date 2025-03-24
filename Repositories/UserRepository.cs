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

        //update name del usuario
        public async Task<User?> UpdateUserFullName(int id, string fullName)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }

            if (user.full_name != fullName)
            {
                user.full_name = fullName;
                await db.SaveChangesAsync();
            }

            return user;
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}