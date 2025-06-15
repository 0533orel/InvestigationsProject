using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.Classes
{
    public abstract class Sensor
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }


        public Sensor(string name)
        {
            Name = name;
            IsActive = true;
        }


        public abstract bool Activate();
        
    }


}
