﻿namespace SurveyGenerator.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Question Question { get; set; }
    }
}