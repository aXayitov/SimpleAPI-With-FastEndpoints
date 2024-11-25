using Assigment.Domain.Exceptions;
using Assigment.Domain.Models;
using Assigment.Infrastructure.Persistance;
using Assigment.Services.DTOs.StudentDto;
using Assigment.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assigment.Services;

public class StudentService(AssigmentDbContext context, IMapper mapper) : IStudentService
{
    private readonly AssigmentDbContext _context = context 
        ?? throw new ArgumentNullException(nameof(context));

    private readonly IMapper _mapper = mapper
        ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<List<StudentDto>> GetAllStudentsAsync()
    {
        var students = await _context.Students.Include(x => x.Class).ToListAsync();

        return _mapper.Map<List<StudentDto>>(students);
    }

    public async Task<StudentDto> GetStudentByIdAsync(StudentForDeleteOrGetByIdDto dto)
    {
        var entity = await _context.Students.Include(x => x.Class).FirstOrDefaultAsync(x => x.Id == dto.Id);

        if(entity == null)
        {
            throw new EntityNotFoundException($"Student with {dto.Id} does not exist");
        }

        return _mapper.Map<StudentDto>(entity);
    }

    public async Task<StudentDto> CreateStudentAsync(StudentForCreateDto studentForCreate)
    {
        var entity = _mapper.Map<Student>(studentForCreate);

        var createdStudent = await _context.Students.AddAsync(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<StudentDto>(createdStudent.Entity);
    }

    public async Task<StudentDto> UpdateStudentAsync(StudentForUpdateDto studentForUpdate)
    {
        if(!_context.Students.Any(x => x.Id == studentForUpdate.Id))
        {
            throw new EntityNotFoundException($"Student with id: {studentForUpdate.Id} does not exist.");
        }

        var entity = _mapper.Map<Student>(studentForUpdate);

        _context.Students.Update(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<StudentDto>(entity);
    }

    public async Task DeleteStudentAsync(StudentForDeleteOrGetByIdDto dto)
    {
        var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == dto.Id);

        if(entity == null)
        {
            throw new EntityNotFoundException($"Student with id: {dto.Id} does not exist");
        }

        _context.Students.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
