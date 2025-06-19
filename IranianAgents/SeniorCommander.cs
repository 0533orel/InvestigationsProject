using InvestigationsProject.Classes;
using InvestigationsProject.Game;
using InvestigationsProject.IranianAgents.Interfaces;

namespace InvestigationsProject.IranianAgents
{
    public class SeniorCommander : Agent, IStrikeBackable
    {
        int CounterAttack = 3;

        public SeniorCommander(string rank, List<string> weaknesses) : base(rank, weaknesses) { }

        public void StrikeBack()
        {
            CounterAttack--;
            if (CounterAttack == 0)
            {
                if (attachedSensors.Count > 0)
                {
                    Random random = new Random();
                    int counterRemoved = 0;
                    while (attachedSensors.Count > 0 && counterRemoved < 2)
                    {
                        int index = random.Next(attachedSensors.Count);
                        attachedSensors.RemoveAt(index);
                        counterRemoved++;
                    }
                    Helper.PrintSlow($"\nThe agent broke {counterRemoved} of the sensors", 5);
                }
                CounterAttack = 3;
            }

        }
    }
}
