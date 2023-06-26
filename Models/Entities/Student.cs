namespace Voter_sApp;

public class Student : AuditableEntity
{
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public string? PhoneNumber {get; set;}
    public float Cgpa {get; set;}
    public int Age {get; set;}
    public string? Level {get; set;}
    public int UserId {get; set;}
    public User User {get; set;}
}
