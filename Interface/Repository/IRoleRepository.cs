namespace Voter_sApp;

public interface IRoleRepository
{
    Task<Role> CreateRole(Role role);
    Task<Role> GetRole(int id);
    Task<Role> GetRole (string name);
    Task<ICollection<Role>> GetRolesWithUser (int userId);
    Task<ICollection<Role>> GetAllRole();
    Task<Role> UpdateRole (Role role);
}
