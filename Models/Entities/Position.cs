namespace Voter_sApp;

public class Position : AuditableEntity
{
    public string? Name {get; set;}
    public ICollection<Contestant> Contestants { get; set; } = new HashSet<Contestant>();
    public ICollection<Vote> Votes {get; set;}

}
