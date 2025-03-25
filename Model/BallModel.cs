using System;
using System.Collections.Generic;

public class BallModel
{
    private readonly List<BallLogic> _balls = new List<BallLogic>();

    public void AddBall(double x, double y, double radius, double velocityX, double velocityY)
    {
        var ball = new Ball(x, y, radius, velocityX, velocityY);
        var ballLogic = new BallLogic(ball);
        _balls.Add(ballLogic);
    }

    public void UpdateBalls(double canvasWidth, double canvasHeight)
    {
        foreach (var ballLogic in _balls)
        {
            ballLogic.MoveBall(canvasWidth, canvasHeight);
        }
    }

    public List<BallLogic> GetBalls() => _balls;

    public void AddBall(double x, double y, double radius)
    {
        throw new NotImplementedException();
    }

    public void UpdateBalls()
    {
        throw new NotImplementedException();
    }
}
