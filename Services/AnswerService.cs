using API_AMADEUS.Data;
using API_AMADEUS.DTOs;
using API_AMADEUS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_AMADEUS.Services
{
    public class AnswerService
    {
        private readonly ApplicationDbContext _context;

        public AnswerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAnswerAsync(Answer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
        }

        public async Task<Answer?> GetAnswerByIdAsync(int id)
        {
            return await _context.Answers.FindAsync(id);
        }

        public async Task<List<Answer>> GetAllAnswersAsync()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task<Answer> CreateAnswerAsync(AnswerDTOCreate answerDto)
        {
            if (answerDto == null)
            {
                throw new ArgumentNullException(nameof(answerDto), "AnswerDTOCreate cannot be null");
            }

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