namespace API_AMADEUS.DTOs
{
    public class AnswerDTO
    {
        public int UserId { get; set; } 
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int QuestionOptionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
    public class AnswerDTOCreate
    {
        public int UserId { get; set; } 
        public int QuestionId { get; set; }
        public int QuestionOptionId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    
}