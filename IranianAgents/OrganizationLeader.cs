using InvestigationsProject.Classes;
using InvestigationsProject.Factories;
using InvestigationsProject.Game;
using InvestigationsProject.IranianAgents.Interfaces;

namespace InvestigationsProject.IranianAgents
{
    public class OrganizationLeader : Agent, IStrikeBackable
    {
        int CounterAttack = 0;

        public OrganizationLeader(string rank, List<string> weaknesses) : base(rank, weaknesses) { }

        public void StrikeBack()
        {
            CounterAttack++;
            if (CounterAttack % 10 == 0)
            {
                secretWeaknesses = FactoryAgents.GetRandomWeaknesses(8);
                attachedSensors.Clear();
                Helper.PrintSlow($"\nThe agent broke all the sensors and changed the list", 5);
            }
            else if (CounterAttack % 3 == 0)
            {
                if (attachedSensors.Count > 0)
                {
                    Random random = new Random();
                    int index = random.Next(attachedSensors.Count);
                    attachedSensors.RemoveAt(index);
                    Helper.PrintSlow($"\nThe agent broke one of the attached sensors.", 5);
                }
            }
        }
    }
}
