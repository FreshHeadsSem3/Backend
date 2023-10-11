using FreshHeadBackend.Business;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreshHeadBackend.Models
{
    public class CompanyModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public int KVK { get; set; }

        public CompanyModel(Guid id, string name, string description, List<string> images, int kvk)
        {
            ID = id;
            Name = name;
            Description = description;
            Images = images;
            KVK = kvk;
        }

        public CompanyModel(string name, string description, List<string> images, int kvk)
        {
            Name = name;
            Description = description;
            Images = images;
            KVK = kvk;
        }

        public CompanyModel(Company company)
        {
            ID = company.ID;
            Name = company.Name;
            Description = company.Description;
            KVK = company.KVK;
            Images = new List<string>();
            if (company.Images != null)
            {
                foreach (CompanyImage image in company.Images)
                {
                    Images.Add(image.ImageUrl);
                }
            }
        }
    }
}
