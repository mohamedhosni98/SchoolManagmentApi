using managment_api.Models;

namespace SchoolManagementApi.Interfaces
{
    public interface IStudentService
    {
        Task<bool> CreateStudent(Student student);
        Task<List<Student>> GetAllStudents();
        Task<Student> UpdateStudent(int id, Student student);
        Task<bool> DeleteStudent(int id);
    }
}
