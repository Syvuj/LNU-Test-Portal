using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace LNU_Test_Portal.Models
{
    public class Test
    {
        public string TestId { get; set; }
        public string TName { get; set; }
        public string TDescription { get; set; }
        public List<Question> Questions { get; set; }
        public Test(string TestId, string TName, string TDescription, List<Question> Questions)
        {
            this.TestId = TestId;
            this.TName = TName;
            this.TDescription = TDescription;
            
            
        }
    }
}