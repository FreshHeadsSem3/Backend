using System.ComponentModel.DataAnnotations;

namespace FreshHeadBackend.Business
{
    public class DealParticipants
    {
        [Key][Required] public Guid ID { get; set; }
        public virtual Deal Deal { get; set; }
        public Guid DealID { get; set; }
        public string Email { get; set; }

        public DealParticipants()
        {
                
        }

        public DealParticipants(Guid dealID, string email)
        {
            this.DealID = dealID;
            this.Email = email;
        }
    }
}
