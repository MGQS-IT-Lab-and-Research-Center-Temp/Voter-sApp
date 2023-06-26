namespace Voter_sApp;

public class Vote
{
    public int Count {get; set;}
    public int ContestantId {get; set;}
    public Contestant Contestant {get; set;}
    public int PositionId {get; set;}
    public Position position {get; set;}
    public int VoterId {get; set;}
    public Voter Voter {get; set;}
}
