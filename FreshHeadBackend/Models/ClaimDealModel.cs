namespace FreshHeadBackend.Models
{
    public class ClaimDealModel
    {
        public Guid DealID { get; set; }
        public string MailUser { get; set; }
        public string MailMSG { get; set; }

        public ClaimDealModel(Guid dealID, string mailUser, string mailMSG)
        {
            DealID = dealID;
            MailUser = mailUser;
            MailMSG = mailMSG;
        }
    }
}
