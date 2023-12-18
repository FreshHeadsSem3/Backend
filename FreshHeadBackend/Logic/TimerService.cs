using FreshHeadBackend.Interfaces;

namespace FreshHeadBackend.Logic
{
    public class TimerService : ITimerService
    {
        private Timer timer;
        private int updateInterval;
        public Task StartAsync()
        {
            //detect weekday, set updateinterval
            updateInterval = NextWeekday(DateTime.Now);

            timer = new Timer(StatusUpdate, null, 0, updateInterval);
            Console.WriteLine("Timed hosted service started, starts in:" + updateInterval);
            return Task.CompletedTask;
        }

        public Task StopAsync()
        {
            Console.WriteLine("Timed hosted service stopped");
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void StatusUpdate(object state)
        {
            Console.WriteLine("StatusUpdate sent");
        }
        private int NextWeekday(DateTime date)
        {
            var nearestMonday = date.AddDays(6 - (date.DayOfWeek == DayOfWeek.Monday ? 0 : (int)date.DayOfWeek) + (int)DayOfWeek.Monday);
            TimeSpan timeDiff = nearestMonday - date;
            int diffInMs = ((int)timeDiff.TotalMilliseconds);
            return diffInMs;
        }
    }
}
