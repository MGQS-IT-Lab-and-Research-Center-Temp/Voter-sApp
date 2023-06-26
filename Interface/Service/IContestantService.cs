namespace Voter_sApp;

public interface IContestantService
{
    Task<BaseResponse<ContestantDTO>> CreateContestant(ContestantDTO contestantDTO);
    Task<BaseResponse<ContestantDTO>> GetContestant(int id);
    Task<BaseResponse<ICollection<ContestantDTO>>> GetAllContestant();
    Task<BaseResponse<ICollection<ContestantDTO>>> GetContestantsWithPosition(int positionId);
    Task<BaseResponse<ContestantDTO>> UpdateContestant (ContestantDTO contestantDTO, int id);
}
