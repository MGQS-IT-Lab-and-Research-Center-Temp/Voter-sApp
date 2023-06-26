namespace Voter_sApp;

public interface IElectoralService
{
    Task<BaseResponse<ElectoralOfficerDTO>> CreateElectoralOfficer (ElectoralOfficerDTO electoralOfficerDTO);
    Task<BaseResponse<ICollection<ElectoralOfficerDTO>>> GetAllElectoralOfficers();
}
