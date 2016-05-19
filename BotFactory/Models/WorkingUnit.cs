
using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    public abstract class WorkingUnit : BaseUnit, IWorkingUnit, ITestingUnit 
    {
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }
        public bool IsWorking { get; set; }
        public WorkingUnit(double buildTime, string name, double speed) : base(buildTime, name, speed)
        {

        }

        //public async virtual void WorkBegins()
        //{
        //    //this.WorkStarted = false;

        //    Console.WriteLine("Going to work position");
        //    await GoToWork(WorkingPos, ParkingPos);

        //    IsWorking = true;
        //    Console.WriteLine("Starting to work");
        //}

        //public async virtual void WorkEnds()
        //{

        //    Console.WriteLine("Ending Work");
        //    await StopToWork(WorkingPos, ParkingPos);

        //    IsWorking = false;
        //    Console.WriteLine("Recharging");
        //}
        public Task<bool> WorkBegins()
        {
            StatusChangedEventArgs args = new StatusChangedEventArgs();
            args.NewStatus = "Going to work";
            OnStatusChanged(args);

            return Task.Factory.StartNew(() =>
            {
                
                CurrentPos.X = ParkingPos.X;
                CurrentPos.Y = ParkingPos.Y;
                Move(WorkingPos.X, WorkingPos.Y);
                return true;
            });

        }
        public Task<bool> WorkEnds()
        {
            return Task.Factory.StartNew(() =>
            {
                CurrentPos.X = WorkingPos.X;
                CurrentPos.Y = WorkingPos.Y;
                Move(ParkingPos.X, ParkingPos.Y);
                return true;
            });
        }

    }
}
