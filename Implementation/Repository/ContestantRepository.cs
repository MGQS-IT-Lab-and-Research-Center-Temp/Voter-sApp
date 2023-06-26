using Microsoft.EntityFrameworkCore;

namespace Voter_sApp;

public class ContestantRepository : IContestantRepository
{
    private readonly ApplicationContext _context;
    public ContestantRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<Contestant> CreateContestant(Contestant contestant)
    {
        await _context.Contestants.AddAsync(contestant);
        await _context.SaveChangesAsync();
        return contestant;
    }

    public async Task<ICollection<Contestant>> GetAllContestant()
    {
        var contestants = await _context.Contestants.Where(c => c.IsDeleted == false).ToListAsync();
        return contestants;
    }

    public async Task<Contestant> GetContestant(int id)
    {
        var contestant = await _context.Contestants.Include(c => c.User).FirstOrDefaultAsync(d => d.Id == id);
        return contestant;
    }

    public async Task<ICollection<Contestant>> GetContestantsWithPosition(int positionId)
    {
        var contestants = await _context.Contestants.Include(c => c.Position).Where(c => c.PositionId == positionId).ToListAsync();
        return contestants;
    }

    public async Task<Contestant> GetContestantWithMatricNo(string matricNo)
    {
        var contestant = await _context.Contestants.Include(c => c.User).FirstOrDefaultAsync(d => d.User.MatricNo == matricNo);
        return contestant;
    }

    public async Task<Contestant> UpdateContestant(Contestant contestant)
    {
        _context.Update(contestant);
        await _context.SaveChangesAsync();
        return contestant;
    }
}
