using InvestigationsProject.DAL;
using InvestigationsProject.players;
using InvestigationsProject.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.Game
{
    public static class Helper
    {
        public static List<string> GetSensorsList()
        {
            List<string> sensors = new List<string> 
            {
                "mobile",
                "movement",
                "thermal", 
                "pulse" 
            };
            return sensors;
        }

        public static int GetLevel(string rank)
        {
            Dictionary<string, int> levels = new Dictionary<string, int>
            {
                {"Foot Soldier", 1 },
                {"Squad Leader", 2 },
                {"Senior Commander", 3 },
                {"Organization Leader", 4 }
            };
            return levels[rank];
        }

        public static string GetNewRank(int level)
        {
            Dictionary<int, string> ranks = new Dictionary<int, string>
            {
                {1, "Foot Soldier" },
                {2, "Squad Leader" },
                {3, "Senior Commander" },
                {4, "Organization Leader" }
            };
            return ranks[level];
        }


        public static string GetUserSelection()
        {
            List<string> sensors = GetSensorsList();
            string userSelection;
            while (true)
            {
                Console.WriteLine("\nPlease select one of the sensors from the list that you want to connect to the Iranian agent.\n" +
                                 $"The sensors are: {string.Join(" / ", sensors)}\n");

                userSelection = Console.ReadLine().Trim().ToLower();

                if (sensors.Contains(userSelection))
                    break;

                Console.WriteLine("Invalid value");
            }

            return userSelection;
        }

        public static Sensor CreateSensor(string userSelection)
        {
            List<Sensor> sensors = new List<Sensor>
        {
            new Movement(),
            new Mobile(),
            new Thermal(),
            new Pulse()
        };

            return sensors.FirstOrDefault(sensor => sensor.Name == userSelection);
        }

        public static Player GetPlayer()
        {
            Player player;
            while (true)
            {
                Console.Write("\nPlease enter a username: ");
                string userName = Console.ReadLine().ToLower().Trim();
                if (!String.IsNullOrEmpty(userName))
                {
                    player = DALPlayers.GetPlayerByUserName(userName);
                    if (player == null)
                    {
                        Console.WriteLine("\nYou are not registered in the system. You must register first.");
                        string fullName = GetFullName();
                        DALPlayers.Add(userName, fullName);
                        player = DALPlayers.GetPlayerByUserName(userName);
                    }
                    break;
                }
            }
            return player;
        }


        public static string GetFullName()
        {
            string fullName;
            while (true)
            {
                Console.Write("\nPlease enter your full name: ");
                fullName = Console.ReadLine()!.ToLower().Trim();
                if (!String.IsNullOrEmpty(fullName))
                    break;
            }
            return fullName;
        }


    }
}
