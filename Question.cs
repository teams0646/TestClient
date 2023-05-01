using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public Answer AnswerA { get; set; }
        public Answer AnswerB { get; set; }
        public Answer AnswerC { get; set; }
        public Answer AnswerD { get; set; }
        public List<Answer> Answers { get; internal set; }
        public Answer CorrectAnswer { get; internal set; }
    }

    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }

}
