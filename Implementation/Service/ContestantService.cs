namespace Voter_sApp;

public class ContestantService : IContestantService
{
    private readonly IContestantRepository _contestanRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly ApplicationContext _context;
    public ContestantService(IContestantRepository contestantRepository, IUserRepository userRepository, IRoleRepository roleRepository, ApplicationContext context)
    {
        _contestanRepository = contestantRepository;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _context = context;
    }
    
    public async Task<BaseResponse<ContestantDTO>> CreateContestant(ContestantDTO contestantDTO)
    {
        var getContestant = await _contestanRepository.GetContestantWithMatricNo(contestantDTO.MatricNo);
        if (getContestant != null)
        {
            return new BaseResponse<ContestantDTO>
            {
                Message = "Sorry, you've alraedy registered as a contestant",
                Status = false
            };
        }
        var user = new User
        {
            FullName = $"{contestantDTO.FirstName} {contestantDTO.LastName}",
            Password = contestantDTO.Password,
            Email = contestantDTO.Email,
            MatricNo = contestantDTO.MatricNo
        };
        var addUser = await _userRepository.CreateUser(user);
        var role = await _roleRepository.GetRole("Ordinary User");
        if (role == null)
        {
            return new BaseResponse<ContestantDTO>
            {
                Message = "Role not found",
                Status = false
            };
        }
        var userRole = new UserRoles
        {
            UserId = addUser.Id,
            RoleId = role.Id
        };
        _context.UserRoles.Add(userRole);
        await _userRepository.UpdateUser(user);

        var contestant = new Contestant
        {
            FirstName = contestantDTO.FirstName,
            LastName = contestantDTO.LastName,
            Cgpa = contestantDTO.Cgpa,
            Level = contestantDTO.Level,
            UserId = addUser.Id,
        };
        var addContestant = await _contestanRepository.CreateContestant(contestant);

        contestant.CreatedBy = addContestant.Id;
        await _contestanRepository.UpdateContestant(contestant);

        return new BaseResponse<ContestantDTO>
        {
            Message = "You've succesfully registered for this position",
            Status = true
        };

    } 

    public async Task<BaseResponse<ICollection<ContestantDTO>>> GetAllContestant()
    {
        var contestants = await _contestanRepository.GetAllContestant();
        if (contestants is null)
        {
            return new BaseResponse<ICollection<ContestantDTO>>
            {
                Message = "No contestant registered yet",
                Status = false
            };
        }
        var contestantDTOs = contestants.Select(a => new ContestantDTO
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            MatricNo = a.User.MatricNo,
            Level = a.Level
        }).ToList();
        return new BaseResponse<ICollection<ContestantDTO>>
        {
            Data = contestantDTOs,
            Message = "list of contestants",
            Status = true
        };
    }

    public async Task<BaseResponse<ContestantDTO>> GetContestant(int id)
    {
        var contestant = await _contestanRepository.GetContestant(id);
        if (contestant is null)
        {
            return new BaseResponse<ContestantDTO>
            {
                Message = "Not found",
                Status = false
            };
        }
        var contestantDTOs = new ContestantDTO
        {
            Id = contestant.Id,
            FirstName = contestant.FirstName,
            LastName = contestant.LastName,
            MatricNo = contestant.User.MatricNo,
            Level = contestant.Level
        };
        return new BaseResponse<ContestantDTO>
        {
            Data = contestantDTOs,
            Message = "Contestant info",
            Status = true
        };
    }

    public async Task<BaseResponse<ICollection<ContestantDTO>>> GetContestantsWithPosition(int positionId)
    {
        var contestants = await _contestanRepository.GetContestantsWithPosition(positionId);
        if (contestants is null)
        {
            return new BaseResponse<ICollection<ContestantDTO>>
            {
                Message = "No contestant registered yet for this position",
                Status = false
            };
        }
        var contestantDTOs = contestants.Select(a => new ContestantDTO
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            MatricNo = a.User.MatricNo,
            Level = a.Level
        }).ToList();
        return new BaseResponse<ICollection<ContestantDTO>>
        {
            Data = contestantDTOs,
            Message = "list of contestants",
            Status = true
        };
    }

    public async Task<BaseResponse<ContestantDTO>> UpdateContestant(ContestantDTO contestantDTO, int id)
    {
        var contestant = await _contestanRepository.GetContestant(id);
        if (contestant == null)
        {
            return new BaseResponse<ContestantDTO>
            {
                Message = "contestant not  found",
                Status = false
            };
        }
        var getUser = await _userRepository.GetUser(contestantDTO.Email);
        if (getUser == null)
        {
            return new BaseResponse<ContestantDTO>
            {
                Message = "User not found",
                Status = false
            };
        }
        getUser.Email = contestantDTO.Email;
        getUser.Password = contestantDTO.Password;
        await _userRepository.UpdateUser(getUser);

        contestant.User.Email = contestantDTO.Email ?? contestant.User.Email;
        contestant.User.Password = contestantDTO.Password ?? contestant.User.Password;
        contestant.FirstName = contestantDTO.FirstName ?? contestant.FirstName;
        contestant.LastName = contestantDTO.LastName ?? contestant.LastName;
        contestant.Level = contestantDTO.Level ?? contestant.Level;
        await _contestanRepository.UpdateContestant(contestant);

        return new BaseResponse<ContestantDTO>
        {
            Message = "Contestant updated succesfully",
            Status = true
        };
    }
}
