using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.Sensors
{
    public class Mobile : Sensor
    {
        
        public Mobile() : base("mobile")
        {
            quantityLife = 100;
        }
    }
}
