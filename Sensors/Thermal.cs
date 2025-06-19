
using InvestigationsProject.Classes;
using InvestigationsProject.Game;

namespace InvestigationsProject.Sensors
{
    public class Thermal : Sensor
    {
        public Thermal() : base("thermal")
        {
            quantityLife = 100;
        }

        public void DiscoverOneWeakness(Agent agent)
        {
            List<string> weaknesses = agent.GetSecretWeaknesses();
            List<string> discover = weaknesses
                .Where(w => agent.GetTimesWeaknessAttached(w) < agent.GetTimesWeaknessExists(w))
                .Distinct()
                .ToList();

            if (discover.Count > 0)
            {
                string selected = discover[new Random().Next(discover.Count)];
                Helper.PrintSlow($"\nThe sensor discover one valid weakness: '{selected}'", 5);
            }
            
        }
    }
}
