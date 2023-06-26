namespace Voter_sApp;

public interface IRoleService
{
    Task<BaseResponse<RoleDTO>> CreateRole(RoleDTO roleDTO);
    Task<BaseResponse<RoleDTO>> GetRole(int id);
    Task<BaseResponse<ICollection<RoleDTO>>> GetAllRole();
    Task<BaseResponse<ICollection<RoleDTO>>> GetRoleWithUser(int userId);
    Task<BaseResponse<RoleDTO>> UpdateRole (RoleDTO roleDTO);
}