namespace FreshHeadBackend.Business
{
    public class Company
    {
        private int ID { get; }
        private string Name { get; }
        private string Description { get; }
        private List<string> Images { get; }
        private List<Deal> Deals { get; }
        public Company()
        {

        }
    }
}
