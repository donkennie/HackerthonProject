using AutoMapper;
using HackerthonProject.DTOs;
using HackerthonProject.Models;

namespace HackerthonProject.Core
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {

            CreateMap<Advocate, AdvocateDTO>().ReverseMap();

            CreateMap<Company, CompanyDTO>().ReverseMap();
        }
    }
}
