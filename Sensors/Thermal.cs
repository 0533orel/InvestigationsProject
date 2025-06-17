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
        public Thermal() : base("thermal")
        {
            quantityLife = 100;
        }


        public override bool Activate(IranianAgent agent)
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
