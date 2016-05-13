using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Factories;
using BotFactory.Common.Interface;
using BotFactory.Models;
using Factories;

namespace BotFactory.Factories
{
    public class ReportingFactory
    {

        public event EventHandler<FactoryProgressEventArgs> FactoryProgress;
        
        public void AddTestingUnit(ITestingUnit testingUnit)
        {
            FactoryProgressEventArgs args = new FactoryProgressEventArgs();
            args.TestingUnit = testingUnit;
            OnFactoryProgress(args);
        }

        public void AddQueueElt(FactoryQueueElement queueElement)
        {
            FactoryProgressEventArgs args = new FactoryProgressEventArgs();
            args.QueueElt = queueElement;
        }

        public void OnFactoryProgress(FactoryProgressEventArgs e)
        {
            EventHandler<FactoryProgressEventArgs> handler = FactoryProgress;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
    }
}
