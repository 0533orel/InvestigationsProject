using InvestigationsProject.Classes;
using InvestigationsProject.DAL;
using InvestigationsProject.Factories;
using InvestigationsProject.IranianAgents.Interfaces;
using InvestigationsProject.players;
using InvestigationsProject.Sensors;

namespace InvestigationsProject.Game
{
    public static class GameControl
    {
        public static void GameMenu()
        {
            Helper.PrintSlow("=== Welcome to the Investigation Game ===\n");

            Player player = Helper.GetPlayer();
            player = Helper.PrintToPlayer(player);

            while (true)
            {
                Helper.PrintSlow("\nMain Menu:", 5);
                Helper.PrintSlow("1. Start", 5);
                Helper.PrintSlow("2. Show Player Info", 5);
                Helper.PrintSlow("3. Exit Game", 5);
                Helper.PrintSlow("\nSelect an option (1-3): ", 5);

                string menuChoice = Console.ReadLine()?.Trim();

                switch (menuChoice)
                {
                    case "1":
                        if (player.Level < 5)
                            player = StartGame(player);
                        if (player.Level == 5)
                            Helper.PrintSlow("\nCongratulations! You've completed the investigation.", 5);
                        break;

                    case "2":
                        Helper.PrintSlow($"\n--- Player Info ---\nUsername: {player.UserName}\nLevel: {player.Level}\nRevealed Rank: {player.RankExposed}\nAttempts: {player.TotalAttempts}\n", 5);
                        break;

                    case "3":
                        Helper.PrintSlow("\nThank you for playing. Goodbye!", 5);
                        return;

                    default:
                        Helper.PrintSlow("\nInvalid selection. Please choose 1, 2, or 3.", 5);
                        break;
                }
            }
        }

        private static Player StartGame(Player player)
        {
            Agent iranianAgent = FactoryAgents.CreateAgent(player.RankExposed);
            Helper.PrintSlow($"\n=== Starting Level {player.Level} ===", 5);

            while (true)
            {
                // Debug: show weaknesses
                Console.WriteLine(String.Join(" | ", iranianAgent.secretWeaknesses));

                string userSelection = Helper.GetUserSelection();
                Sensor sensor = Helper.CreateSensor(userSelection);

                Helper.ActiveSensor(player, sensor, iranianAgent);

                if (iranianAgent is IStrikeBackable agent)
                    agent.StrikeBack();

                Helper.PrintSlow($"\nProgress: {iranianAgent.GetLenAttachedSensors()}/{iranianAgent.GetLenSecretWeaknesses()} sensors attached\n", 5);

                if (iranianAgent.GetLenAttachedSensors() == iranianAgent.GetLenSecretWeaknesses())
                {
                    Helper.FinishLevel(player, iranianAgent);
                    break;
                }
            }
            player = DALPlayers.GetPlayerByUserName(player.UserName);
            return player;
        }
    }
}
