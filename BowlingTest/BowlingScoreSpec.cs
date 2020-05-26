using Bowling;
using NUnit.Framework;

namespace BowlingTest
{
    public class BowlingScoreSpec
    {
        private BowlingScore _score;
        private BowlingGame _game;
        
        [SetUp]
        public void Setup()
        {
            this._game = new BowlingGame();
            this._score = new BowlingScore();
        }
        
        [TearDown]
        public void Teardown()
        {
            this._score = null;
            this._game = null;
        }

        [Test]
        public void A_Game_Of_All_Gutter_Balls_Scores_Zero()
        {
            while (!this._game.Finished) this._game.Roll(0);
            var score = this._score.Calculate(this._game);
            Assert.Zero(score);
        }

        [Test]
        public void A_Game_Of_All_1s_Scores_20()
        {
            while (!this._game.Finished) this._game.Roll(1);
            var score = this._score.Calculate(this._game);
            Assert.AreEqual(20, score);
        }
        
        [Test]
        public void A_Game_With_5_5_And_All_Gutter_Balls_After_Scores_10()
        {
            this._game.Roll(5);
            this._game.Roll(5);
            while (!this._game.Finished) this._game.Roll(0);
            var score = this._score.Calculate(this._game);
            Assert.AreEqual(10, score);
        }
        
        [Test]
        public void A_Game_With_5_5_5_And_All_Gutter_Balls_After_Scores_20()
        {
            for (var i = 0; i < 3; i++) this._game.Roll(5);
            while (!this._game.Finished) this._game.Roll(0);
            var score = this._score.Calculate(this._game);
            Assert.AreEqual(20, score);
        }
        
        [Test]
        public void A_Game_With_10_And_All_Gutter_Balls_After_Scores_10()
        {
            this._game.Roll(10);
            while (!this._game.Finished) this._game.Roll(0);
            var score = this._score.Calculate(this._game);
            Assert.AreEqual(10, score);
        }
        
        [Test]
        public void A_Game_With_10_5_3_And_All_Gutter_Balls_After_Scores_17()
        {
            this._game.Roll(10);
            this._game.Roll(5);
            this._game.Roll(3);
            while (!this._game.Finished) this._game.Roll(0);
            var score = this._score.Calculate(this._game);
            Assert.AreEqual(26, score);
        }
        
        [Test]
        public void A_Game_With_10_5_5_2_And_All_Gutter_Balls_After_Scores_34()
        {
            this._game.Roll(10);
            this._game.Roll(5);
            this._game.Roll(5);
            this._game.Roll(2);
            while (!this._game.Finished) this._game.Roll(0);
            var score = this._score.Calculate(this._game);
            Assert.AreEqual(34, score);
        }
        
        [Test]
        public void A_Game_With_10_10_2_3_And_All_Gutter_Balls_After_Scores_42()
        {
            this._game.Roll(10);
            this._game.Roll(10);
            this._game.Roll(2);
            this._game.Roll(3);
            while (!this._game.Finished) this._game.Roll(0);
            var score = this._score.Calculate(this._game);
            Assert.AreEqual(42, score);
        }

        [Test]
        public void A_Game_With_18_Gutter_Balls_5_5_3_Scores_13()
        {
            for (var i = 0; i < 18; i++) this._game.Roll(0);
            this._game.Roll(5);
            this._game.Roll(5);
            this._game.Roll(3);
            var score = this._score.Calculate(this._game);
            Assert.AreEqual(13, score);
        }
        
        [Test]
        public void A_Game_With_18_Gutter_Balls_10_5_3_Scores_18()
        {
            for (var i = 0; i < 18; i++) this._game.Roll(0);
            this._game.Roll(5);
            this._game.Roll(5);
            this._game.Roll(3);
            var score = this._score.Calculate(this._game);
            Assert.AreEqual(13, score);
        }
    }
}