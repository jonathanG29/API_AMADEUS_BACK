using API_AMADEUS.Data;
using API_AMADEUS.Models;

namespace API_AMADEUS.Services
{
    public class QuestionOptionService
    {
        private readonly QuestionOptionRepository _repo;

        public QuestionOptionService(ApplicationDbContext context)
        {
            _repo = new QuestionOptionRepository(context);
        }

        public async Task<List<QuestionOption>> GetAllOptions()
        {
            return await _repo.GetAllOptions();
        }

        public async Task<QuestionOption?> GetOptionById(int id)
        {
            return await _repo.GetOptionById(id);
        }
    }
}
