using API_AMADEUS.Models;
using API_AMADEUS.Data;
using System.Security.Cryptography;
using System.Text;


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

        public string GetDestinationHash(string id)
        {
            return ComputeSha256Hash(id);
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task<Destination?> GetDestinationByCombination(string combination)
        {
            return await repository.GetDestinationByCombination(combination);
        }
    }
}
