using FreshHeadBackend.Business;

namespace FreshHeadBackend.Models
{
    public class DealModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }

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
            Images = new List<string>();
            foreach(DealImage image in deal.Images)
            {
                Images.Add(image.ImageUrl);
            }
        }
    }
}
