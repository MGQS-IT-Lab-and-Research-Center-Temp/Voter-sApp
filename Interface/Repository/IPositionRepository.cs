namespace Voter_sApp;

public interface IPositionRepository
{
    Task<Position> Create (Position position);
    Task<ICollection<Position>> GetAllPositions();
    Task<Position> EditPosition (Position position);
}
