namespace Voter_sApp;

public interface IContestantRepository
{
    Task<Contestant> CreateContestant(Contestant contestant);
    Task<Contestant> GetContestant(int id);
    Task<Contestant> GetContestantWithMatricNo(string matricNo);
    Task<ICollection<Contestant>> GetAllContestant();
    Task<ICollection<Contestant>> GetContestantsWithPosition(int positionId);
    Task<Contestant> UpdateContestant (Contestant contestant);
}
