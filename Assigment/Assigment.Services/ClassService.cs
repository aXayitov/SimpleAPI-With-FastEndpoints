using Assigment.Domain.Exceptions;
using Assigment.Domain.Models;
using Assigment.Infrastructure.Persistance;
using Assigment.Services.DTOs.ClassDto;
using Assigment.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assigment.Services;

public class ClassService(AssigmentDbContext context, IMapper mapper) : IClassService
{
    private readonly AssigmentDbContext _context = context
        ?? throw new ArgumentNullException(nameof(context));

    private readonly IMapper _mapper = mapper
        ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<List<ClassDto>> GetAllClassesAsync()
    {
        var query = _context.Classes.AsQueryable();

        var result = await query.ToListAsync();

        return _mapper.Map<List<ClassDto>>(result);
    }

    public async Task<ClassDto> GetClassByIdAsync(ClassForDeleteOrGetByIdDto dto)
    {
        var entity = await _context.Classes.FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (entity == null)
        {
            throw new EntityNotFoundException($"Class with {dto.Id} does not exist");
        }

        return _mapper.Map<ClassDto>(entity);
    }

    public async Task<ClassDto> CreateClassAsync(ClassForCreateDto classForCreate)
    {
        var entity = _mapper.Map<Class>(classForCreate);

        var createdClass = await _context.Classes.AddAsync(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<ClassDto>(createdClass.Entity);
    }

    public async Task<ClassDto> UpdateClassAsync(ClassForUpdateDto classForUpdate)
    {
        if (!_context.Classes.Any(x => x.Id == classForUpdate.Id))
        {
            throw new EntityNotFoundException($"Class with id: {classForUpdate.Id} does not exist.");
        }

        var entity = _mapper.Map<Class>(classForUpdate);

        _context.Classes.Update(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<ClassDto>(entity);
    }

    public async Task DeleteClassAsync(ClassForDeleteOrGetByIdDto classForDeleteDto)
    {
        var entity = await _context.Classes.FirstOrDefaultAsync(x => x.Id == classForDeleteDto.Id);

        if (entity == null)
        {
            throw new EntityNotFoundException($"Class with id: {classForDeleteDto.Id} does not exist");
        }

        _context.Classes.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
