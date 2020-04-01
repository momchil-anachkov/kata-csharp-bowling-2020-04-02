using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingGame
    {
        private readonly List<Frame> _finishedFrames = new List<Frame>();
        private Frame _currentFrame = new Frame(false);

        public void Roll(byte knockedPins)
        {
            if (this.Finished) throw new InvalidOperationException();
            this._currentFrame.Roll(knockedPins);
            if (this._currentFrame.Finished) this.FinalizeFrame();
        }

        private void FinalizeFrame()
        {
            this._finishedFrames.Add(this._currentFrame);
            this._currentFrame = new Frame(this.IsLastFrame);
        }
        
        private bool IsLastFrame => this._finishedFrames.Count == 9;

        public bool Finished => this._finishedFrames.Count == 10;

        private class Frame
        {
            private readonly bool _isLastFrame;
            private byte _pinsLeft = 10;
            private List<int> _rolls = new List<int>();

            public Frame(bool isLastFrame)
            {
                this._isLastFrame = isLastFrame;
            }

            public void Roll(byte knockedPins)
            {
                if (knockedPins > 10) throw new ArgumentException();
                if (knockedPins > this._pinsLeft) throw new ArgumentException();

                this._rolls.Add(knockedPins);
                this._pinsLeft -= knockedPins;
                if (this._pinsLeft == 0  && this._isLastFrame && this._rolls.Count < 3) this._pinsLeft = 10;
            }

            public bool Finished =>
                (this.RollSum < 10 && this._rolls.Count == 2) ||
                (this.RollSum == 10 && !this._isLastFrame) ||
                (this.RollSum > 10 && this._isLastFrame && this._rolls.Count == 3);

            private int RollSum
            {
                get { return this._rolls.Sum(); }
            }
        }
    }
}