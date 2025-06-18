using InvestigationsProject.Classes;

namespace InvestigationsProject.Sensors
{
    public abstract class Sensor
    {
        public string Name { get; private set; }
        protected int quantityLife;


        public Sensor(string name)
        {
            Name = name;
        }


        public bool Activate(Agent agent)
        {
            int timesExists = agent.GetTimesWeaknessExists(Name);
            int timesAttached = agent.GetTimesWeaknessAttached(Name);

            if (timesExists != 0 && timesAttached < timesExists)
                return true;
            else
                return false;
        }


        public int GetQuantityLife()
        {
            return quantityLife;
        }


        public void DownLifeQuantity()
        {
            quantityLife--;
        }
    }
}
