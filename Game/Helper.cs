using InvestigationsProject.Classes;
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
        public static string GetUserSelection(List<string> sensors)
        {
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
    }

}
