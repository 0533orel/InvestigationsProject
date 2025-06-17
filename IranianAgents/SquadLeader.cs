using InvestigationsProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.IranianAgents
{
    public class SquadLeader : Agent
    {
        int CounterAttack = 3;

        public SquadLeader(string name, List<string> weaknesses) : base(name, weaknesses) 
        {
            Rank = "Squad Leader";
        }


        public void StrikeBack()
        {
            CounterAttack--;
            if (CounterAttack == 0)
            {
                if (attachedSensors.Count > 0)
                {
                    Console.WriteLine($"\nThe agent broke one of the sensors");
                    attachedSensors.RemoveAt(attachedSensors.Count - 1);
                }
                CounterAttack = 3;
            }

        }
    }
}
