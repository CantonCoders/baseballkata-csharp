namespace Baseball.Tests
{
    internal class ScoreBoard
    {
        private Team homeTeam;
        private Team awayTeam;
        public ScoreBoard()
        {
            this.homeTeam = new Team();
            this.awayTeam = new Team();
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
        public string GetScore()
        {
            return $"Home: {homeTeam.Score} Away: {awayTeam.Score}";
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