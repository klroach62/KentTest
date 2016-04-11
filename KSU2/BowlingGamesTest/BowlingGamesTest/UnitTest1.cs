using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using BowlingGameClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGamesTest
{
    [TestClass]
    public class BowlingGameTest
    {
        [TestMethod]
        public void TestGutter()
        {
            var g = SetGame();
            for (int i = 0; i < 20; i++)
                g.RollBall(0);
            Assert.AreEqual(0, g.Score());

        }

        [TestMethod]
        public void TestHittingOnePin()
        {
            var g = SetGame();
            for (int i = 0; i < 20; i++)
                g.RollBall(1);
            Assert.AreEqual(20, g.Score());

        }
        [TestMethod]
        public void TestHittingnoPinrolling()
        {
            var g = SetGame();
            RollPins(g, 20, 0);
            Assert.AreEqual(0, g.Score());

        }
        [TestMethod]
        public void TestHittingOnePinrolling()
        {
            var g = SetGame();
            RollPins(g, 20, 1);
            Assert.AreEqual(20, g.Score());

        }

        [TestMethod]
        public void TestOneSpare()
        {
            var g = SetGame();
            RollSpare(g);
            g.RollBall(3);
            RollPins(g, 17, 0);

            Assert.AreEqual(16, g.Score());

        }
        [TestMethod]
        public void TestOneStrike()
        {
            var g = SetGame();
            RollStrike(g);
            g.RollBall(3);
            g.RollBall(4);
            RollPins(g, 16, 0);

            Assert.AreEqual(24, g.Score());

        }

        [TestMethod]
        public void PerfectGame()
        {
            var g = SetGame();
            RollPins(g, 12, 10);

            Assert.AreEqual(300, g.Score());

        }

        private void RollSpare(Game g)
        {
            g.RollBall(7);
            g.RollBall(3);
        }
        private void RollStrike(Game g)
        {
            g.RollBall(10);
        }
        private Game SetGame()
        {
            return new Game();
        }

        private void RollPins(Game game, int numRolls, int pinsScored)
        {
            for (int i = 0; i < numRolls; i++)
            {
                game.RollBall(pinsScored);
            }
        }

    }
}
