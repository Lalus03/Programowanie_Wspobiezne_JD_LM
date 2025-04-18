﻿
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ModelAbstractAPI : IObservable<IBall>
    {
        public static ModelAbstractAPI CreateModelAPI()
        {
            return new Model();
        }

        public abstract void StartSimulation();
        public abstract void StopSimulation();
        public abstract IDisposable Subscribe(IObserver<IBall> observer);
        public abstract IBall[] getballs();
        public abstract event PropertyChangedEventHandler PropertyChanged;
        public abstract void getBoardParameters(int x, int y, int ballsAmount);
    }


    internal class Model : ModelAbstractAPI
    {
        private IObservable<EventPattern<BallChangeEventArgs>> eventObservable = null;
        public LogicAbstractAPI simulation { get; set; }
        public override event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<BallChangeEventArgs> BallChanged;
        public IObservable<EventHandler> ballsChanged;
        DrawBalls[] drawBalls;
        public override void getBoardParameters(int x, int y, int ballsAmount)
        {
            simulation.getBoardParameters(x, y, ballsAmount);
            drawBalls = new DrawBalls[ballsAmount]; 
            for (int i = 0; i < ballsAmount; i++)
            {
                DrawBalls ball = new DrawBalls(simulation.getCoordinates()[i][0], simulation.getCoordinates()[i][1]);
                drawBalls[i] = ball;
                simulation.PropertyChanged += OnBallChanged; //send update to upper level
            }
        }

        public override IBall[] getballs()
        {
            return drawBalls;
        }

        public Model(LogicAbstractAPI api = null)
        {
            if (api == null)
            {
                this.simulation = LogicAbstractAPI.CreateLogicAPI();
            }
            else
            {
                this.simulation = api;
            }
            eventObservable = Observable.FromEventPattern<BallChangeEventArgs>(this, "BallChanged");
        }

        public void setLogicAPI(LogicAbstractAPI api)
        {
            simulation = api;
        }

        private void OnBallChanged(object sender, PropertyChangedEventArgs args)
        {
            //reaction to update from layers below
            if (drawBalls[0].x != simulation.getCoordinates()[0][0] && drawBalls[0].y != simulation.getCoordinates()[0][1])
            {
                UpdatePosition();
            }
        }
        private void UpdatePosition()
        {
            for(int i = 0; i < simulation.getCoordinates().Length; i++)
            {
                drawBalls[i].x = simulation.getCoordinates()[i][0];
                drawBalls[i].y = simulation.getCoordinates()[i][1];
            }
        }

        public override void StartSimulation()
        {
            //button
            simulation.startSimulation();
        }

        public override void StopSimulation()
        {
            //button
            simulation.stopSimulation();
        }
        

        public override IDisposable Subscribe(IObserver<IBall> observer)
        {
            return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
        }
    }
}
