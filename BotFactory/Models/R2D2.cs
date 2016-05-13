using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class R2D2 : WorkingUnit
    {
        public R2D2() : base(5.5, "R2D2", 1.5)
        {

        }
        public R2D2(double buildTime = 5.5, string name = "R2D2", double speed = 1.5) : base (buildTime, name, speed)
        {

        }
    }
}
