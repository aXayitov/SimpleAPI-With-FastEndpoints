using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Services.DTOs.StudentDto
{
    public class StudentDto
    {
        public int Id { get; init; }
        public string FullName { get; init; }
        public DateTime BirthDate { get; init; }
        public int ClassId { get; init; }
        public string Class { get; init; }
    }
}
