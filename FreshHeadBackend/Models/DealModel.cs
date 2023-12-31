﻿using FreshHeadBackend.Business;
using System.Diagnostics.CodeAnalysis;

namespace FreshHeadBackend.Models
{
    public class DealModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxParticipants { get; set; }
        public int Claimed { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime ActiveTill { get; set; }
        public List<string> Images { get; set; }
        public string DealCategory { get; set; }
        public Guid DealCategoryID { get; set; }

        public DealModel()
        {

        }

        public DealModel(Guid id, string title, string description, int maxParticipants, int claimed, string location, DateTime eventDate, DateTime activeTill, List<string> images, string dealCategory, Guid dealCategoryID)
        {
            ID = id;
            Title = title;
            Description = description;
            MaxParticipants = maxParticipants;
            Claimed = claimed;
            Location = location;
            EventDate = eventDate;
            ActiveTill = activeTill;
            Images = images;
            DealCategory = dealCategory;
            DealCategoryID = dealCategoryID;
        }

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
            MaxParticipants = deal.MaxParticipants;
            Claimed = deal.GetParticipantsCount();
            if (deal.Location != null) Location = deal.Location;
            else Location = "";
            if (deal.ActiveTill < new DateTime(2000, 1, 1)); //Geeft geen eindatum mee als de datum voor 2000 is.
            else ActiveTill = deal.ActiveTill;
            if (deal.EventDate < new DateTime(2000, 1, 1)) ; //Geeft geen eindatum mee als de datum voor 2000 is.
            else EventDate = deal.EventDate;

            if (deal.DealCategory != null) {
                DealCategory = deal.DealCategory.Name;
            } else {
                DealCategoryID = deal.CategoryID;
                DealCategory = null; 
            }
            Images = new List<string>();
            if (deal.Images != null) {
                foreach (DealImage image in deal.Images) {
                    Images.Add(image.ImageUrl);
                }
            }
        }

    }
}
