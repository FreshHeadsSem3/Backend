namespace FreshHeadBackend.Models
{
    public class CreateCompanyModel
    {
        public Guid Id = new Guid();
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public int KVK { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string Link3 { get; set; }
        public string Link4 { get; set; }

        public CreateCompanyModel(string title, string description, List<string> images, int kvk, string link1, string link2, string link3, string link4)
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

    }
}
