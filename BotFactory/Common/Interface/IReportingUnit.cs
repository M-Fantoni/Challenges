using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BotFactory.Common.Interface
{
    public delegate void UnitStatusChangedHandler(object sender, IStatusChangedEventArgs e);

    public interface IReportingUnit
    {

        event UnitStatusChangedHandler UnitStatusChanged;

    }
}
