using System;
using System.Linq;
using NUnit.Framework;
using Bowling;

namespace BowlingTest
{
    public class BowlingFrameSpec
    {
        private BowlingFrame _frame;
        
        [SetUp]
        public void Setup()
        {
            this._frame = new BowlingFrame();
        }
        
        [Test]
        public void A_Frame_With_2_Rolls_Is_Finished()
        {
            this._frame.Roll(0);
            this._frame.Roll(0);
            Assert.True(this._frame.Finished);
        }
        
        [Test]
        public void A_Frame_With_One_Roll_Of_10_Is_Finished()
        {
            this._frame.Roll(10);
            Assert.True(this._frame.Finished);
        }
        
        [Test]
        public void Rolling_On_A_Finished_Frame_Throws_An_Exception()
        {
            this._frame.Roll(10);
            Assert.Throws<InvalidOperationException>(() => this._frame.Roll(7));
        }

        [Test]
        public void A_Frame_With_One_Roll_Of_10_Is_A_Strike_And_Not_A_Spare()
        {
            this._frame.Roll(10);
            Assert.True(this._frame.IsStrike);
            Assert.False(this._frame.IsSpare);
        }
        
        [TestCase(1,9)]
        [TestCase(3,7)]
        [TestCase(5,5)]
        public void A_Frame_With_Two_Rolls_That_Sum_To_10_Is_A_Spare_And_Not_A_Strike(byte roll1, byte roll2)
        {
            this._frame.Roll(roll1);
            this._frame.Roll(roll2);
            Assert.True(this._frame.IsSpare);
            Assert.False(this._frame.IsStrike);
        }

        [TestCase(new int[] { 1, 0 })]
        [TestCase(new int[] { 5, 5 })]
        [TestCase(new int[] { 3, 7 })]
        [TestCase(new int[] { 4 })]
        public void A_Frame_Returns_Correct_Sum_Of_Its_Rolls(int[] rolls)
        {
            foreach (var roll in rolls) this._frame.Roll((byte) roll);
            Assert.AreEqual(rolls.Sum(), this._frame.Rolls.Sum());
        }
        
        [TestCase(new int[] { 1, 0 })]
        [TestCase(new int[] { 5, 5 })]
        [TestCase(new int[] { 3, 7 })]
        [TestCase(new int[] { 4 })]
        public void A_Frame_Returns_Correct_Count_Of_Its_Rolls(int[] rolls)
        {
            foreach (var roll in rolls) this._frame.Roll((byte) roll);
            Assert.AreEqual(rolls.Count(), this._frame.Rolls.Count);
        }
    }
}