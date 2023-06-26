using Microsoft.EntityFrameworkCore;

namespace Voter_sApp;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<Student> Students {get; set;}    
    public DbSet<Voter> Voters {get; set;}
    public DbSet<Contestant> Contestants {get; set;}
    public DbSet<ElectoralOfficer> ElectoralOfficers {get; set;}
    public DbSet<Position> Positions {get; set;}
    public DbSet<Vote> Votes{get; set;}
}
