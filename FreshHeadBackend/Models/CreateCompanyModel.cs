namespace FreshHeadBackend.Models
{
    public class CreateCompanyModel
    {
        public Guid Id = new Guid();
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public int KVK { get; set; }
        public CreateCompanyModel(string title, string description, List<string> images, int kvk)
        {
            Title = title;
            Description = description;
            Images = images;
            KVK = kvk;
        }

    }
}
