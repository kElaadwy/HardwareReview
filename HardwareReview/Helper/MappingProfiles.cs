using AutoMapper;
using HardwareReview.Dto;
using HardwareReview.Models;

namespace HardwareReview.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Hardware, HardwareDto>();
        }
    }
}
