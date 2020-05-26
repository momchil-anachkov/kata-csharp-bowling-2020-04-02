using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public partial class BowlingGame
    {
        private readonly List<BowlingFrame> _finishedFrames = new List<BowlingFrame>();
        private readonly List<int> _bonusRolls = new List<int>();
        private BowlingFrame _currentFrame = new BowlingFrame();

        public void Roll(byte knockedPins)
        {
            if (this.Finished) throw new InvalidOperationException();
            if (!this.RegularRollsAreFinished)
                this._currentFrame.Roll(knockedPins);
            else
                this._bonusRolls.Add(knockedPins);
            if (this._currentFrame.Finished) this.FinalizeFrame();
        }
        
        public bool Finished =>
            this._finishedFrames.Count == 10 && this._finishedFrames.Last().Rolls.Sum() < 10 ||
            this._finishedFrames.Count == 10 && this._finishedFrames.Last().IsSpare && this._bonusRolls.Count == 1 ||
            this._finishedFrames.Count == 10 && this._finishedFrames.Last().IsStrike && this._bonusRolls.Count == 2;

        public List<BowlingFrame> FinishedFrames => new List<BowlingFrame>(this._finishedFrames);

        public List<int> BonusRolls => _bonusRolls;

        private void FinalizeFrame()
        {
            this._finishedFrames.Add(this._currentFrame);
            this._currentFrame = new BowlingFrame();
        }
        
        private bool RegularRollsAreFinished => this._finishedFrames.Count == 10;
    }
}