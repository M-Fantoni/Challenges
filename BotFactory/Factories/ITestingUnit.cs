using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Interface;
using BotFactory.Common.Tools;

namespace BotFactory.Factories
{
    public interface ITestingUnit
    {
        string Name { get; set; }
        Coordinates CurrentPos { get; set; }
        bool MovementComplete { get; }
        Task<Boolean> Move(double X, double Y);
        void MoveAsync(double X, double Y);

        double BuildTime { get; set; }
        void WorkBegins();
        void WorkEnds();
        Task StopToWork(Coordinates workingPos, Coordinates parkingPos);
        Task GoToWork(Coordinates workingPos, Coordinates parkingPos);

        event UnitStatusChangedHandler UnitStatusChanged;

    }
}
