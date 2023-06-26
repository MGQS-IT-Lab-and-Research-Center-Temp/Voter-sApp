using Microsoft.EntityFrameworkCore;

namespace Voter_sApp;

public class ElectoralOfficersRepository : IElectoralOfficerRepository
{
    private readonly ApplicationContext _context;
    public ElectoralOfficersRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<ElectoralOfficer> Create(ElectoralOfficer electoralOfficer)
    {
        await _context.ElectoralOfficers.AddAsync(electoralOfficer);
        await _context.SaveChangesAsync();
        return electoralOfficer;
    }

    public async Task<ICollection<ElectoralOfficer>> GetAllElectoralOfficers()
    {
        var electoralOfficers = await _context.ElectoralOfficers.Where(e => e.IsDeleted == false).ToListAsync();
        return electoralOfficers;
    }
}
