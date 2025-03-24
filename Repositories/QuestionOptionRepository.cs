using API_AMADEUS.Models;
using Microsoft.EntityFrameworkCore;

namespace API_AMADEUS.Data
{
    public class QuestionOptionRepository
    {
        private readonly ApplicationDbContext _db;

        public QuestionOptionRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<List<QuestionOption>> GetAllOptions()
        {
            return await _db.QuestionOptions.ToListAsync();
        }

        public async Task<QuestionOption?> GetOptionById(int id)
        {
            return await _db.QuestionOptions.FirstOrDefaultAsync(qo => qo.Id == id);
        }
    }
}
