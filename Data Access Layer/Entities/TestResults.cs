using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class TestResults:BaseEntity
    {

        public int StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }



    }
}