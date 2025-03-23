namespace API_AMADEUS.Models
{
    public class Answer
    {
        public int UserId { get; set; } 
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int QuestionOptionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

    }
}