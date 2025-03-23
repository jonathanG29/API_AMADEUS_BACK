using API_AMADEUS.Models;
using Microsoft.EntityFrameworkCore;

namespace API_AMADEUS.Data
{
    public class AnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public AnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Answer> GetAllAnswers()
        {
            return _context.Answers.ToList();
        }

        public async Task<Answer?> GetAnswerById(int id)
        {
            return await _context.Answers.FirstOrDefaultAsync(answer => answer.Id == id);
        }

        public async Task<Answer> CreateAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return answer;
        }
    }
}