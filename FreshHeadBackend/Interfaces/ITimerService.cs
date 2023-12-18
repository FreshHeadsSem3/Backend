namespace FreshHeadBackend.Interfaces
{
    public interface ITimerService
    {
        Task StartAsync();
        Task StopAsync();
        void StatusUpdate(object state);
    }
}