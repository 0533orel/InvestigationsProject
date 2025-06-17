using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.Factories
{
    public static class FactoryWeaknesses
    {
        static Random rand = new Random();

        public static List<string> sensors = new List<string> { "mobile", "movement", "thermal", "pulse" };

        public static List<string> JuniorWeaknesses()
        {
            List<string> agentWeaknesses = new List<string>
                    {
                        sensors[rand.Next(sensors.Count)],
                        sensors[rand.Next(sensors.Count)]
                    };
            return agentWeaknesses;
        }


        
    }
}
