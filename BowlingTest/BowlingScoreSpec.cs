using Bowling;
using NUnit.Framework;

namespace BowlingTest
{
    public class BowlingScoreSpec
    {
        private BowlingScore _bowlingScore = new BowlingScore();
        
        [SetUp]
        public void Setup()
        {
            this._bowlingScore = new BowlingScore();
        }

        [TearDown]
        public void Teardown()
        {
            this._bowlingScore = null;
        }

        [Test]
        public void Bowling_Score_Instantiates_Successfully()
        {
            Assert.NotNull(this._bowlingScore);
        }

        [Test]
        public void A_Game_Of_All_Gutterballs_Scores_Zero()
        {
            // var game = new BowlingGame();
            // this._bowlingScore.Calculate(game);
        }
    }
}