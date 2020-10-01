using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Tracing;

namespace Baseball.Tests
{
    internal partial class BaseballGame
    {
        private Diamond diamond;
        private ScoreBoard scoreBoard;

        public BaseballGame()
        {
            scoreBoard = new ScoreBoard();
            diamond = new Diamond(scoreBoard);
        }

        public string ScoreCard
        {
            get { return scoreBoard.GetScore(); }
        }

        public void AddEntry(AtBatResult atBat)
        {
            if (atBat == AtBatResult.OUT)
            {
                scoreBoard.AddOut();
                return;
            }

            this.diamond.RunBases(atBat);
        }
    }
}