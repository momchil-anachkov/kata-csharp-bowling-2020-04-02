using System.Linq;

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
                var frameScore = finishedFrames[i].Rolls.Sum();
                if (i == finishedFrames.Count() - 1)
                {
                    frameScore += game.BonusRolls.Sum();
                }
                else
                {
                    if (finishedFrames[i].IsSpare)
                    {
                        frameScore += finishedFrames[i + 1].Rolls[0];
                    }
                    else if (finishedFrames[i].IsStrike)
                    {
                        var nextFrame = finishedFrames[i + 1];
                        var nextNextFrame = finishedFrames[i + 2];
                        frameScore += nextFrame.Rolls[0];
                        if (nextFrame.IsStrike) frameScore += nextNextFrame.Rolls[0];
                        else frameScore += nextFrame.Rolls[1];
                    }
                }

                score += frameScore;
            }

            return score;
        }
    }
}