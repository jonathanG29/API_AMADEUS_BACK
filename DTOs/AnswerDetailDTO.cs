namespace API_AMADEUS.DTOs
{
    public class AnswerDetailDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public int QuestionOptionId { get; set; }
        public string OptionDescription { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
