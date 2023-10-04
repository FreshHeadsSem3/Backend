using System.ComponentModel.DataAnnotations;

namespace FreshHeadBackend.Business
{
    public class DealImage
    {
        [Key][Required] public Guid ID { get; set; }

        public Guid DealID { get; set; }
        [Required] public string ImageUrl { get; set; }
        [Required] public virtual Deal Deal { get; set; }

        public DealImage(string imageUrl, Guid dealID)
        {
            this.ImageUrl = imageUrl;
            this.DealID = dealID;
        }
    }
}
