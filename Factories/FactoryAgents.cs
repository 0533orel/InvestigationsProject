using InvestigationsProject.Classes;
using InvestigationsProject.Game;
using InvestigationsProject.IranianAgents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.Factories
{
    public static class FactoryAgents
    {
        static Random rand = new Random();

        static string GetRandomName()
        {
            List<string> firstNames = new List<string>
                {
                    "Amir",
                    "Reza",
                    "Hossein",
                    "Ali",
                    "Mehdi",
                    "Mostafa",
                    "Saeed",
                    "Kaveh",
                    "Behrouz",
                    "Farhad",
                    "Arash",
                    "Navid",
                    "Babak",
                    "Nima",
                    "Shayan"
                };
            List<string> lastNames = new List<string>
                {
                    "Mohammadi",
                    "Hosseini",
                    "Ahmadi",
                    "Rahimi",
                    "Ebrahimi",
                    "Karimi",
                    "Rezaei",
                    "Abbasi",
                    "Jafari",
                    "Kazemi",
                    "Najafi",
                    "Rostami",
                    "Eskandari",
                    "Soleimani",
                    "Sharifi",
                    "Fallahi",
                    "Ghaffari",
                    "Khodadadi",
                    "Mousavi",
                    "Zand"
                };
            string fullName = firstNames[rand.Next(firstNames.Count)] + " " + lastNames[rand.Next(lastNames.Count)];
            return fullName;
        }

        static List<string> GetRandomWeaknesses(int count)
        {
            List<string> sensors = Helper.GetSensorsList();
            List<string> randomSensors = new List<string>();
            for (int i = 0; i < count; i++)
            {
                randomSensors.Add(sensors[rand.Next(sensors.Count)]);
            }
            return randomSensors;
        }

        public static Agent CreateAgent(int level)
        {
            string name = GetRandomName();
            switch (level)
            {
                case 1:
                    return new Agent(name, "Foot Soldier", GetRandomWeaknesses(2));
                case 2:
                    return new SquadLeader(name, "Squad Leader", GetRandomWeaknesses(4));
                case 3:
                    return null;
                case 4:
                    return null;
                default:
                    return null;
            }
        }
    }
}
