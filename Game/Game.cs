using InvestigationsProject.Classes;
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
            static Random rand = new Random();

            static string[] ranks = { "Junior", "Class commander", "Company commander", "Senior" };

            static List<string> sensors = new List<string> { "mobile", "movement", "thermal", "pulse" };

            static List<string> agentWeaknesses = new List<string>
                    {
                        sensors[rand.Next(sensors.Count)],
                        sensors[rand.Next(sensors.Count)]
                    };

            static IranianAgent iranianAgent = new IranianAgent("junior", agentWeaknesses);
        public static void Game()
        {

            Console.WriteLine("Welcome to the investigation game!\n" +
                "We have captured an Iranian agent and we want to expose him. For this we need to attach 'several' sensors to him according to his weaknesses.\n");

            while (true)
            {
                string userSelection = Helper.GetUserSelection(sensors);
                Sensor sensor = Helper.CreateSensor(userSelection);

                bool canAttach = sensor.Activate(iranianAgent);

                if (canAttach)
                    iranianAgent.AttachSensor(sensor);
                else if (iranianAgent.GetLenAttachedSensors() > 0)
                    iranianAgent.CheckQuantityLife();

                Console.WriteLine($"\nAnswered: {iranianAgent.GetLenAttachedSensors()}/{iranianAgent.GetLenSecretWeaknesses()}\n");

                if (iranianAgent.GetLenAttachedSensors() == iranianAgent.GetLenSecretWeaknesses())
                {
                    Console.WriteLine("\nDone\n");
                    break;
                }
            }
        }
    }

}

