using FreshHeadBackend.Business;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreshHeadBackend.Models
{
    public class CompanyModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int KVK { get; set; }
        public List<string> Images { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string Link3 { get; set; }
        public string Link4 { get; set; }

        public CompanyModel(Guid id, string title, string description, int kvk, List<string> images, string link1, string link2, string link3, string link4)
        {
            ID = id;
            Title = title;
            Description = description;
            KVK = kvk;
            Images = images;
            Link1 = link1;
            Link2 = link2;
            Link3 = link3;
            Link4 = link4;
        }

        public CompanyModel(string title, string description, List<string> images, int kvk, string link1, string link2, string link3, string link4)
        {
            Title = title;
            Description = description;
            Images = images;
            KVK = kvk;
            Link1 = link1;
            Link2 = link2;
            Link3 = link3;
            Link4 = link4;
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
            Link1 = company.Link1;
            Link2 = company.Link2;
            Link3 = company.Link3;
            Link4 = company.Link4;
            Images = new List<string>();
            if (company.Images != null)
            {
                foreach (CompanyImage image in company.Images)
                {
                    Images.Add(image.ImageUrl);
                }
            }
        }

        public CompanyModel(Guid iD, string title)
        {
            ID = iD;
            Title = title;
        }
    }
}
