using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace InvestigationsProject.Classes
{
    public class IranianAgent
    {
        // for sql later
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        //

        private List<string> secretWeaknesses;

        private List<Sensor> attachedSensors;

        public IranianAgent(string rank, List<string> weaknesses)
        {
            Rank = rank;
            secretWeaknesses = weaknesses;
            attachedSensors = new List<Sensor>();
        }


        public void AttachSensor(Sensor sensor)
        {
            attachedSensors.Add(sensor);
        }



        public void CheckQuantityLife()
        {
            for (int i = attachedSensors.Count - 1; i >= 0; i--)
            {
                attachedSensors[i].DownLifeQuantity();

                if (attachedSensors[i].GetQuantityLife() == 0)
                {
                    Console.WriteLine($"The sensor {attachedSensors[i].Name} is broken");
                    attachedSensors.RemoveAt(i);
                }
            }
        }



        public int GetLenSecretWeaknesses()
        {
            return secretWeaknesses.Count;
        }

        public int GetLenAttachedSensors()
        {
            return attachedSensors.Count;
        }

        public int GetTimesWeaknessExists(string weakness)
        {
            int counter = 0;
            foreach (String wkns in secretWeaknesses)
            {
                if (wkns == weakness)
                    counter++;
            }
            return counter;
        }


        public int GetTimesWeaknessAttached(string weakness)
        {
            int counter = 0;
            foreach (Sensor sensor in attachedSensors)
            {
                if (sensor.Name == weakness)
                    counter++;
            }
            return counter;
        }
    }
}

