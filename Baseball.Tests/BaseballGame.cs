using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Tracing;

namespace Baseball.Tests
{
    internal class BaseballGame
    {
        public enum AtBatResult
        {
            HOMERUN = 4,
            TRIPLE = 3,
            DOUBLE = 2,
            SINGLE = 1,
            OUT = 0
        }

        private Diamond diamond = new Diamond();
        private Team homeTeam = new Team();
        private Team awayTeam = new Team();
        private Inning inning;


        public BaseballGame()
        {
            inning = new Inning(homeTeam, awayTeam);
        }

        public string ScoreCard
        {
            get { return $"Home: {homeTeam.Score} Away: {awayTeam.Score}"; }
        }

        public void AddEntry(AtBatResult atBat)
        {
            if (atBat == AtBatResult.OUT)
            {
                inning.AddOut();
                return;
            }
            if (atBat == AtBatResult.SINGLE)
            {
                if (this.diamond.AreBasesLoaded())
                {
                    inning.AddRun();

                }
                else if (this.diamond.IsFirstBaseLoaded && this.diamond.IsSecondBaseLoaded)
                {
                    diamond.IsThirdBaseLoaded = true;
                }
                else if (this.diamond.IsFirstBaseLoaded)
                {
                    diamond.IsSecondBaseLoaded = true;
                }
                diamond.IsFirstBaseLoaded = true;
                return;
            }

            if (atBat == AtBatResult.HOMERUN)
            {
                inning.AddRun();
            }

            if (atBat == AtBatResult.DOUBLE)
            {
                if (this.diamond.IsSecondBaseLoaded)
                {
                    inning.AddRun();
                }
                diamond.IsSecondBaseLoaded = true;
                return;
            }

            if (atBat == AtBatResult.TRIPLE)
            {
                if (this.diamond.IsFirstBaseLoaded)
                {
                    inning.AddRun();
                }

                if (this.diamond.IsSecondBaseLoaded)
                {
                    inning.AddRun();
                }
                if (this.diamond.IsThirdBaseLoaded)
                {
                    inning.AddRun();
                }
                else if (!this.diamond.IsThirdBaseLoaded)
                {
                    this.diamond.IsThirdBaseLoaded = true;
                }
                return;
            }
        }
  
    }
}