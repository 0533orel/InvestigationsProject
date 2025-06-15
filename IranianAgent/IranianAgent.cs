using System;
using System.Collections.Generic;
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

        public IranianAgent(List<string> weaknesses)
        {
            
            secretWeaknesses = weaknesses;
            attachedSensors = new List<Sensor>();
        }

       public void AttachedSensor(Sensor sensor)
        {
            attachedSensors.Add(sensor);
        }


    }
}
