using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingGame
    {
        private readonly List<Frame> _finishedFrames = new List<Frame>();
        private readonly List<int> _bonusRolls = new List<int>();
        private Frame _currentFrame = new Frame();

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
            this._finishedFrames.Count == 10 && this._finishedFrames.Last().RollSum < 10 ||
            this._finishedFrames.Count == 10 && this._finishedFrames.Last().IsSpare && this._bonusRolls.Count == 1 ||
            this._finishedFrames.Count == 10 && this._finishedFrames.Last().IsStrike && this._bonusRolls.Count == 2;

        private void FinalizeFrame()
        {
            this._finishedFrames.Add(this._currentFrame);
            this._currentFrame = new Frame();
        }
        
        private bool RegularRollsAreFinished => this._finishedFrames.Count == 10;

        private class Frame
        {
            private byte _pinsLeft = 10;
            private List<int> _rolls = new List<int>();

            public void Roll(byte knockedPins)
            {
                if (knockedPins > 10) throw new ArgumentException();
                if (knockedPins > this._pinsLeft) throw new ArgumentException();

                this._rolls.Add(knockedPins);
                this._pinsLeft -= knockedPins;
            }

            public bool Finished =>
                this._pinsLeft == 0 || this._rolls.Count == 2;

            public int RollSum => this._rolls.Sum();

            public bool IsStrike => this._pinsLeft == 0 && this._rolls.Count == 1;
            
            public bool IsSpare => this._pinsLeft == 0 && this._rolls.Count == 2;
        }
    }
}