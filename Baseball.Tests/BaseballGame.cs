using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Tracing;

namespace Baseball.Tests
{
    internal class BaseballGame
    {
        public const int HOMERUN = 4;
        public const int TRIPLE = 3;
        public const int DOUBLE = 2;
        public const int SINGLE = 1;
        public const int OUT = 0;

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
            if(atBat == OUT)
            {
                countOuts++;
                switchInning();
                return;
            }
            if (atBat == SINGLE)
            {
                SingleHit();
                return;
            }
            if (atBat == TRIPLE)
            {
                TripleHit();
                return;
            }

            if (atBat == DOUBLE)
            {
                DoubleHit();
                return;
            }

            if (atBat == HOMERUN)
            {
                HomeRun();
                return;
            }
        }

        private void HomeRun()
        {
            if (isAwayTeamBatting)
                awayTeamScores();
            else
                homeTeamScores();
        }
        private void TripleHit()
        {
            SingleHit();
            SingleHit();
            SingleHit();
        }

        private void DoubleHit()
        {
            if (this.IsSecondBaseLoaded)
            {
                homeTeamScores();
            }
            IsSecondBaseLoaded = true;
        }

        private void SingleHit()
        {
            if (this.IsFirstBaseLoaded
                       && this.IsSecondBaseLoaded
                       && this.IsThirdBaseLoaded)
            {
                AtBatTeamScores();

            }
            else if (this.IsFirstBaseLoaded && this.IsSecondBaseLoaded)
            {
                IsThirdBaseLoaded = true;
            }
            else if (this.IsFirstBaseLoaded)
            {
                IsSecondBaseLoaded = true;
            }
            IsFirstBaseLoaded = true;
        }

        private void AtBatTeamScores()
        {
            if (isAwayTeamBatting)
            {
                awayTeamScores();
            }
            else
            {
                homeTeamScores();
            }
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
            {
                countOuts = 0;
                isAwayTeamBatting = !isAwayTeamBatting;
            }
        }

        private bool isInningOver() => countOuts >= 3;
    }
}