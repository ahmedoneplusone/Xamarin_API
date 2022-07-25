using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinWebAPI.Models;
using Profile = XamarinWebAPI.Models.Profile;

namespace XamarinWebAPI.Mapper
{
    public class ProfilesProfile : AutoMapper.Profile
    {
        public ProfilesProfile()
        {
            CreateMap<Profile, ProfileDto>()
                .ForMember(dst => dst.ProfileID, src => src.MapFrom(c => c.ProfileID))
                .ForMember(dst => dst.Name, src => src.MapFrom(c => c.Name))
                .ForMember(dst => dst.FirstHireDate, src => src.MapFrom(c => c.FirstHireDate.ToShortDateString()))
                .ForMember(dst => dst.Mobile, src => src.MapFrom(c => c.Mobile))
                .ForMember(dst => dst.Job, src => src.MapFrom(c => c.Job))
                .ForMember(dst => dst.Email, src => src.MapFrom(c => c.Email));

        }
    }
}
