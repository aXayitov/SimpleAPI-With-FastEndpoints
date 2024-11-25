using Assigment.Domain.Models;
using Assigment.Services.DTOs.StudentDto;
using AutoMapper;

namespace Assigment.Services.Mappings;

public class StudentMappings : Profile
{
    public StudentMappings()
    {
        CreateMap<Student, StudentDto>()
            .ForMember(x => x.Class, r => r.MapFrom(e => e.Class.Name));
        CreateMap<StudentForCreateDto, Student>();
        CreateMap<StudentForUpdateDto, Student>();
    }
}
