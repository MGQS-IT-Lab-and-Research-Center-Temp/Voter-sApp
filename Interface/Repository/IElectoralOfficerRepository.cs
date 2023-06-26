namespace Voter_sApp;

public interface IElectoralOfficerRepository
{
    Task<ElectoralOfficer> Create (ElectoralOfficer electoralOfficer);
    Task<ICollection<ElectoralOfficer>> GetAllElectoralOfficers();
    Task<ElectoralOfficer> Update (ElectoralOfficer electoralOfficer);
    Task<ElectoralOfficer> GetEFWithUserId (int UserId);
}
