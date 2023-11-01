using FreshHeadBackend.Models;
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
        public virtual DealCategory dealCategory { get; set; }
        public Deal()
        {

        }
        public DealModel getDTO()
        {
            List<string> stringImages = new List<string>();
            foreach (DealImage image in Images)
            {
                stringImages.Add(image.ImageUrl);
            }
            return new DealModel(ID, Title, Description,stringImages, dealCategory.Name);
        }
    }
}
