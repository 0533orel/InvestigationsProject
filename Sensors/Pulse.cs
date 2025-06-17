using InvestigationsProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.Sensors
{
    internal class Pulse : Sensor
    {
        public Pulse() : base("pulse")
        {
            quantityLife = 3;
        }
    }
}
