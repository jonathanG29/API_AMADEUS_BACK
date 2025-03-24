using API_AMADEUS.Models;
using API_AMADEUS.Data;

namespace API_AMADEUS.Services
{
    public class DestinationService
    {
        private readonly DestinationRepository repository;

        public DestinationService(ApplicationDbContext context)
        {
            repository = new DestinationRepository(context);
        }

        public async Task<List<Destination>> GetAllDestinations()
        {
            return await repository.GetAllDestinations();
        }

        public async Task<Destination?> GetDestinationById(int id)
        {
            return await repository.GetDestinationById(id);
        }
    }
}
