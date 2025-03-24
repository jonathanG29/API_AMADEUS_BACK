using API_AMADEUS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_AMADEUS.Data
{
    public class QuestionRepository
    {
        private readonly ApplicationDbContext db;

        public QuestionRepository(ApplicationDbContext context)
        {
            db = context;
        }

        // Obtener todas las preguntas
        public async Task<List<Question>> GetAllQuestions()
        {
            return await db.Questions.ToListAsync();
        }

        // Obtener una pregunta por ID
        public async Task<Question?> GetQuestionById(int id)
        {
            return await db.Questions.FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
