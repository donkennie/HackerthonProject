using AutoMapper;
using HackerthonProject.DTOs;
using HackerthonProject.Models;

namespace HackerthonProject.Core
{
    public class PhotoUrlResolver : IValueResolver<Advocate, AdvocateDTO, string>
    {
        private readonly IConfiguration _config;

        public PhotoUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Advocate source, AdvocateDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Profile_pic))
            {
                return _config["ApiUrl"] + source.Profile_pic;
            }

            return null;
        }
    }
}
