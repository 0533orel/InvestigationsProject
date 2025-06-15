using InvestigationsProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.Sensors
{
    public class Mobile : Sensor
    {
        public Mobile() : base("mobile") { }


        public override bool Activate()
        {
            Console.WriteLine($"The sensor {Name} is activated.");
            return true;
        }
    }
}
