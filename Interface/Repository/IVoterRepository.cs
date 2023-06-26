namespace Voter_sApp;

public interface IVoterRepository
{
    Task<Voter> CreateVoter(Voter voter);
    Task<Voter> GetVoter(int id);
    Task<ICollection<Voter>> GetAllVoter();
    Task<Voter> UpdateVoter (Voter voter);
}
