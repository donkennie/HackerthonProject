using AutoMapper;
using HackerthonProject.DTOs;
using HackerthonProject.Models;

namespace HackerthonProject.Core
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            #region Advocate Mapping
            CreateMap<Advocate, AdvocateDTO>()
                .ForMember(p => p.Profile_pic, i => i.MapFrom<PhotoUrlResolver>())
                .ReverseMap();
            #endregion

            #region Link Mapping

           CreateMap<Link, LinkDTO>().ReverseMap();
            #endregion


            #region Company Mapping

            CreateMap<Company, CompanyForAdvocateDTO>().ReverseMap();

            CreateMap<Company, CompanyDTO>()
                .ForPath(o => o.Advocates, p => p.MapFrom(i => i.Advocates))
                .ReverseMap();

            #endregion
        }

    }
}
