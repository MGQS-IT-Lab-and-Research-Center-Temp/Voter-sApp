namespace Voter_sApp;

public class VoteRepository : IVoteRepository
{
    private readonly ApplicationContext _context;
    public VoteRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<Vote> CreateVote(Vote vote)
    {
        await _context.Votes.AddAsync(vote);
        await _context.SaveChangesAsync();
        return vote;
    }

    public async Task<ICollection<Vote>> GetAllVotesByContestant(int contestantid)
    {
        
        var allVotes = await _context.Votes.ToListAsync();
        return allVotes;
    }

    public Task<ICollection<Vote>> GetAllVotesByPosition(int positionId)
    {
        var votesByPosition = await _context.Positions.Where(c => c.PositionId == positionId).Include(c => c.ContestantId).FirstOrDefaultAsync();
        return votesByPosition;
    }
}
