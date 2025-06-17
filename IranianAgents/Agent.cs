using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace InvestigationsProject.Classes
{
    public class Agent
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Rank { get; private set; }

        protected List<string> secretWeaknesses;

        protected List<Sensor> attachedSensors;

        public Agent(string name, string rank, List<string> weaknesses)
        {
            Name = name;
            Rank = rank;
            secretWeaknesses = weaknesses;
            attachedSensors = new List<Sensor>();
        }

        public void AttachSensor(Sensor sensor)
        {
            attachedSensors.Add(sensor);
        }

        public void DownQuantityLifeSensor()
        {
            for (int i = attachedSensors.Count - 1; i >= 0; i--)
            {
                attachedSensors[i].DownLifeQuantity();

                if (attachedSensors[i].GetQuantityLife() == 0)
                {
                    Console.WriteLine($"\nThe sensor {attachedSensors[i].Name} is broken");
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

