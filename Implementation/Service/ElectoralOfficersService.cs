namespace Voter_sApp;

public class ElectoralOfficersService : IElectoralService
{
    private readonly IContestantRepository _contestanRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IElectoralOfficerRepository _electoralOfficerRepository;
    private readonly ApplicationContext _context;
    public ElectoralOfficersService(IContestantRepository contestantRepository, IUserRepository userRepository, IRoleRepository roleRepository, IElectoralOfficerRepository electoralOfficerRepository, ApplicationContext context)
    {
        _contestanRepository = contestantRepository;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _electoralOfficerRepository = electoralOfficerRepository;
        _context = context;
    }
    public async Task<BaseResponse<ElectoralOfficerDTO>> CreateElectoralOfficer(ElectoralOfficerDTO electoralOfficerDTO)
    {
        var getElectoralOfficer = await _electoralOfficerRepository.GetEFWithUserId(electoralOfficerDTO.id);
        if (getElectoralOfficer != null)
        {
            return new BaseResponse<ElectoralOfficerDTO>
            {
                Message = "Sorry, you've alraedy registered as a contestant",
                Status = false
            };
        }
        var user = new User
        {
            FullName = $"{electoralOfficerDTO.FirstName} {electoralOfficerDTO.LastName}",
        };
        var addUser = await _userRepository.CreateUser(user);
        var addRole = await _roleRepository.GetRole("Admin");
        if (addRole == null)
        {
            return new BaseResponse<ElectoralOfficerDTO>
            {
                Message = "Role not found",
                Status = false
            };
        }
        var userRole = new UserRoles
        {
            UserId = addUser.Id,
            RoleId = addRole.Id
        };
        _context.UserRoles.Add(userRole);
        await _userRepository.UpdateUser(user);


        var electoralOfficer = new ElectoralOfficer
        {
            FirstName = electoralOfficerDTO.FirstName,
            LastName = electoralOfficerDTO.LastName,
            UserId = addUser.Id,
        };
        var adddElectoralOfficer = await _electoralOfficerRepository.Create(electoralOfficer);

        electoralOfficer.CreatedBy = electoralOfficer.Id;
        await _electoralOfficerRepository.Update(electoralOfficer);

        return new BaseResponse<ElectoralOfficerDTO>
        {
            Message = "You've succesfully registered for this position",
            Status = true
        };
    }

    public async Task<BaseResponse<ICollection<ElectoralOfficerDTO>>> GetAllElectoralOfficersAsync()
    {
        var electoralOfficers = await _electoralOfficerRepository.GetAllElectoralOfficers();
        if (electoralOfficers is null)
        {
            return new BaseResponse<ICollection<ElectoralOfficerDTO>>
            {
                Message = "No electoral official registered yet",
                Status = false
            };
        }
        var electoralOfficersDTO = electoralOfficers.Select(a => new ElectoralOfficerDTO
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
        }).ToList();
        return new BaseResponse<ICollection<ElectoralOfficerDTO>>
        {
            Data = electoralOfficersDTO,
            Message = "list of contestants",
            Status = true
        };
    }
}
