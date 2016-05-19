using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class T_800 : WorkingUnit
    {
        public T_800() : base (10, "T800", 3)
        {

        }
        public T_800(double buildTime = 10, string name = "T800", double speed = 3) : base (buildTime, name, speed)
        {

        }
    }
}
