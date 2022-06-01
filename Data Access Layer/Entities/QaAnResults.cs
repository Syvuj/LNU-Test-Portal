using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Entities
{
    public class QaAnResults
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int TestId { get; set; }
        public string StudentId { get; set; }
        public int QuestionId { get; set; }
        public int StudentAnswScore { get; set; }
        public string StudAnsw { get; set; }
        public string CorectAnswer { get; set; }
    }
}