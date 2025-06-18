using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.Sensors
{
    public class Movement : Sensor
    {
        public Movement() : base("movement")
        {
            quantityLife = 100;
        }
    }
}
