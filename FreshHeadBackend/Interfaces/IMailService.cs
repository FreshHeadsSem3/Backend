namespace FreshHeadBackend.Interfaces
{
    public interface IMailService
    {
        bool SendEmailAsync(string mail, string subject, string mailMSG);
    }
}
