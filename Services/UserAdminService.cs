using API_AMADEUS.Models;
using API_AMADEUS.Data;

namespace API_AMADEUS.Services
{
    public class UserAdminService
    {
        private readonly UserAdminRepository userAdminRepository;

        public UserAdminService(ApplicationDbContext context)
        {
            userAdminRepository = new UserAdminRepository(context);
        }

        // Método para obtener todos los administradores
        public async Task<List<UserAdminModel>> GetAllAdmins()
        {
            return await userAdminRepository.GetAllAdmins();
        }
    }
}