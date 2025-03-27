namespace API_AMADEUS.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionOptionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relaciones
        public Question Question { get; set; }
        public QuestionOption QuestionOption { get; set; }
    }
}
