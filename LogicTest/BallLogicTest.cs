using LogicTest;
using Xunit;

namespace LogicTest
{
    public class BallLogicTest
    {
        [Fact]
        public void TestBallBouncesOffWalls()
        {
            // Inicjalizacja pi³ki na pozycji (50, 50) z promieniem 10 i prêdkoœciami 2 (w prawo) oraz 3 (w dó³)
            var ball = new Ball(50, 50, 10, 2, 3);
            var ballLogic = new BallLogic(ball);

            // Za³ó¿my, ¿e canvas ma rozmiar 100x100
            double canvasWidth = 100;
            double canvasHeight = 100;

            // Sprawdzamy pocz¹tkow¹ pozycjê pi³ki
            Assert.Equal(50, ball.X);
            Assert.Equal(50, ball.Y);

            // Przemieszczamy pi³kê
            ballLogic.MoveBall(canvasWidth, canvasHeight);

            // Po przesuniêciu pi³ki oczekujemy, ¿e nowa pozycja to 52, 53
            Assert.Equal(52, ball.X);  // 50 + 2 = 52
            Assert.Equal(53, ball.Y);  // 50 + 3 = 53

            // Teraz ustawiamy pi³kê blisko krawêdzi (90, 90), aby mog³a odbiæ siê od œciany
            ball.X = 90;
            ball.Y = 90;

            // Przemieszczamy pi³kê z prêdkoœciami 2 (w prawo) i 3 (w dó³)
            ballLogic.MoveBall(canvasWidth, canvasHeight);

            // Oczekujemy, ¿e pi³ka odbije siê od prawej i dolnej krawêdzi, wiêc jej nowa pozycja bêdzie wynosiæ 92, 93
            Assert.Equal(92, ball.X);  // 90 + 2 = 92
            Assert.Equal(93, ball.Y);  // 90 + 3 = 93
        }
    }
}
