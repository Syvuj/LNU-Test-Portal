using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace LNU_Test_Portal.ViewModels
{
    public class QaAnViewModel:Question
    {
        public string NewStudentAnswer { get; set; }
        public int StudentScorecByQues { get; set; }
    }
}