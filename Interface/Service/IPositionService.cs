namespace Voter_sApp;

public interface IPositionService
{
    Task<BaseResponse<PositionDTO>> CreatePosition (PositionDTO positionDTO);
    Task<BaseResponse<ICollection<PositionDTO>>> GetAllPositions();
    Task <BaseResponse<PositionDTO>> EditPosition (PositionDTO positionDTO);
}
