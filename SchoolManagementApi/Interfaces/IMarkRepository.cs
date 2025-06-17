using managment_api.Models;

namespace SchoolManagementApi.Interfaces
{
    public interface IMarkRepository
    {
        Task<bool> CreateMark(Mark mark);
        Task<List<Mark>> GetMarksByClassId(int classId);
        Task<List<Mark>> GetMarksByStudentId(int studentId);
    }
}
