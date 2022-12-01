﻿namespace PersonalityCheckDAL.API.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int NumberOfAnsweredQuestions { get; set; }
        public int Result { get; set; }
        public bool Retaken { get; set; }
    }
}