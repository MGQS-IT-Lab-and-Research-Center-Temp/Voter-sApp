namespace Voter_sApp;

public class Role : AuditableEntity
{
    public string?  Name { get; set; }
    public ICollection<UserRoles> UserRole { get; set; } = new HashSet<UserRoles>();
}
