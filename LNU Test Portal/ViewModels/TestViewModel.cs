using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data_Access_Layer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace LNU_Test_Portal.ViewModels
{
    public class TestViewModel:Test
    {
        public bool isFirstAttemp { get; set; }
        public int TotalAvailablePoits { get; set; }
        public int SumByTest { get; set; }
    }
}