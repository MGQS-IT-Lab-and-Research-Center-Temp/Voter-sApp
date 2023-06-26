namespace Voter_sApp;

public interface IVoteRepository
{
    Task<Vote> CreateVote (Vote vote);
    Task<ICollection<Vote>> GetAllVotesByPosition (int positionId);
    Task<ICollection<Vote>> GetAllVotesByContestant (int contestantid);
}
