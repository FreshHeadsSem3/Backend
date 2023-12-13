namespace FreshHeadBackend.Interfaces
{
    public interface ITimerService
    {
        Task StartAsync();
        void StatusUpdate(object state);
    }
}