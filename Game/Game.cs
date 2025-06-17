using InvestigationsProject.Classes;
using InvestigationsProject.Factories;
using InvestigationsProject.IranianAgents;
using InvestigationsProject.players;
using InvestigationsProject.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.Game
{
    public static class GameControl
    {
        public static void Game()
        {
            Junior iranianAgent = FactoryAgents.JuniorAgent();
            List<string> sensors = FactoryWeaknesses.sensors;

            Console.WriteLine("Welcome to the investigation game!");
            Player player = Helper.GetPlayer();
            Console.WriteLine($"\nWelcome {player.FullName}!\n" +
                                 "\nWe have captured an Iranian agent and we want to expose him. For this we need to attach 'several' sensors to him according to his weaknesses.\n");

            while (true)
            {

                string userSelection = Helper.GetUserSelection(sensors);
                Sensor sensor = Helper.CreateSensor(userSelection);

                bool ActiveSensor = sensor.Activate(iranianAgent);

                if (ActiveSensor)
                    iranianAgent.AttachSensor(sensor);
                else if (iranianAgent.GetLenAttachedSensors() > 0)
                    iranianAgent.DownQuantityLifeSensor();

                Console.WriteLine($"\nAnswered: {iranianAgent.GetLenAttachedSensors()}/{iranianAgent.GetLenSecretWeaknesses()}\n");

                if (iranianAgent.GetLenAttachedSensors() == iranianAgent.GetLenSecretWeaknesses())
                {
                    Console.WriteLine($"\nDone\n" +
                        $"You exposed the agent: {iranianAgent.Name} in rank: {iranianAgent.Rank}");
                    break;
                }
            }
        }
    }

}

