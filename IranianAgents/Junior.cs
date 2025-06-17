using InvestigationsProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.IranianAgents
{
    public class Junior : Agent
    {
        public Junior(string name, List<string> weaknesses) : base(name, weaknesses)
        {
            Rank = "Junior";
        }
    }
}
