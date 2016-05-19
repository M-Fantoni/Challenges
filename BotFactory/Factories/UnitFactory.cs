using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Models;
using System.Threading;
using Factories;

namespace BotFactory.Factories
{
    public delegate object StartEventHandler();
    public delegate ITestingUnit EndEventHandler();

    public class UnitFactory : IUnitFactory
    {
        //public event EventHandler<FactoryProgressEventArgs> FactoryProgress;

        public int QueueCapacity { get; set; }
        public int StorageCapacity { get; set; }
        public List<IFactoryQueueElement> Queue { get; set; }
        public List<ITestingUnit> Storage { get; set; }
        public bool IsConstructing { get; set; }
        public int QueueFreeSlots { get; set; }
        public int StorageFreeSlots { get; set; }
        public TimeSpan QueueTime { get; set; }
        public UnitFactory(int queueSize, int warehouseSize)
        {
            Queue = new List<IFactoryQueueElement>();
            Storage = new List<ITestingUnit>();
            QueueCapacity = queueSize;
            StorageCapacity = warehouseSize;
            QueueTime = TimeSpan.FromSeconds(10);
        }


        public bool AddWorkableUnitToQueue(Type modele, string name, Coordinates parkingPos, Coordinates workingPos)
        {

            if (Queue.Count < QueueCapacity)
            {
                Queue.Add(new FactoryQueueElement { Model = modele, Name = name, ParkingPos = parkingPos, WorkingPos = workingPos });
                Console.WriteLine("Added to queue");
                IFactoryQueueElement QueueElt = Queue.Last();
                AddQueueElt(QueueElt as FactoryQueueElement);
                if (!IsConstructing)
                {
                    StartConstruction();
                }
                
                return true;
            }
            else
            {
                Console.WriteLine("Queue at full capacity");
                return false;
            }
            

        }
        public bool CheckQueue()
        {
            if (Queue.Count > 0)
            {

                return true;
            }
            else
            {
                Console.WriteLine("Queue empty");
                return false;
            }
        }
        private void DeleteFromQueue(List<int> indexOfQueue)
        {
            foreach (var item in indexOfQueue)
            {
                Queue.RemoveAt(0);
            }
        }
        public Task Construct(IFactoryQueueElement queueElt )
        {
            Object obj = Activator.CreateInstance(queueElt.Model);
            var bot = obj as ITestingUnit;
            bot.Name = queueElt.Name;
            bot.ParkingPos = queueElt.ParkingPos;
            bot.WorkingPos = queueElt.WorkingPos;
            

            return Task.Factory.StartNew(() =>
            {
                if (bot == null)
                {
                    IsConstructing = false;
                    Console.WriteLine("Construction failed : impossible to read bot specification");
                }
                else
                {

                    Thread.Sleep(TimeSpan.FromSeconds(bot.BuildTime));
                    Storage.Add(bot);
                }
            });
        }
        public async void StartConstruction()
        {

            List<int> indexOfQueue = new List<int>();
            if (CheckQueue())
            {

                for (int i = 0; i < Queue.Count; i++)
                {
                    if (StorageCapacity > Storage.Count)
                    {
                        FactoryQueueElement bot = Queue.ElementAt(i) as FactoryQueueElement;
                        IsConstructing = true;
                        Console.WriteLine("starting construction");
                        await Construct(bot);
                        AddTestingUnit(bot as ITestingUnit);
                        indexOfQueue.Add(i);
                        //Console.WriteLine("construction ended : {0}",bot.Name);
                    }
                    else
                    {
                        IsConstructing = false;
                        Console.WriteLine("Storage full");
                        break;
                    }

                }
                DeleteFromQueue(indexOfQueue);
                QueueFreeSlots = QueueCapacity - Queue.Count;
                StorageFreeSlots = StorageCapacity - Storage.Count;
                IsConstructing = false;
            }
            else
            {
                IsConstructing = false;
                Console.WriteLine("Construction queue empty");
            }
        }


        #region reporting

        public event EventHandler<IFactoryProgressEventArgs> FactoryProgress;

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
            OnFactoryProgress(args);
        }

        public void OnFactoryProgress(FactoryProgressEventArgs e)
        {
            FactoryProgress?.Invoke(this, e);
        }

        #endregion

    }
}
