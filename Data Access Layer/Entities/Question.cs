using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class Question:BaseEntity
    {

        public int Scores { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
        public string StudentAnswer { get; set; }
        public string Options { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}