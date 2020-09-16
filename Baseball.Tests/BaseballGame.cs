using System;

namespace Baseball.Tests
{
    internal class BaseballGame
    {
        public const int HOMERUN = 4;
        public const int OUT = 0;
        public const int DOUBLE = 2;
        public const int SINGLE = 1;

        private bool IsThirdBaseLoaded
        {
            get { return this.bases[3]; }
            set { this.bases[3] = value; }
        }

        private bool IsSecondBaseLoaded { 
            get { return this.bases[2]; } 
            set { this.bases[2] = value; } 
        }

        private bool IsFirstBaseLoaded
        {
            get { return this.bases[SINGLE]; }
            set { this.bases[SINGLE] = value; }
        }

        private int awayRuns = 0;
        private int homeTeamRuns = 0;
        private int countOuts = 0;

        private bool isAwayTeamBatting = true;
        private bool[] bases = new bool[4];

        public BaseballGame()
        {

        }

        public string ScoreCard
        {
            get { return $"Home: {homeTeamRuns} Away: {awayRuns}"; }
        }

        internal void AddEntry(int atBat)
        {
            switchInning();

            if (atBat == SINGLE && this.IsFirstBaseLoaded 
                           && this.IsSecondBaseLoaded
                           && this.IsThirdBaseLoaded)
            {
                awayTeamScores();
                    
            }
            else if (atBat == SINGLE && this.IsFirstBaseLoaded && this.IsSecondBaseLoaded)
            {
                IsThirdBaseLoaded = true;
            }
            else if (atBat == SINGLE && this.IsFirstBaseLoaded)
            {
                IsSecondBaseLoaded = true;
            }
            else if (atBat == SINGLE)
            {
                IsFirstBaseLoaded = true;
            }


            if (atBat == DOUBLE && this.IsSecondBaseLoaded)
            {
                IsSecondBaseLoaded = true;
                homeTeamScores();
            }
            else if (atBat == DOUBLE)
            {
                IsSecondBaseLoaded = true;
            }

            if (atBat == HOMERUN)
            {
                if (isAwayTeamBatting)
                    awayTeamScores();
                else
                    homeTeamScores();
            }
            else if (atBat == OUT)
                countOuts++;
        }

        private void awayTeamScores()
        {
            awayRuns++;
        }

        private void homeTeamScores()
        {
            this.homeTeamRuns++;
        }

        private void switchInning()
        {
            if (isInningOver())
                isAwayTeamBatting = !isAwayTeamBatting;
        }

        private bool isInningOver()
        {
            return countOuts % 3 == 0 && countOuts != 0;
        }
    }
}