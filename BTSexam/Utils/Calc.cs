using BTSexam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTSexam.Utils
{
    internal class Calc
    {
        public static int ThreatSeverity(Threat threat)
        {
            int targetValue = threat.Target switch
            {
                "Web Server" => 10,
                "Database" => 15,
                "User Credentials" => 20,
                _=> 5
            };
            return (threat.Volume * threat.Sophistication) + targetValue;
        }
    }
}
