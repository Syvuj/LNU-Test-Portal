using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class QaAnResults:BaseEntity
    {
        [ForeignKey("ApplicationUser")]
        public int StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question QuestionAnswer { get; set; }
        public int StudentAnswScore { get; set; }
    }
}