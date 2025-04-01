using API_AMADEUS.DTOs;
using API_AMADEUS.Models;
using API_AMADEUS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_AMADEUS.Controllers
{
    // This controller handles the creation and retrieval of answers.
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
        public async Task<IActionResult> CreateAnswers([FromBody] List<AnswerDTOCreate> answerDtos)
        {
            if (answerDtos == null || answerDtos.Count == 0)
            {
                return BadRequest(new { Message = "Invalid answer data", StatusCode = 400 });
            }

            var createdAnswers = new List<Answer>();
            foreach (var answerDto in answerDtos)
            {
                var createdAnswer = await _answerService.CreateAnswerAsync(answerDto);
                createdAnswers.Add(createdAnswer);
            }

            return Ok(createdAnswers);
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

        [Authorize(Roles = "Admin")] // Solo accesible para usuarios con rol "Admin"
        [HttpGet("details")]
        public async Task<IActionResult> GetAnswersWithDetails()
        {
            var answers = await _answerService.GetAnswersWithDetailsAsync();
            return Ok(answers);
        }
    }
}
