using System.Linq;
﻿using System.Collections.Generic;

namespace Bowling
{
    public class BowlingScore
    {
        public int Calculate(BowlingGame game)
        {
            var score = 0;
            var finishedFrames = game.FinishedFrames;
            for (var i = 0; i < finishedFrames.Count(); i++)
            {
                var currentFrame = finishedFrames[i];
                var frameScore = currentFrame.Rolls.Sum();
                if (currentFrameIsLastFrame(i, finishedFrames))
                    frameScore += game.BonusRolls.Sum();
                else
                    if (currentFrame.IsSpare) frameScore += nextRoll(i, finishedFrames);
                    else if (currentFrame.IsStrike) frameScore += nextTwoRolls(i, finishedFrames);
                score += frameScore;
            }

            return score;
        }

        private bool currentFrameIsLastFrame(int i, List<BowlingFrame> finishedFrames)
        {
            return i == finishedFrames.Count() - 1;
        }

        private int nextRoll(int i, List<BowlingFrame> frames)
        {
            var nextFrame = frames[i + 1];
            return nextFrame.Rolls[0];
        }

        private int nextTwoRolls(int i, List<BowlingFrame> frames)
        {
            var nextFrame = frames[i + 1];
            var nextNextFrame = frames[i + 2];
            return nextFrame.Rolls[0] + (nextFrame.IsStrike ? nextNextFrame.Rolls[0] : nextFrame.Rolls[1]);
        }
    }
}