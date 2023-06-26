using Microsoft.EntityFrameworkCore;

namespace Voter_sApp;

public class PositionRepository : IPositionRepository
{
    private readonly ApplicationContext _context;
    public PositionRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<Position> Create (Position position)
    {
        await _context.Positions.AddAsync(position);
        await _context.SaveChangesAsync();
        return position;
    }
    public async Task<ICollection<Position>> GetAllPositions()
    {
        var positions = await _context.Positions.Where(p => p.IsDeleted == false).ToListAsync();
        return positions;
    }
    public async Task<Position> EditPosition (Position position)
    {
        _context.Positions.Update(position);
        await _context.SaveChangesAsync();
        return position;
    }
    
}
