using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{

    public interface IUnitFactory 
    {


        int QueueCapacity { get; set; }
        int StorageCapacity { get; set; }
        List<IFactoryQueueElement> Queue { get; set; }
        List<ITestingUnit> Storage { get; set; }
        bool IsConstructing { get; set; }
        int QueueFreeSlots { get; set; }
        int StorageFreeSlots { get; set; }
        TimeSpan QueueTime { get; set; }

        bool AddWorkableUnitToQueue(Type modele, string name, Coordinates parkingPos, Coordinates workingPos);

        bool CheckQueue();

        //void DeleteFromQueue(List<int> indexOfQueue);

        Task Construct(IFactoryQueueElement queueElt);

        void StartConstruction();

        event EventHandler<IFactoryProgressEventArgs> FactoryProgress;


    }
}
