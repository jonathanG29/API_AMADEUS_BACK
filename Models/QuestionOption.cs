namespace API_AMADEUS.Models
{
    public class QuestionOption
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImgDescription { get; set; } = string.Empty;
    }
}
