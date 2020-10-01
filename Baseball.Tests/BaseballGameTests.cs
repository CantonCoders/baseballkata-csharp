using System;
using Xunit;
using FluentAssertions;
/*
 * Thanks Code Wars!
 * Your school has hired you to keep track of the score at baseball games. 
 * Unfortunately you tend to be rather absent minded because most nights you stay up late on lean coffees and coding. 
 * Let's create a program that will keep track of the score for us.
 * We'll need to create a constructor ScoreCard that has two public functions: addEntry and getScore.
 *  addEntry - Takes in the result of an at-bat. This result can be single, double, triple, homerun, or out.
 *  getScore - Returns the score in the format Home: [HOME_SCORE] Away: [AWAY_SCORE] except 
 *  when a game is completed after 9 innings FINAL will be pre-pended to the score.
    To keep things simple, base runners will advance the amount of bases equal to that of the batter's hit 
        (i.e. if the batter hits a double, each base-runner will advance two bases)
    
    A few important baseball rul
    1. The Away team bats first.
    2. There are three outs in an inning
    3. After three outs the opposing team hits.
    The hits single, double, triple and homerun correspond to the batter reaching bases first, second, third and home respectively.

    Base runners start at home and then cycle through the bases first, second, third and home.
    Runners score for their team after they reach home.
    For more information on baseball visit here: http://en.wikipedia.org/wiki/Baseball
 */
namespace Baseball.Tests
{
    public class BaseballGameTests
    {
        private BaseballGame game;
        
        public BaseballGameTests()
        {
            game = new BaseballGame();
        }

        private void AssertScore(int homeScore, int awayScore)
        {
            game.ScoreCard.Should().Be($"Home: {homeScore} Away: {awayScore}");
        }

   




        [Fact]
        public void GameStartsAtZeroZero()
        {
            AssertScore(0, 0);
        }

        [Fact]
        public void Test_WhenGameStartsHomeZeroAwayZero()
        {
            BaseballGame game = new BaseballGame();
            game.ScoreCard.Should().Be("Home: 0 Away: 0");
        }
        [Fact]
        public void Test_FourSingles()
        {
            BaseballGame game = new BaseballGame();
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);

            game.ScoreCard.Should().Be("Home: 0 Away: 1");

        }

        [Fact]
        public void Test_2DoublesHomeOneAwayZero()
        {
            BaseballGame game = new BaseballGame();
            game.AddEntry(AtBatResult.OUT);
            game.AddEntry(AtBatResult.OUT);
            game.AddEntry(AtBatResult.OUT);

            game.AddEntry(AtBatResult.DOUBLE);
            game.AddEntry(AtBatResult.DOUBLE);
          
            game.ScoreCard.Should().Be("Home: 1 Away: 0");

        }

        [Fact]
        public void Test_2DoublesHomeZeroAwayOne()
        {
            BaseballGame game = new BaseballGame();
        
            game.AddEntry(AtBatResult.DOUBLE);
            game.AddEntry(AtBatResult.DOUBLE);

            game.ScoreCard.Should().Be("Home: 0 Away: 1");

        }

        [Fact]
        public void Test_2TriplesHomeZeroAwayOne()
        {
            BaseballGame game = new BaseballGame();

            game.AddEntry(AtBatResult.TRIPLE);
            game.AddEntry(AtBatResult.TRIPLE);

            game.ScoreCard.Should().Be("Home: 0 Away: 1");

        }

        [Fact]
        public void Test_HomeRunHomeZeroAway1()
        {
            BaseballGame game = new BaseballGame();
            game.AddEntry(AtBatResult.HOMERUN);

            game.ScoreCard.Should().Be("Home: 0 Away: 1");

        }



        [Fact]
        public void HomeRunWorthOneRun()
        {
            game.AddEntry(AtBatResult.HOMERUN);
            AssertScore(0, 1);
            game.AddEntry(AtBatResult.HOMERUN);
            AssertScore(0, 2);
        }

        [Fact]
        public void SwitchingScoringAfterThreeOuts()
        {
            game.AddEntry(AtBatResult.HOMERUN);
            game.AddEntry(AtBatResult.HOMERUN);
            game.AddEntry(AtBatResult.OUT);
            game.AddEntry(AtBatResult.OUT);
            game.AddEntry(AtBatResult.OUT);
            game.AddEntry(AtBatResult.OUT);



            game.AddEntry(AtBatResult.HOMERUN);

            AssertScore(1, 2);
        }

        [Fact]
        public void DoubleDrivesSecondBaserunnerHome()
        {
            game.AddEntry(AtBatResult.HOMERUN);
            game.AddEntry(AtBatResult.HOMERUN);

            game.AddEntry(AtBatResult.OUT);
            game.AddEntry(AtBatResult.OUT);
            game.AddEntry(AtBatResult.OUT);
            game.AddEntry(AtBatResult.OUT);

            game.AddEntry(AtBatResult.HOMERUN);

            game.AddEntry(AtBatResult.DOUBLE);
            game.AddEntry(AtBatResult.DOUBLE);
            game.AddEntry(AtBatResult.DOUBLE);

            AssertScore(3, 2);
        }

        [Fact]
        public void SinglesScore()
        {
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);


            AssertScore(0, 2);
        }
        [Fact]
        public void Test_SingleTripleHomeZeroAway1()
        {
            BaseballGame game = new BaseballGame();
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.TRIPLE);

            game.ScoreCard.Should().Be("Home: 0 Away: 1");
        }

        [Fact]
        public void Test_2SinglesTripleHomeZeroAway2()
        {
            BaseballGame game = new BaseballGame();
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.TRIPLE);

            game.ScoreCard.Should().Be("Home: 0 Away: 2");
        }

        [Fact]
        public void Test_3SinglesTripleHomeZeroAway3()
        {
            BaseballGame game = new BaseballGame();
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);

            game.AddEntry(AtBatResult.TRIPLE);

            game.ScoreCard.Should().Be("Home: 0 Away: 3");
        }

        [Fact]
        public void Test_2SinglesOneDoubleHomeZeroAway1()
        {
            BaseballGame game = new BaseballGame();
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.SINGLE);
            game.AddEntry(AtBatResult.DOUBLE);

            game.ScoreCard.Should().Be("Home: 0 Away: 1");



        }












    }
}
