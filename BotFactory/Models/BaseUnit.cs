using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Common.Interface;
using System.Threading;

namespace BotFactory.Models
{
    public abstract class BaseUnit : ReportingUnit, IBaseUnit
    {
        public string Name { get; set; }
        public Coordinates CurrentPos { get; set; }
        public double Speed { get; set; }
        public bool MovementComplete { get; private set; }

        public BaseUnit(double buildTime, string name, double speed = 1) : base(buildTime)
        {
            Name = name;
            Speed = speed;

        }

        //public Task Move(double X, double Y)
        //{
        //    Vector Vector = new Vector();
        //    Coordinates TargetPos = new Coordinates();

        //    double distance = 0;
        //    int timeToMove = 0;
        //    return Task.Factory.StartNew(() =>
        //    {
        //        if (CurrentPos == null)
        //        {
        //            CurrentPos = new Coordinates();
        //            CurrentPos.Y = 0;
        //            CurrentPos.X = 0;
        //        }

        //        TargetPos.X = X;
        //        TargetPos.Y = Y;

        //        Vector = Vector.FromCoordinates(CurrentPos, TargetPos);
        //        distance = Vector.Length(CurrentPos, TargetPos);

        //        //TimeSpan
        //        timeToMove = Convert.ToInt32(distance * 1000);

        //        CurrentPos.X = X;
        //        CurrentPos.Y = Y;

        //        Console.WriteLine("Start to move");
        //        Thread.Sleep(timeToMove);
                
        //    }); 
            


        //}

        public Task<bool> Move(double x, double y)
        {
            double timeToMove;
            double distance;
            distance = Vector.Length(CurrentPos, new Coordinates(x,y));

            return Task.Factory.StartNew(() =>
            {
                timeToMove = distance / Speed;

                Console.WriteLine("Start to move");
                Thread.Sleep(TimeSpan.FromSeconds((int)timeToMove));

                CurrentPos.X = x;
                CurrentPos.Y = y;

                Console.WriteLine("Stopped movement");
                return true;
            });
            
        }

        async public void MoveAsync(double X, double Y)
        {
            MovementComplete = false;
            Console.WriteLine("Begin movement");
            await Move(X, Y);
            Console.WriteLine("movement ended");
            MovementComplete = true;

        }
        protected override void OnStatusChanged(StatusChangedEventArgs args)
        {
            base.OnStatusChanged(args);
        }

    }
}
