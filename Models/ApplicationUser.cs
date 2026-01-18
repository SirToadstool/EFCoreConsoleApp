using Microsoft.AspNetCore.Identity;

namespace Fiddle.Models;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? LastLoginDate { get; set; }
    
    public string? FullName
    {
        get
        {
            string fullName = $"{FirstName} {LastName}".Trim();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return null;
            }
            return fullName;
        }
    }
}