namespace FreshHeadBackend.Models
{
    public class CreateCompanyModel
    {
        public Guid Id = new Guid();
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public int KVK { get; set; }
        public CreateCompanyModel(string name, string description, List<string> images, int kvk)
        {
            Name = name;
            Description = description;
            Images = images;
            KVK = kvk;
        }

    }
}
