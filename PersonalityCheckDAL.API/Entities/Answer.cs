namespace PersonalityCheckDAL.API.Entities
{
    public partial class Answer
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int QuestionId { get; set; }
    }
}
