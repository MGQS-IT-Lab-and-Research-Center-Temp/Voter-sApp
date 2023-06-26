using Microsoft.EntityFrameworkCore;

namespace Voter_sApp;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationContext _context;
    public RoleRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Role> CreateRole(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
        return role;
    }

    public async Task<ICollection<Role>> GetAllRole()
    {
        var role = await _context.Roles.Include(r => r.UserRole).ToListAsync();
        return role;
    }

    public async Task<Role> GetRole(int id)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(u => u.Id == id);
        return role;
    }

    public async Task<Role> GetRole(string name)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(u => u.Name == name);
        return role;
    }

    public async Task<ICollection<Role>> GetRolesWithUser(int userId)
    {
        var roles = await _context.Roles.Where(x => x.Id == userId).Select(r => new Role
        {
            Name = r.Name,        
        }).ToListAsync();
        return roles;
    }

    public async Task<Role> UpdateRole(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
        return role;
    }
}
