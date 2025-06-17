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


        public override bool Activate(Agent agent)
        {
            int timesExists = agent.GetTimesWeaknessExists(Name);
            int timesAttached = agent.GetTimesWeaknessAttached(Name);

            if (timesExists != 0 && timesAttached < timesExists)
                return true;
            else
                return false;
        }


        public override int GetQuantityLife()
        {
            return quantityLife;
        }


        public override void DownLifeQuantity()
        {
            quantityLife--;
        }
    }
}
