using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace BallSimulation
{
    public partial class MainWindow : Window
    {
        private readonly BallModel _ballModel = new BallModel();
        private readonly System.Windows.Threading.DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            // Dodajemy przykładowe piłki
            _ballModel.AddBall(100, 100, 20, 2, 2);
            _ballModel.AddBall(200, 200, 30, -3, 3);
            _ballModel.AddBall(300, 300, 25, 1, -1);

            // Ustawiamy timer, aby piłki mogły się poruszać
            _timer = new System.Windows.Threading.DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(30)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _ballModel.UpdateBalls(BallCanvas.ActualWidth, BallCanvas.ActualHeight);
            DrawBalls();
        }

        private void DrawBalls()
        {
            // Czyścimy canvas
            BallCanvas.Children.Clear();

            // Rysujemy piłki na canvasie
            foreach (var ballLogic in _ballModel.GetBalls())
            {
                var ball = ballLogic.GetBall();
                var ellipse = new Ellipse
                {
                    Width = ball.Radius * 2,
                    Height = ball.Radius * 2,
                    Fill = Brushes.Red
                };

                Canvas.SetLeft(ellipse, ball.X - ball.Radius);
                Canvas.SetTop(ellipse, ball.Y - ball.Radius);
                BallCanvas.Children.Add(ellipse);
            }
        }
    }
}
