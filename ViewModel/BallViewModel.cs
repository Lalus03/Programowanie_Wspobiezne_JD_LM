using ViewModel;

namespace ViewModel
{
    public class BallViewModel
    {
        private readonly BallModel _model;

        public BallViewModel()
        {
            _model = new BallModel();
        }

        public void AddBall(double x, double y, double radius)
        {
            _model.AddBall(x, y, radius);
        }

        public void Update()
        {
            _model.UpdateBalls();
        }
    }
}
