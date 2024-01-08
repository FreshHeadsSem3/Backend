using FreshHeadBackend.Business;
using System.ComponentModel.DataAnnotations;

namespace FreshHeadBackend.Models
{
    public class DealParticipantsModel
    {
        [Key][Required] public Guid ID { get; set; }
        public virtual Deal Deal { get; set; }
        public Guid DealID { get; set; }
        public string Email { get; set; }

        public DealParticipantsModel()
        {

        }

        public DealParticipantsModel(Guid dealID, string email)
        {
            this.DealID = dealID;
            this.Email = email;
        }

    }
}
