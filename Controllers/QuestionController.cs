using API_AMADEUS.Data;
using API_AMADEUS.Models;
using API_AMADEUS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_AMADEUS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController(ApplicationDbContext context) : ControllerBase
{
    private readonly QuestionService questionService = new(context);

    [HttpGet]
    public async Task<IActionResult> GetQuestions()
    {
        var questions = await questionService.GetAllQuestions();
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetQuestion(int id)
    {
        var question = await questionService.GetQuestionById(id);

        if (question == null)
        {
            return NotFound(new ErrorResponse { Message = "Question not found", StatusCode = 404 });
        }

        return Ok(question);
    }
}
