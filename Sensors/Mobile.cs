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
        
        public Mobile() : base("mobile")
        {
            quantityLife = 100;
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
