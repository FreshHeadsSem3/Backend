namespace FreshHeadBackend.Models
{
    public class CreateDealModel
    {
        public Guid Id = new Guid();
        public Guid companyID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public List<string> images { get; set; }
        public int maxParticipants { get; set; }
        public DateTime activeTill { get; set; }
        public Guid categoryID { get; set; }

        public CreateDealModel(Guid companyID, string title, string description, string location, List<string> images, int maxParticipants, DateTime activeTill, Guid categoryID)
        {
            this.companyID = companyID;
            this.title = title;
            this.description = description;
            this.location = location;
            this.images = images;
            this.maxParticipants = maxParticipants;
            this.activeTill = activeTill;
            this.categoryID = categoryID;
        }
    }
}
