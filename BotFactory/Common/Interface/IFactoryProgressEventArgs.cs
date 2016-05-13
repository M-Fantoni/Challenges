namespace BotFactory.Common.Interface
{
    public interface IFactoryProgressEventArgs
    {
        IFactoryQueueElement QueueElt { get; set; }
        ITestingUnit TestingUnit { get; set; }
    }
}