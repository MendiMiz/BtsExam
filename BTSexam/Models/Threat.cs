﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSexam.Models
{
    internal class Threat
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }  
        public int Sophistication { get; set; } 
        public string Target { get; set; } = string.Empty;



        
    }
}
