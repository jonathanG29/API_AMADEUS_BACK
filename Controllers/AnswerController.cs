using API_AMADEUS.Models;
using API_AMADEUS.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_AMADEUS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : ControllerBase
    {
        private readonly AnswerService _answerService;

        public AnswerController(AnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer([FromBody] Answer answer)
        {
            if (answer == null)
            {
                return BadRequest(new { Message = "Invalid answer data", StatusCode = 400 });
            }

            var createdAnswer = await _answerService.CreateAnswerAsync(answer);
            return CreatedAtAction(nameof(GetAnswerById), new { id = createdAnswer.Id }, createdAnswer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnswerById(int id)
        {
            var answer = await _answerService.GetAnswerByIdAsync(id);
            if (answer == null)
            {
                return NotFound(new { Message = "Answer not found", StatusCode = 404 });
            }
            return Ok(answer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnswers()
        {
            var answers = await _answerService.GetAllAnswersAsync();
            return Ok(answers);
        }
    }
}