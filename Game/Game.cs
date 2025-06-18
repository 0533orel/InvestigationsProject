using InvestigationsProject.Classes;
using InvestigationsProject.DAL;
using InvestigationsProject.Factories;
using InvestigationsProject.IranianAgents.Interfaces;
using InvestigationsProject.players;
using InvestigationsProject.Sensors;
using static InvestigationsProject.Game.Helper;

namespace InvestigationsProject.Game
{
    public static class GameControl
    {
        public static void GameMenu()
        {
            PrintSlow("=== Welcome to the Investigation Game ===\n");

            Player player = GetPlayer();
            player = PrintToPlayer(player);

            while (true)
            {
                PrintSlow("\nMain Menu:");
                PrintSlow("1. Start");
                PrintSlow("2. Show Player Info");
                PrintSlow("3. Exit Game");
                PrintSlow("\nSelect an option (1-3): ", 20);

                string menuChoice = Console.ReadLine()?.Trim();

                switch (menuChoice)
                {
                    case "1":
                        player = StartGame(player);
                        if (player.Level > 2)
                            PrintSlow("\nCongratulations! You've completed the investigation.");
                        break;

                    case "2":
                        PrintSlow($"\n--- Player Info ---\nUsername: {player.UserName}\nLevel: {player.Level}\nRevealed Rank: {player.RankExposed}\nAttempts: {player.TotalAttempts}\n");
                        break;

                    case "3":
                        PrintSlow("\nThank you for playing. Goodbye!");
                        return;

                    default:
                        PrintSlow("\nInvalid selection. Please choose 1, 2, or 3.");
                        break;
                }
            }
        }

        private static Player StartGame(Player player)
        {
            Agent iranianAgent = FactoryAgents.CreateAgent(player.RankExposed);
            PrintSlow($"\n=== Starting Level {player.Level} ===");

            while (true)
            {
                // Debug: show weaknesses
                Console.WriteLine(String.Join(" | ", iranianAgent.secretWeaknesses));

                string userSelection = GetUserSelection();
                Sensor sensor = CreateSensor(userSelection);

                ActiveSensor(player, sensor, iranianAgent);

                if (iranianAgent is IStrikeBackable agent)
                    agent.StrikeBack();

                PrintSlow($"\nProgress: {iranianAgent.GetLenAttachedSensors()}/{iranianAgent.GetLenSecretWeaknesses()} sensors attached\n");

                if (iranianAgent.GetLenAttachedSensors() == iranianAgent.GetLenSecretWeaknesses())
                {
                    FinishLevel(player, iranianAgent);
                    break;
                }
            }
            player = DALPlayers.GetPlayerByUserName(player.UserName);
            return player;
        }
    }
}
