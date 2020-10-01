using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Tracing;

namespace Baseball.Tests
{
    internal partial class BaseballGame
    {
        private Diamond diamond;
        private ScoreBoard inning;

        public BaseballGame()
        {
            inning = new ScoreBoard();
            diamond = new Diamond(inning);
        }

        public string ScoreCard
        {
            get { return inning.GetScore(); }
        }



        public void AddEntry(AtBatResult atBat)
        {
            if (atBat == AtBatResult.OUT)
            {
                inning.AddOut();
                return;
            }

            this.diamond.RunBases(atBat);
        }
    }
}