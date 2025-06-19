using InvestigationsProject.Classes;
using InvestigationsProject.Game;
using InvestigationsProject.IranianAgents.Interfaces;



namespace InvestigationsProject.IranianAgents
{
    public class SquadLeader : Agent , IStrikeBackable
    {
        
        int CounterAttack = 3;

        public SquadLeader(string rank, List<string> weaknesses) : base(rank, weaknesses) { }

        public void StrikeBack()
        {
            CounterAttack--;
            if (CounterAttack == 0)
            {
                if (attachedSensors.Count > 0)
                {
                    Random random = new Random();
                    attachedSensors.RemoveAt(random.Next(attachedSensors.Count));
                    Helper.PrintSlow($"\nThe agent broke one of the sensors", 5);
                }
                CounterAttack = 3;
            }

        }
    }
}
