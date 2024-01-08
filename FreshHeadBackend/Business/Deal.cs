using FreshHeadBackend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace FreshHeadBackend.Business
{
    public class Deal
    {
        [Key] [Required] public Guid ID { get; set; }
        [Required] public string Title { get; set; }
        public string Description { get; set; }
        [AllowNull] public int MaxParticipants { get; set; }
        [AllowNull] public string Location { get; set; }
        [AllowNull] public DateTime ActiveTill { get; set; }
        [AllowNull] public DateTime EventDate { get; set; }
        public Guid CompanyID { get; set; }
        [Required] public virtual Company Company { get; set; }
        public virtual ICollection<DealImage> Images { get; set; }
        public virtual ICollection<DealParticipants> Participants { get; set; }
        public virtual DealCategory DealCategory { get; set; }
        public Guid CategoryID { get; set; }

        public Deal()
        {
        }

        public Deal(Guid iD, string title, string description, int maxParticipants, string location, DateTime activeTill, DateTime eventDate, Guid categoryID)
        {
            ID = iD;
            Title = title;
            Description = description;
            MaxParticipants = maxParticipants;
            Location = location;
            ActiveTill = activeTill;
            EventDate = eventDate;
            CategoryID = categoryID;
        }

        public Deal(CreateDealModel model)
        {
            this.CompanyID = model.companyID;
            this.Title = model.title;
            this.Description = model.description;
            this.Location = model.location;
            this.MaxParticipants = model.maxParticipants;
            this.ActiveTill = model.activeTill;
            this.CategoryID = model.categoryID;
        }

        public DealModel getDTO()
        {
            List<string> stringImages = new List<string>();
            foreach (DealImage image in Images)
            {
                stringImages.Add(image.ImageUrl);
            }
            return new DealModel(ID, Title, Description,stringImages, DealCategory.Name);
        }

        public int GetParticipantsCount()
        {
            if (this.Participants == null) {
                return 0;
            } else {
                return this.Participants.Count();
            }
        }
    }
}
