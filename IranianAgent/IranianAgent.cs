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


        public void AttachedSensor(Sensor sensor)
        {
            attachedSensors.Add(sensor);
        }


        public int LenSecretWeaknesses()
        {
            return secretWeaknesses.Count;
        }

        public int LenAttachedSensors()
        {
            return attachedSensors.Count;
        }

        public int TimesWhenWeaknessExists(string weakness)
        {
            int counter = 0;
            foreach (String wkns in secretWeaknesses)
            {
                if (wkns == weakness)
                    counter++;
            }
            return counter;
        }


        public int TimesWhenWeaknessAttached(string weakness)
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

