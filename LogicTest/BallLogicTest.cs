using LogicTest;
using Xunit;

namespace LogicTest
{
    public class BallLogicTest
    {
        [Fact]
        public void TestBallBouncesOffWalls()
        {
            // Inicjalizacja pi�ki na pozycji (50, 50) z promieniem 10 i pr�dko�ciami 2 (w prawo) oraz 3 (w d�)
            var ball = new Ball(50, 50, 10, 2, 3);
            var ballLogic = new BallLogic(ball);

            // Za��my, �e canvas ma rozmiar 100x100
            double canvasWidth = 100;
            double canvasHeight = 100;

            // Sprawdzamy pocz�tkow� pozycj� pi�ki
            Assert.Equal(50, ball.X);
            Assert.Equal(50, ball.Y);

            // Przemieszczamy pi�k�
            ballLogic.MoveBall(canvasWidth, canvasHeight);

            // Po przesuni�ciu pi�ki oczekujemy, �e nowa pozycja to 52, 53
            Assert.Equal(52, ball.X);  // 50 + 2 = 52
            Assert.Equal(53, ball.Y);  // 50 + 3 = 53

            // Teraz ustawiamy pi�k� blisko kraw�dzi (90, 90), aby mog�a odbi� si� od �ciany
            ball.X = 90;
            ball.Y = 90;

            // Przemieszczamy pi�k� z pr�dko�ciami 2 (w prawo) i 3 (w d�)
            ballLogic.MoveBall(canvasWidth, canvasHeight);

            // Oczekujemy, �e pi�ka odbije si� od prawej i dolnej kraw�dzi, wi�c jej nowa pozycja b�dzie wynosi� 92, 93
            Assert.Equal(92, ball.X);  // 90 + 2 = 92
            Assert.Equal(93, ball.Y);  // 90 + 3 = 93
        }
    }
}
