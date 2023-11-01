namespace FreshHeadBackend.Models
{
    public class CreateDealModel
    {
        public Guid Id = new Guid();
        public Guid companyID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> images { get; set; }
        public Guid categoryID { get; set; }

        public CreateDealModel(Guid companyID, string title, string description, Guid categoryID, List<string> images)
        {
            this.companyID = companyID;
            this.title = title;
            this.description = description;
            this.categoryID = categoryID;
            this.images = images;
        }
    }
}
