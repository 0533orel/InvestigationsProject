using InvestigationsProject.Classes;
using InvestigationsProject.Game;
using InvestigationsProject.IranianAgents;

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

        public static List<string> GetRandomWeaknesses(int count)
        {
            List<string> sensors = Helper.GetSensorsList();
            List<string> randomSensors = new List<string>();
            for (int i = 0; i < count; i++)
            {
                randomSensors.Add(sensors[rand.Next(sensors.Count)]);
            }
            return randomSensors;
        }

        public static Agent CreateAgent(string rank)
        {
            string name = GetRandomName();
            switch (rank)
            {
                case "Foot Soldier":
                    return new Agent(rank, GetRandomWeaknesses(2));
                case "Squad Leader":
                    return new SquadLeader(rank, GetRandomWeaknesses(4));
                case "Senior Commander":
                    return new SeniorCommander(rank, GetRandomWeaknesses(6));
                case "Organization Leader":
                    return new OrganizationLeader(rank, GetRandomWeaknesses(8));
                default:
                    return null;
            }
        }
    }
}
