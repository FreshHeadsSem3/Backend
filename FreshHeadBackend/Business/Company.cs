using System.ComponentModel.DataAnnotations;

namespace FreshHeadBackend.Business
{
    public class Company
    {
        [Key][Required] public Guid ID { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
        public virtual ICollection<CompanyImage> Images { get; set; }
        public int KVK { get; set; }
        public Company()
        {

        }
    }
}
