using AutoMapper;
using FreshHeadBackend.Models;

namespace FreshHeadBackend
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Business.Deal, Models.DealModel>();
            CreateMap<Models.DealModel, Business.Deal>();
        }
    }
}
