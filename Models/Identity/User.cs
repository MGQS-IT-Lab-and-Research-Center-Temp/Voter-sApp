namespace Voter_sApp;

public class User : AuditableEntity
{
    public string?  FullName { get; set; }
    public string? Email { get; set; }
    public string? MatricNo {get; set;}
    public string? Password { get; set; }
    public ICollection<UserRoles> UserRoles { get; set; } = new HashSet<UserRoles>();
}
