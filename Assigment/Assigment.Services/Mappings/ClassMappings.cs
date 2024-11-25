using Assigment.Domain.Models;
using Assigment.Services.DTOs.ClassDto;
using AutoMapper;

namespace Assigment.Services.Mappings;

public class ClassMappings : Profile
{
    public ClassMappings()
    {
        CreateMap<Class, ClassDto>();
        CreateMap<ClassForCreateDto, Class>();
        CreateMap<ClassForUpdateDto, Class>();
    }
}
