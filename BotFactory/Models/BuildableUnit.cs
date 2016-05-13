using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    abstract public class BuildableUnit : IBuildableUnit
    {
        public double BuildTime { get; set; }
        public string Model { get; set; }

        public BuildableUnit(double buildTime)
        {

            this.BuildTime = buildTime;
        }
    }
}
