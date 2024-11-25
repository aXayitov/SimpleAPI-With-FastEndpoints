using Assigment.Services.DTOs.ClassDto;

namespace Assigment.Services.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassDto>> GetAllClassesAsync();
        Task<ClassDto> GetClassByIdAsync(ClassForDeleteOrGetByIdDto dto);
        Task<ClassDto> CreateClassAsync(ClassForCreateDto classForCreate);
        Task<ClassDto> UpdateClassAsync(ClassForUpdateDto classForUpdate);
        Task DeleteClassAsync(ClassForDeleteOrGetByIdDto classForDeleteDto);
    }
}
