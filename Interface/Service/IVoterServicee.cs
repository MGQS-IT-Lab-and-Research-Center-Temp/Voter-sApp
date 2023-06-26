namespace Voter_sApp;

public interface IVoterServicee
{
    Task<BaseResponse<VoterDTO>> CreateVoter(VoterDTO voterDTO);
    Task<BaseResponse<VoterDTO>> GetVoter(int id);
    Task<BaseResponse<ICollection<VoterDTO>>> GetAllVoter();
    Task<BaseResponse<VoterDTO>> UpdateVoter (VoterDTO voterDTO);
}
