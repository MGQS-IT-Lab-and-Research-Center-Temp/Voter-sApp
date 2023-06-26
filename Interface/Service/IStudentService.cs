namespace Voter_sApp;

public interface IStudentService
{
    Task<BaseResponse<StudentDTO>> CreateStudent(StudentDTO studentDTO);
    Task<BaseResponse<StudentDTO>> GetStudent(int id);
    Task<BaseResponse<ICollection<StudentDTO>>> GetAllStudent();
    Task<BaseResponse<StudentDTO>> UpdateStudent (StudentDTO studentDTO);

}
