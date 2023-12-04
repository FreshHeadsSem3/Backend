using FreshHeadBackend.Models;
using FreshHeadBackend.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FreshHeadBackend.Business
{
    public class Company
    {
        [Key][Required] public Guid ID { get; set; }
        [Required] public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
        public virtual ICollection<CompanyImage> Images { get; set; }
        public int KVK { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        [AllowNull] public string Link1 { get; set; }
        [AllowNull] public string Link2 { get; set; }
        [AllowNull] public string Link3 { get; set; }
        [AllowNull] public string Link4 { get; set; }

        public Company()
        {

        }

        public Company(CreateCompanyModel model)
        {
            Title = model.Title;
            Description = model.Description;
            KVK = model.KVK;
            UserEmail = model.UserEmail;
            UserPassword = model.UserPassword;
            Link1 = model.Link1;
            Link2 = model.Link2;
            Link3 = model.Link3;
            Link4 = model.Link4;
        }
    }
}
