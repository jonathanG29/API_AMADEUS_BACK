using API_AMADEUS.DTOs;
using API_AMADEUS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<Answer> CreateAnswer(AnswerDTOCreate answerDto)
        {
            var answer = new Answer
            {
                UserId = answerDto.UserId,
                QuestionId = answerDto.QuestionId,
                QuestionOptionId = answerDto.QuestionOptionId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return answer;
        }
    }
}