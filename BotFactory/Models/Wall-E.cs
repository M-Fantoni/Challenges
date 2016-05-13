using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class Wall_E : WorkingUnit
    {
        public Wall_E() : base (4, "WALL-E", 2)
        {

        }
        public Wall_E(double buildTime = 4, string name = "Wall-E", double speed = 2) : base (buildTime, name, speed )
        {

        }
    }
}
