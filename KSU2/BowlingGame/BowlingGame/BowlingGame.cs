using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
    class Game
    {
        private int[] rolls = new int[21];
        private int currentBowl;
        public void RollBall(int pins)
        {
            rolls[currentBowl++] = pins;
        }

        public int Score()
        {
            int TotalScore = 0;
            int roll = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    TotalScore += 10 + MadeAStrike(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    TotalScore += 10 + MadeASpare(roll);
                    roll += 2;
                }
                else
                {
                    TotalScore += SumFrame(roll);
                    roll += 2;
                }
            }
            return TotalScore;
        }
        private int SumFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }
        private int MadeASpare(int roll)
        {
            return rolls[roll + 2];
        }
        private int MadeAStrike(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }
        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }
    }

}
