using System;
using System.Collections.Generic;

namespace Bowling
{
        public class BowlingFrame
        {
            private byte _pinsLeft = 10;
            private List<int> _rolls = new List<int>();

            public void Roll(byte knockedPins)
            {
                if (this.Finished) throw new InvalidOperationException();
                if (knockedPins > 10) throw new ArgumentException();
                if (knockedPins > this._pinsLeft) throw new ArgumentException();

                this._rolls.Add(knockedPins);
                this._pinsLeft -= knockedPins;
            }

            public bool Finished =>
                this._pinsLeft == 0 || this._rolls.Count == 2;

            public List<int> Rolls => new List<int>(this._rolls);

            public bool IsStrike => this._pinsLeft == 0 && this._rolls.Count == 1;
            
            public bool IsSpare => this._pinsLeft == 0 && this._rolls.Count == 2;
        }
}