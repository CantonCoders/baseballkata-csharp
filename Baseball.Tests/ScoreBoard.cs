namespace Baseball.Tests
{
    internal class ScoreBoard
    {
        private Score homeTeam;
        private Score awayTeam;
        public ScoreBoard()
        {
            this.homeTeam = new Score();
            this.awayTeam = new Score();
            AtBatTeam = awayTeam;
        }

        internal void AddOut()
        {
            OutCount++;
            if (IsInningOver())
            {
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
            ResetOutCount();
        }
        public string GetScore()
        {
            return $"Home: {homeTeam.Runs} Away: {awayTeam.Runs}";
        }
        public void AddRun()
        {
            AtBatTeam.AddRun();
        }
        public bool IsInningOver() => OutCount >= 3;

        public int OutCount { get; internal set; }
        public Score AtBatTeam { get; internal set; }
    }
}