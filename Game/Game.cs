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

            static List<string> sensors = new List<string> { "mobile", "movement", "thermal" };

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
                    iranianAgent.AttachedSensor(sensor);

                Console.WriteLine($"\nAnswered: {iranianAgent.LenAttachedSensors()}/{iranianAgent.LenSecretWeaknesses()}\n");

                if (iranianAgent.LenAttachedSensors() == iranianAgent.LenSecretWeaknesses())
                {
                    Console.WriteLine("\nDone\n");
                    break;
                }
            }
        }
    }

}

