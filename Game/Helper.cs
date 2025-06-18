using InvestigationsProject.Classes;
using InvestigationsProject.DAL;
using InvestigationsProject.players;
using InvestigationsProject.Sensors;

namespace InvestigationsProject.Game
{
    public static class Helper
    {
        public static List<string> GetSensorsList()
        {
            return new List<string>
            {
                "mobile",
                "movement",
                "thermal",
                "pulse"
            };
        }

        public static string GetNewRank(int level)
        {
            var ranks = new Dictionary<int, string>
            {
                {1, "Foot Soldier" },
                {2, "Squad Leader" },
                {3, "Senior Commander" },
                {4, "Organization Leader" }
            };
            return ranks.ContainsKey(level) ? ranks[level] : "Unknown Rank";
        }

        public static Player PrintToPlayer(Player player)
        {
            if (player.TotalAttempts > 0)
            {
                PrintSlow($"\nWelcome back {player.FullName}!");
                player = CheckPlayerStart(player);
            }
            else
                PrintSlow($"\nWelcome {player.FullName}!");

            PrintSlow("\nAn Iranian agent has been captured. Your mission: identify and attach the correct sensors to reveal his vulnerabilities and uncover his true intentions.", 10);
            return player;
        }

        public static Player CheckPlayerStart(Player player)
        {
            while (true)
            {
                PrintSlow("\nWould you like to:\n1. Continue from your last saved level\n2. Start a new game\nChoose (1 or 2): ", 10);
                string choice = Console.ReadLine()?.Trim();

                if (choice == "1")
                {
                    break;
                }
                else if (choice == "2")
                {
                    DALPlayers.ResetPlayerProgress(player.UserName);
                    player = DALPlayers.GetPlayerByUserName(player.UserName);
                    PrintSlow("\nYour progress has been reset.");
                    break;
                }
                else
                {
                    PrintSlow("Invalid selection. Please choose 1 or 2.");
                }
            }
            return player;
        }

        public static string GetUserSelection()
        {
            var sensors = GetSensorsList();
            string userSelection;
            while (true)
            {
                PrintSlow("\nPlease select one of the sensors from the list that you want to connect to the Iranian agent.", 5);
                PrintSlow($"The sensors are: {string.Join(" / ", sensors)}\n", 5);

                userSelection = Console.ReadLine().Trim().ToLower();

                if (sensors.Contains(userSelection))
                    break;

                PrintSlow("Invalid value. Please choose a valid sensor.");
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
                PrintSlow("Please enter a username: ", 10);
                string userName = Console.ReadLine().ToLower().Trim();
                if (!String.IsNullOrEmpty(userName))
                {
                    player = DALPlayers.GetPlayerByUserName(userName);
                    if (player == null)
                    {
                        PrintSlow("\nYou are not registered in the system. You must register first.");
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
                PrintSlow("\nPlease enter your full name: ", 10);
                fullName = Console.ReadLine().ToLower().Trim();
                if (!String.IsNullOrEmpty(fullName))
                    break;
            }
            return fullName;
        }

        public static void ActiveSensor(Player player, Sensor sensor, Agent iranianAgent)
        {
            PrintSlow("...", 300);

            bool activeSensor = sensor.Activate(iranianAgent);
            Thread.Sleep(300);

            if (activeSensor)
            {
                iranianAgent.AttachSensor(sensor);
                PrintSlow($"\nRight!", 0);
                DALPlayers.UpdateSuccessfulAttempts(player.UserName);
                PrintSlow("\nThe sensor added successfully.", 10);
            }
            else
            {
                DALPlayers.UpdateFailedAttempts(player.UserName);
                PrintSlow($"\nWrong!", 0);

                if (iranianAgent.GetLenAttachedSensors() > 0)
                {
                    iranianAgent.DownQuantityLifeSensor();
                }
            }

            DALPlayers.UpdateTotalAttempts(player.UserName);
        }

        public static void FinishLevel(Player player, Agent iranianAgent)
        {
            PrintSlow($"\nSuccess!\nYou exposed the agent: {iranianAgent.Name} in rank: {iranianAgent.Rank}");
            DALPlayers.UpdateLevel(player.UserName);
            string newRank = GetNewRank(player.Level + 1);
            DALPlayers.UpdateRankExposed(player.UserName, newRank);
        }

        public static void PrintSlow(string text, int delay = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            Thread.Sleep(delay);
        }
    }
}
