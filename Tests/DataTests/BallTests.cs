using System.Linq;
using Data;
using NUnit.Framework;

namespace DataTests
{
    [TestFixture]
    public class BallTests
    {
        [Test]
        public void Balls_Behavior_Is_Identical_With_And_Without_Logger()
        {
            DataLogger.ResetInstance("TestLogger.xml");

            var board1 = DataAbstractAPI.CreateDataAPI();
            board1.setBoardParameters(100, 100, 2);

            var board2 = DataAbstractAPI.CreateDataAPI();
            board2.setBoardParameters(100, 100, 2);

            var balls1 = board1.getBalls();
            var logger = DataLogger.GetInstance();
            var balls2 = board2.getBalls();
            foreach (var ball in balls2)
                logger.addToQueue(ball);

            
            Assert.That(balls1.Length, Is.EqualTo(balls2.Length));
            Assert.That(balls1.Select(b => b.ID), Is.EquivalentTo(balls2.Select(b => b.ID)));
        }
    }
}
