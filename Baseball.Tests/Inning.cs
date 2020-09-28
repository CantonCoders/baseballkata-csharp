namespace Baseball.Tests
{
    internal class Inning
    {
        private Team homeTeam;
        private Team awayTeam;
        public Inning(Team homeTeam, Team awayTeam)
        {
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            AtBatTeam = awayTeam;

        }

        internal void AddOut()
        {
            OutCount++;
            if (IsInningOver())
            {
                ResetOutCount();
                switchAtBatTeams();
            }
        }

        private void ResetOutCount()
        {
            OutCount = 0;
        }

        private void switchAtBatTeams()
        {
            AtBatTeam = awayTeam == AtBatTeam ? homeTeam : awayTeam;
        }

        public void AddRun()
        {
            AtBatTeam.AddRun();
        }
        public bool IsInningOver() => OutCount >= 3;

        public int OutCount { get; internal set; }
        public Team AtBatTeam { get; internal set; }
    }
}