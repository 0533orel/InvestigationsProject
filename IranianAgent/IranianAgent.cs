using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationsProject.Classes
{
    public class IranianAgent
    {


        string[] Weaknesses = new string[] { "movement", "thermal", "mobile" };

        public int Id { get; set; }
        public string Name { get; set; }
        public string rank;
        public string[] SecretWeaknesses = new string[2];

        public IranianAgent(string[] secretWeaknesses)
        {
            Random rand = new Random();
            string[] ranks = new string[] { "junior", "Class commander", "Company commander", "senior" };
            rank = ranks[0];

            SecretWeaknesses = secretWeaknesses;
        }

        public static void Active()
        {

        }
    }
}
