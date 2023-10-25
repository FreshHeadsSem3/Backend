using System.ComponentModel.DataAnnotations;

namespace FreshHeadBackend.Business
{
    public class DealCategory
    {
        [Key] [Required] public Guid ID { get; set; }
        [Required] public string Name { get; set; }
         

        public DealCategory()
        {
            
        }
    }
}
