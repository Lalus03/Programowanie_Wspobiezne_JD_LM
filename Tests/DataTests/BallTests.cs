using System.Runtime.CompilerServices;
using Data;
using NUnit.Framework;

namespace DataTests
{
    [TestFixture]
    public class BallTests
    {
        [Test]
        public void DataApi_CanCreateBoardAndBalls()
        {
            
            DataLogger.ResetInstance("TestLogger.xml");

            var board = DataAbstractAPI.CreateDataAPI();
            board.setBoardParameters(100, 100, 2);

            var balls = board.getBalls();

            Assert.That(balls, Is.Not.Null);
            Assert.That(balls.Length, Is.EqualTo(2));
        }
    }
}
