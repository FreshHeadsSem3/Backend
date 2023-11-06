using FreshHeadBackend.Business;
using System.Diagnostics.CodeAnalysis;

namespace FreshHeadBackend.Models
{
    public class DealModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxParticipents { get; set; }
        public int Claimed { get; set; }
        public string Location { get; set; }
        public DateTime ActiveTill { get; set; }
        public List<string> Images { get; set; }
        public string DealCategory { get; set; }
        public Guid DealCategoryID { get; set; }


        public DealModel(Guid iD, string title, string description, List<string> images, string dealCategory)
        {
            ID = iD;
            Title = title;
            Description = description;
            Images = images;
            DealCategory = dealCategory;
        }
        

        public DealModel(Guid iD, string title, string description, List<string> images)
        {
            ID = iD;
            Title = title;
            Description = description;
            Images = images;
        }
        public DealModel(string title, string description, List<string> images)
        {
            Title = title;
            Description = description;
            Images = images;
        }
        public DealModel(Deal deal)
        {
            ID = deal.ID;
            Title = deal.Title;
            Description = deal.Description;
            MaxParticipents = deal.MaxParticipents;
            Claimed = deal.Claimed;
            if (deal.Location != null) Location = deal.Location;
            else Location = "";
            if (deal.ActiveTill < new DateTime(2000, 1, 1)) ;
            else ActiveTill = deal.ActiveTill;

            if (deal.DealCategory != null)
            {
                DealCategory = deal.DealCategory.Name;
            }
            else
            {
                DealCategoryID = deal.CategoryID;
                DealCategory = null; 
            }
            Images = new List<string>();
            if (deal.Images != null)
            {
                foreach (DealImage image in deal.Images)
                {
                    Images.Add(image.ImageUrl);
                }
            }
        }

    }
}
