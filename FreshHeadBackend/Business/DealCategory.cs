using System.ComponentModel.DataAnnotations;

namespace FreshHeadBackend.Business
{
    public class DealCategory
    {
        [Key] [Required] public Guid ID { get; set; }
        [Required] public string Name { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
         

        public DealCategory()
        {
            
        }
    }
}
