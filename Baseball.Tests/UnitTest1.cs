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
 *  getScore - Returns the score in the format Home: [HOME_SCORE] Away: [AWAY_SCORE] except when a game is completed after 9 innings FINAL will be pre-pending to the score.
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
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(false);
        }
    }
}
