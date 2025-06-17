using InvestigationsProject.Classes;
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

        // later
        static List<string> ranks = new List<string>
        { 
            "Junior",
            "Squad Leader",
            "Company commander",
            "Senior" 
        };

        static string RandomName()
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

        public static Junior JuniorAgent()
        {
            Junior agent = new Junior(RandomName(), FactoryWeaknesses.JuniorWeaknesses());
            return agent;
        }

        public static SquadLeader SquadLeaderAgent()
        {
            SquadLeader agent = new SquadLeader(RandomName(), FactoryWeaknesses.SquadLeaderWeaknesses());
            return agent;
        }
    }
}
