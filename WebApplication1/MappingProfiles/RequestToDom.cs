using AutoMapper;
using DataService.Entities.DbSet;
using DataService.Entities.DTOS.RequestDto;

namespace WebApplication1.MappingProfiles
{
    public class RequestToDom : Profile
    {
        public RequestToDom()
        {
            Random rnd = new Random();

            CreateMap<CreateUserRequest, User>()
                .ForMember(user => user.CreationDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(user => user.UpdationDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpDateUserRequest, User>()
               .ForMember(user => user.UpdationDate, opt => opt.MapFrom(src => DateTime.UtcNow))
               .ForMember(user=>user.Role,opt=>opt.MapFrom( src=>src.Role =="Admin"?Role.Admin:Role.User)) ;

            CreateMap<CreateLinkrRequest, Link>()
                .ForMember(link => link.LongUrl, opt => opt.MapFrom(src => src.LongUrl))
                .ForMember(link => link.Id, opt => opt.MapFrom(src => new Guid()))
                .ForMember(link=>link.ShortedUrl,opt=>opt.MapFrom(src=>rnd.Next(111111,999999)))
                .ForMember(link => link.CreationDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(link => link.UpdationDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpDateLinkRequest, Link>()
                .ForMember(link => link.CreationDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(link => link.UpdationDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
