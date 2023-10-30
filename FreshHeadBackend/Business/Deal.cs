using System.ComponentModel.DataAnnotations;

namespace FreshHeadBackend.Business
{
    public class Deal
    {
        [Key] [Required] public Guid ID { get; set; }
        [Required] public string Title { get; set; }
        public string Description { get; set; }
        public Guid CompanyID { get; set; }
        [Required] public virtual Company Company { get; set; }
        public virtual ICollection<DealImage> Images { get; set; }
        public virtual DealCategory DealCategory { get; set; }
        public Deal()
        {

        }
    }
}
