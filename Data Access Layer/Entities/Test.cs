using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class Test:BaseEntity
    {

        public string name { get; set; }
        public string description { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public virtual IEnumerable<Question> Questions { get; set; }

    }
}