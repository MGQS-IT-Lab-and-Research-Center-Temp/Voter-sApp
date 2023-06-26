namespace Voter_sApp;

public class ElectoralOfficer : AuditableEntity
{
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public int UserId {get; set;}
    public User User {get; set;}
}
