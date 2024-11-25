using Microsoft.AspNetCore.Identity;

namespace Assigment.Domain.Models.Identity
{
    public class Role : IdentityRole<string>
    {
        public string? Description { get; set; }
    }
}
