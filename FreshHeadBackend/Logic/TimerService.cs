using FreshHeadBackend.Interfaces;

namespace FreshHeadBackend.Logic
{
    public class TimerService : ITimerService
    {
        private Timer timer;
        private int updateInterval = 1000;
        public Task StartAsync()
        {
            Console.WriteLine("Timed hosted service started");
            //detect weekday, set updateinterval


            timer = new Timer(StatusUpdate, null, 0, updateInterval);

            return Task.CompletedTask;
        }

        public Task StopAsync(){
            Console.WriteLine("Timed hosted service stopped");
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void StatusUpdate(object state)
        {
            Console.WriteLine("StatusUpdate sent");
        }
    }
}
