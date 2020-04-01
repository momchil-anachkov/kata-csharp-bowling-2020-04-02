using System;
using Bowling;
using NUnit.Framework;

namespace BowlingTest
{
    public class BowlingGameSpec
    {
        [Test]
        public void Knocking_More_Than_10_Pins_On_A_Roll_Throws_ArgumentException()
        {
            var game = new BowlingGame();
            Assert.Throws<ArgumentException>(() => game.Roll(11));
        }

        [Test]
        public void A_Game_Rolling_20_Gutter_Balls_Is_Finished()
        {
            var game = new BowlingGame();
            for (var i = 0; i < 20; i++) game.Roll(0);
            Assert.True(game.Finished);
        }

        [Test]
        public void A_Game_Rolling_19_Gutter_Balls_Is_Not_Finished()
        {
            var game = new BowlingGame();
            for (var i = 0; i < 19; i++) game.Roll(0);
            Assert.False(game.Finished);
        }

        [Test]
        public void A_Game_Rolling_A_Strike_And_18_Gutter_Balls_Is_Finished()
        {
            var game = new BowlingGame();
            game.Roll(10);
            for (var i = 0; i < 18; i++) game.Roll(0);
            Assert.True(game.Finished);
        }

        [Test]
        public void A_Game_Rolling_4_Strikes_And_12_Gutter_Balls_Is_Finished()
        {
            var game = new BowlingGame();
            for (var i = 0; i < 4; i++) game.Roll(10);
            for (var i = 0; i < 12; i++) game.Roll(0);
            Assert.True(game.Finished);
        }

        [Test]
        public void Rolling_On_A_Finished_Game_Throws_InvalidOperationException()
        {
            var game = new BowlingGame();
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (var i = 0; i < 21; i++) game.Roll(0);
            });
        }

        [Test]
        public void Rolling_7_4_Throws_ArgumentException()
        {
            var game = new BowlingGame();
            Assert.Throws<ArgumentException>(() =>
            {
                game.Roll(7);
                game.Roll(4);
            });
        }

        [Test]
        public void Rolling_7_3_9_1_Does_Not_Throw_An_Exception()
        {
            var game = new BowlingGame();
            Assert.DoesNotThrow(() =>
            {
                game.Roll(7);
                game.Roll(3);
                game.Roll(9);
                game.Roll(1);
            });
        }

        [Test]
        public void After_A_Strike_On_Roll_19_You_Can_Roll_2_More_Times()
        {
            var game = new BowlingGame();
            for(var i = 0; i < 18; i++) game.Roll(0);
            game.Roll(10);
            Assert.False(game.Finished);
            game.Roll(10);
            Assert.False(game.Finished);
            game.Roll(10);
            Assert.True(game.Finished);
        }
        
        [Test]
        public void After_A_Spare_On_Roll_20_You_Can_Roll_1_More_Time()
        {
            var game = new BowlingGame();
            for(var i = 0; i < 19; i++) game.Roll(0);
            game.Roll(10);
            Assert.False(game.Finished);
            game.Roll(7);
            Assert.True(game.Finished);
        }
    }
}