using FreshHeadBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace FreshHeadBackend.Business
{
    public class DealParticipants
    {
        [Key][Required] public Guid ID { get; set; }
        public virtual Deal Deal { get; set; }
        public Guid DealID { get; set; }
        public string Email { get; set; }

        public DealParticipants(DealParticipantsModel model)
        {
            this.DealID = model.ID;
            this.Deal = model.Deal;
            this.ID = model.ID;
            this.Email = model.Email;
        }

        public DealParticipants(Guid dealID, string email)
        {
            this.DealID = dealID;
            this.Email = email;
        }
    }
}
