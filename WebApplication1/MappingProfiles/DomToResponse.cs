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
                .ForMember(link => link.CreatedBy, opt => opt.MapFrom(src => $"{src.User.FirstName}{src.User.LastName}"));

            CreateMap<User, UserResponse>()
                .ForMember(user=>user.Role,opt=>opt.MapFrom(src=>src.Role.ToString()) );

        }
    }
}
