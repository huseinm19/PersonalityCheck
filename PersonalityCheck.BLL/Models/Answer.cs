namespace PersonalityCheck.BLL.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int QuestionId { get; set; }
    }
}
