using InvestigationsProject.Classes;
using InvestigationsProject.DAL;
using InvestigationsProject.Factories;
using InvestigationsProject.IranianAgents;
using InvestigationsProject.IranianAgents.Interfaces;
using InvestigationsProject.players;
using InvestigationsProject.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace InvestigationsProject.Game
{
    public static class GameControl
    {
        public static void Game()
        {
            Console.WriteLine("Welcome to the investigation game!");
            Player player = Helper.GetPlayer();

            if (player.SuccessfulAttempts > 0)
                Console.WriteLine($"\nWelcome back {player.FullName}!");
            else
                Console.WriteLine($"\nWelcome {player.FullName}!");
            Console.WriteLine($"\nWe have captured an Iranian agent and we want to expose him. For this we need to attach 'several' sensors to him according to his weaknesses.");

            int level = Helper.GetLevel(player.RankExposed);

            while (true)
            {
                Agent iranianAgent = FactoryAgents.CreateAgent(player.RankExposed);

                Console.WriteLine($"\nLevel {level}!");
                //for test
                Console.WriteLine(String.Join(" | ", iranianAgent.secretWeaknesses));

                while (true)
                {
                    string userSelection = Helper.GetUserSelection();
                    Sensor sensor = Helper.CreateSensor(userSelection);

                    bool ActiveSensor = sensor.Activate(iranianAgent);

                    if (ActiveSensor)
                    {
                        iranianAgent.AttachSensor(sensor);
                        DALPlayers.UpdateSuccessfulAttempts(player.UserName);
                    }
                    else 
                    {
                        DALPlayers.UpdateFailedAttempts(player.UserName);
                        if (iranianAgent.GetLenAttachedSensors() > 0)
                            iranianAgent.DownQuantityLifeSensor();
                    }

                    DALPlayers.UpdateTotalAttempts(player.UserName);

                    if (iranianAgent is IStrikeBackable agent)
                    {
                        agent.StrikeBack();
                    }

                    Console.WriteLine($"\nAnswered: {iranianAgent.GetLenAttachedSensors()}/{iranianAgent.GetLenSecretWeaknesses()}\n");

                    if (iranianAgent.GetLenAttachedSensors() == iranianAgent.GetLenSecretWeaknesses())
                    {
                        Console.WriteLine($"\nDone\n" +
                            $"You exposed the agent: {iranianAgent.Name} in rank: {iranianAgent.Rank}");
                        level++;
                        string newRank = Helper.GetNewRank(level);
                        DALPlayers.UpdateRankExposed(player.UserName, newRank);
                        player = DALPlayers.GetPlayerByUserName(player.UserName);
                        break;
                    }
                }
                if (level > 4)
                    break;
            }
        }
    }

}

