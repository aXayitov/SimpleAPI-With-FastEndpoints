using Assigment.Domain.Models.Identity;
using Assigment.Services.DTOs.UserDto;
using AutoMapper;

namespace Assigment.Services.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<RegisterRequestUserDto, User>()
                .ForMember(x => x.Id, x => x.MapFrom(_ => Guid.NewGuid()))
                .ForMember(x => x.UserName, x => x.MapFrom(e => e.Email));
        }
    }
}
