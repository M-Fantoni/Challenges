using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BotFactory.Common.Interface;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    
    

    public abstract class ReportingUnit : BuildableUnit, IReportingUnit
    {

        public ReportingUnit(double buildTime) : base(buildTime)
        {

        }
        public event UnitStatusChangedHandler UnitStatusChanged;

        protected virtual void OnStatusChanged(StatusChangedEventArgs args)
        {
                UnitStatusChanged?.Invoke(this,args);
        }

       
    }
}
