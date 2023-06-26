using Microsoft.EntityFrameworkCore;

namespace Voter_sApp;

public class VoterRepository : IVoterRepository
{
    private readonly ApplicationContext _context;
    public VoterRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<Voter> CreateVoter(Voter voter)
    {
        await _context.Voters.AddAsync(voter);
        await _context.SaveChangesAsync();
        return voter;
    }

    public async Task<ICollection<Voter>> GetAllVoter()
    {
        var voters = await _context.Voters.Where(v =>v.IsDeleted == false).ToListAsync();
        return voters;
    }

    public async Task<Voter> GetVoter(int id)
    {
        var voter = await _context.Voters.Where(v => v.IsDeleted == false).Include(c => c.User).FirstOrDefaultAsync(d => d.Id == id);
        return voter;
    }

    public async Task<Voter> UpdateVoter(Voter voter)
    {
        _context.Voters.Update(voter);
        await _context.SaveChangesAsync();
        return voter;
    }
}
