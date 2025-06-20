﻿

namespace InvestigationsProject.players
{
    public class Player
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string FullName { get; private set; }
        public string RankExposed { get; private set; }
        public int Level { get; private set; }
        public int SuccessfulAttempts { get; private set; }
        public int FailedAttempts { get; private set; }
        public int TotalAttempts { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Player(int id, string userName,  string rankExposed, int level, int successfulAttempts, int failedAttempts, int totalAttempts, DateTime createdAt, string fullName)
        {
            Id = id;
            UserName = userName;
            FullName = fullName;
            RankExposed = rankExposed;
            Level = level;
            SuccessfulAttempts = successfulAttempts;
            FailedAttempts = failedAttempts;
            TotalAttempts = totalAttempts;
            CreatedAt = createdAt;
        }
    }


}
