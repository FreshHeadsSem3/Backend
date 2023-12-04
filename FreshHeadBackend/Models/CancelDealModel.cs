namespace FreshHeadBackend.Models
{
    public class CancelDealModel
    {
        public Guid DealID { get; set; }
        public string MailUser { get; set; }

        public CancelDealModel(Guid dealID, string mailUser)
        {
            DealID = dealID;
            MailUser = mailUser;
        }
    }
}
