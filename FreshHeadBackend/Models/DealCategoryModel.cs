namespace FreshHeadBackend.Models
{
    public class DealCategoryModel
    {
        public Guid DealCategoryID { get; set; }
        public string Name { get; set; }

        public DealCategoryModel(Guid dealCategoryID, string name)
        {
            DealCategoryID = dealCategoryID;
            Name = name;
        }
    }
}
