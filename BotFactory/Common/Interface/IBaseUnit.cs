using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface IBaseUnit
    {
        string Name { get; set; }
        Coordinates CurrentPos { get; set; }
        bool MovementComplete { get; }
        Task<bool> Move(double x, double y);
        void MoveAsync(double X, double Y);
    }
}
