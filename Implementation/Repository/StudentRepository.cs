namespace Voter_sApp;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationContext _context;
    public StudentRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<Student> CreateStudent(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return student;
    }
    public async Task<Student> GetStudent(int id)
    {
        var student = await _context.Students.Include(c => c.User).FirstOrDefaultAsync(d => d.Id == id);
        return student;
    }
    public async Task<ICollection<Student>> GetAllStudent()
    {
        var students = await _context.Students.Where(c => c.IsDeleted == false).ToListAsync();
        return students;
    }
    public async Task<Student> UpdateStudent (Student student)
    {
        _context.Update(student);
        await _context.SaveChangesAsync();
        return student;
    }
}
