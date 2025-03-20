using API_AMADEUS.Data;
using API_AMADEUS.Models;

namespace API_AMADEUS.Services;

public class QuestionService(ApplicationDbContext context)
{
    private readonly QuestionRepository questionRepository = new(context);

    public async Task<List<Question>> GetAllQuestions()
    {
        return await questionRepository.GetAllQuestions();
    }

    public async Task<Question?> GetQuestionById(int id)
    {
        return await questionRepository.GetQuestionById(id);
    }
}
