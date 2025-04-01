using API_AMADEUS.Models;
using Microsoft.EntityFrameworkCore;

namespace API_AMADEUS.Data
{
    public class DestinationRepository
    {
        private readonly ApplicationDbContext db;

        public DestinationRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<List<Destination>> GetAllDestinations()
        {
            return await db.Set<Destination>().ToListAsync();
        }

        public async Task<Destination?> GetDestinationById(int id)
        {
            return await db.Destinations.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Destination?> GetDestinationByCombination(string combination)
        {
            return await db.Destinations
                .FirstOrDefaultAsync(d => d.Combination == combination);
        }

    }
}
