namespace Voter_sApp;

public interface IVoteService
{
    Task<BaseResponse<VoteDTO>> CreateVote (VoteDTO voteDTO);
    Task<BaseResponse<ICollection<VoteDTO>>> GetAllVotesByPosition (int positionId);
    Task<BaseResponse<ICollection<VoteDTO>>> GetAllVotesByContestant (int contestantid);
}
