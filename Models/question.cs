using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_AMADEUS.Models
{
    [Table("question")]
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Column("question_text")]
        public string QuestionText { get; set; } = string.Empty;

        public Question()
        {
        }
    }
}
