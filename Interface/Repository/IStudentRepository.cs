namespace Voter_sApp;

public interface IStudentRepository
{
    Task<Student> CreateStudent(Student student);
    Task<Student> GetStudent(int id);
    Task<ICollection<Student>> GetAllStudent();
    Task<Student> UpdateStudent (Student student);

}
