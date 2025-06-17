using managment_api.Models;

namespace SchoolManagementApi.Interfaces
{
    public interface IMarkService
    {
        Task<bool> CreateMark(int studentId, int classId, decimal examMark, decimal assignmentMark);
        Task<decimal?> GetAverageMarksByClassId(int classId);
        Task<StudentReportResponse?> GetStudentReport(int studentId);
    }
}
