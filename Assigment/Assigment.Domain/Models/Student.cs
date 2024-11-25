using Assigment.Domain.Common;

namespace Assigment.Domain.Models;

public class Student : EntityBase
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
}
