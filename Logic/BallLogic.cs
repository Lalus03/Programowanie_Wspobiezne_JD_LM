public class BallLogic
{
    private readonly Ball _ball;

    public BallLogic(Ball ball)
    {
        _ball = ball;
    }

    // Aktualizacja pozycji piłki
    public void MoveBall(double canvasWidth, double canvasHeight)
    {
        _ball.X += _ball.VelocityX;
        _ball.Y += _ball.VelocityY;

        // Odbicie od ścian
        if (_ball.X - _ball.Radius <= 0 || _ball.X + _ball.Radius >= canvasWidth)
        {
            _ball.VelocityX = -_ball.VelocityX;
        }

        if (_ball.Y - _ball.Radius <= 0 || _ball.Y + _ball.Radius >= canvasHeight)
        {
            _ball.VelocityY = -_ball.VelocityY;
        }
    }

    public Ball GetBall() => _ball;
}
