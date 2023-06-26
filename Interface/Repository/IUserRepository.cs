namespace Voter_sApp;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
    Task<User> GetUser(int id);
    Task<User> GetUser(string matricNo);
    Task<User> UpdateUser (User user);
}
