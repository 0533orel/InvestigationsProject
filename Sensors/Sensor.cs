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
        protected int quantityLife;


        public Sensor(string name)
        {
            Name = name;
        }


        public abstract bool Activate(IranianAgent agent);


        public abstract int GetQuantityLife();


        public abstract void DownLifeQuantity();
    }


}
