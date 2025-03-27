using API_AMADEUS.Models;
using Microsoft.EntityFrameworkCore;

namespace API_AMADEUS.Data
{
    public class UserAdminRepository
    {
        private readonly ApplicationDbContext db;

        public UserAdminRepository(ApplicationDbContext context) 
        {
            db = context;
        }

        // Método actualizado para obtener administradores
        public async Task<List<UserAdminModel>> GetAllAdmins()
{
    return await db.Set<UserAdminModel>().ToListAsync(); // Esto usará el mapeo configurado en ApplicationDbContext
}
    }
}