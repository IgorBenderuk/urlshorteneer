using AutoMapper;
using DataService.Entities.DbSet;
using DataService.Entities.DTOS.ResponseDto;

namespace WebApplication1.MappingProfiles
{
    public class DomToResponse :Profile
    {
        public DomToResponse()
        {

            CreateMap<Link, LinkResponse>()
                .ForMember(l => l.ShortedUrl, opt => opt.MapFrom(src => $"https://localhost:7218/{src.ShortedUrl}"));
                

            CreateMap<User, UserResponse>()
                .ForMember(user=>user.Role,opt=>opt.MapFrom(src=>src.Role.ToString()) );

        }
    }
}
