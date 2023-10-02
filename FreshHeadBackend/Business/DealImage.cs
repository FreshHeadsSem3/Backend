using System.ComponentModel.DataAnnotations;

namespace FreshHeadBackend.Business
{
    public class DealImage
    {
        [Key][Required] public Guid ID { get; set; }

        [Required] public string ImageUrl { get; set; }
        public Deal Deal { get; set; }

        public DealImage(string imageUrl)
        {
            this.ImageUrl = imageUrl;
        }
    }
}
