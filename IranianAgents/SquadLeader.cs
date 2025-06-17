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
        int AgentTurn = 3;

        public SquadLeader(string name, string rank, List<string> weaknesses) : base(name, rank, weaknesses) { }


        public void StrikeBack()
        {
            AgentTurn--;
            if (AgentTurn == 0)
            {
                if (attachedSensors.Count > 0)
                {
                    Console.WriteLine($"\nThe agent broke one of the sensors");
                    attachedSensors.RemoveAt(attachedSensors.Count - 1);
                }
                AgentTurn = 3;
            }

        }
    }
}
