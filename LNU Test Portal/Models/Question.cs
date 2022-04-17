using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace LNU_Test_Portal.Models
{
    public class Question
    {
        public string QuestionId { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
        public string StudentAnswer { get; set; }
        public List<string> Options { get; set; }
        public Question(string QuestionId, string Title, string Key, string StudentAnswer, List<string> Options)
        {
            this.QuestionId = QuestionId;
            this.Title = Title;
            this.Key = Key;
            this.StudentAnswer = StudentAnswer;
            this.Options = Options;
        }
    }
}