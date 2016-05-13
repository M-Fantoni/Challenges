using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class HAL : WorkingUnit
    {
        public HAL() : base (7, "HAL", 0.5)
        {
                
        }
        public HAL(double buildTime = 7, string name = "HAL", double speed = 0.5) : base (buildTime, name, speed)
        {

        }
    }
}
