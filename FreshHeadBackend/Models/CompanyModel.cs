using FreshHeadBackend.Business;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreshHeadBackend.Models
{
    public class CompanyModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public int KVK { get; set; }

        public CompanyModel(Guid id, string title, string description, List<string> images, int kvk)
        {
            ID = id;
            Title = title;
            Description = description;
            Images = images;
            KVK = kvk;
        }

        public CompanyModel(string title, string description, List<string> images, int kvk)
        {
            Title = title;
            Description = description;
            Images = images;
            KVK = kvk;
        }

        public CompanyModel(Guid iD, string title)
        {
            ID = iD;
            Title = title;
        }

        public CompanyModel(Company company)
        {
            ID = company.ID;
            Title = company.Title;
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
