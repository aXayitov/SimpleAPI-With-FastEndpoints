using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Services.DTOs.StudentDto
{
    public record StudentForUpdateDto(
        int Id,
        string FullName,
        DateTime BirthDate,
        int ClassId);
}
