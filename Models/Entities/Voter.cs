namespace Voter_sApp;

public class Voter : AuditableEntity
{
    public string MatricNO {get; set;}
    public int UserId {get; set;}
    public User User {get; set;}
    public Vote Vote {get; set;}
}
