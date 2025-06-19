using InvestigationsProject.Sensors;
using static InvestigationsProject.Game.Helper;

namespace InvestigationsProject.Classes
{
    public class Agent
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Location { get; private set; }
        public string FavoriteWeapon { get; private set; }
        public string ContactNumber { get; private set; }
        public string SecretPhrase { get; private set; }
        public string Affiliation { get; private set; }
        public string Rank { get; private set; }
        //public for test
        public List<string> secretWeaknesses;
        protected List<Sensor> attachedSensors;

        public Agent(int id, string firstName, string lastName, string location, string favoriteWeapon, string contactNumber, string secretPhrase, string affiliation)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Location = location;
            FavoriteWeapon = favoriteWeapon;
            ContactNumber = contactNumber;
            SecretPhrase = secretPhrase;
            Affiliation = affiliation;

        }

        public Agent(string rank, List<string> weaknesses)
        {
            Rank = rank;
            secretWeaknesses = weaknesses;
            attachedSensors = new List<Sensor>();
        }

        public void AttachSensor(Sensor sensor)
        {
            attachedSensors.Add(sensor);
        }

        public void DownQuantityLifeSensor()
        {
            for (int i = attachedSensors.Count - 1; i >= 0; i--)
            {
                attachedSensors[i].DownLifeQuantity();

                if (attachedSensors[i].GetQuantityLife() == 0)
                {
                    PrintSlow($"\nThe sensor {attachedSensors[i].Name} is broken", 5);
                    attachedSensors.RemoveAt(i);
                }
            }
        }

        public int GetLenSecretWeaknesses()
        {
            return secretWeaknesses.Count;
        }

        public int GetLenAttachedSensors()
        {
            return attachedSensors.Count;
        }

        public int GetTimesWeaknessExists(string weakness)
        {
            int counter = 0;
            foreach (String wkns in secretWeaknesses)
            {
                if (wkns == weakness)
                    counter++;
            }
            return counter;
        }

        public int GetTimesWeaknessAttached(string weakness)
        {
            int counter = 0;
            foreach (Sensor sensor in attachedSensors)
            {
                if (sensor.Name == weakness)
                    counter++;
            }
            return counter;
        }

        public List<string> GetSecretWeaknesses()
        {
            return new List<string>(secretWeaknesses);
        }

    }
}

