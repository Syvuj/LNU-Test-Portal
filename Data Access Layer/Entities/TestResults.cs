using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class TestResults:BaseEntity
    {
        [ForeignKey("ApplicationUser")]
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public Test Test { get; set; }
        public List<QnAnResults> QnAnResultsList { get; set; }
        public string TotalStScore { get; set; }

    }
}