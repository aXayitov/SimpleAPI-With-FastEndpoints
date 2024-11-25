using Assigment.Services.DTOs.StudentDto;

namespace Assigment.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(StudentForDeleteOrGetByIdDto dto);
        Task<StudentDto> CreateStudentAsync(StudentForCreateDto studentForCreate);
        Task<StudentDto> UpdateStudentAsync(StudentForUpdateDto studentForUpdate);
        Task DeleteStudentAsync(StudentForDeleteOrGetByIdDto dto);
    }
}
