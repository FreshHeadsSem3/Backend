using FreshHeadBackend.Interfaces;

namespace FreshHeadBackend.Logic
{
    public class TimerService : ITimerService
    {
        private readonly IMailService mailService;
        private readonly ICompanyService companyService;
        private readonly ICompanyRepository companyRepository;

        public TimerService(IMailService mailService, ICompanyService companyService, ICompanyRepository companyRepository)
        {
            this.mailService = mailService;
            this.companyService = companyService;
            this.companyRepository = companyRepository;
        }

        private Timer timer;
        private int updateInterval;
        public Task StartAsync()
        {
            //detect weekday, set updateinterval
            updateInterval = NextMonday(DateTime.Now);

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
            this.companyRepository.GetAllCompanies().ForEach(company =>
            {
                string subject = $"EduDeals weekoverzicht {company.Title}";
                string msg = this.companyService.GetCompanyMailUpdate(company.ID);
                string mail = "482428@student.fontys.nl";
                mailService.SendEmailAsync(mail, subject, msg);
            });
        }

        private int NextMonday(DateTime date)
        {
            var nearestMonday = date.AddDays(6 - (date.DayOfWeek == DayOfWeek.Monday ? 0 : (int)date.DayOfWeek) + (int)DayOfWeek.Monday);
            TimeSpan timeDiff = nearestMonday - date;
            int diffInMs = ((int)timeDiff.TotalMilliseconds);
            return diffInMs;
        }
    }
}
