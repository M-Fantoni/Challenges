using BotFactory.Common.Interface;
using BotFactory.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    public class FactoryProgressEventArgs : IFactoryProgressEventArgs
    {
        public IFactoryQueueElement QueueElt { get; set; }
        public ITestingUnit TestingUnit { get; set; }

        
    }
}
