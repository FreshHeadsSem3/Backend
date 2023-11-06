using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace FreshHeadBackend.Business
{
    public class Deal
    {
        [Key] [Required] public Guid ID { get; set; }
        [Required] public string Title { get; set; }
        public string Description { get; set; }
        [AllowNull] public int MaxParticipents { get; set; }
        [AllowNull] public int Claimed { get; set; }
        [AllowNull] public string Location { get; set; }
        [AllowNull] public DateTime ActiveTill { get; set; }
        public Guid CompanyID { get; set; }
        [Required] public virtual Company Company { get; set; }
        public virtual ICollection<DealImage> Images { get; set; }
        public Guid CategoryID { get; set; }
        public virtual DealCategory DealCategory { get; set; }
        public Deal()
        {

        }
    }
}
