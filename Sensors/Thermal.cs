using InvestigationsProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InvestigationsProject.Sensors
{
    public class Thermal : Sensor
    {
        public Thermal() : base("thermal") { }


        public override bool Activate(IranianAgent agent)
        {
            int timesExists = agent.TimesWhenWeaknessExists(Name);
            int timesAttached = agent.TimesWhenWeaknessAttached(Name);

            if (timesExists != 0 && timesAttached < timesExists)
                return true;
            else
                return false;
        }
    }
}
