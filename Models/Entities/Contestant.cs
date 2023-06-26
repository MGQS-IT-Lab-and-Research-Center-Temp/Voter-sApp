namespace Voter_sApp;

public class Contestant : AuditableEntity
{
    public string?  FirstName {get; set;}
    public string? LastName {get; set;}
    public int PositionId {get; set;}
    public Position Position {get; set;}
    public float Cgpa {get; set;}
    public string? Level {get; set;}
    public int UserId {get; set;}
    public User User {get; set;}
    public ICollection<Vote> Votes {get; set;}
}
