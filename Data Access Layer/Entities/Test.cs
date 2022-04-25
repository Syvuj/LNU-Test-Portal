using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Entities
{
    public class Test
    {
        public string id { get; set; }
        public string TName { get; set; }
        public string TDescription { get; set; }
        public List<Question> Questions { get; set; }
        public Test(string id, string TName, string TDescription, List<Question> Questions)
        {
            this.id = id;
            this.TName = TName;
            this.TDescription = TDescription;
            
            
        }
    }
}