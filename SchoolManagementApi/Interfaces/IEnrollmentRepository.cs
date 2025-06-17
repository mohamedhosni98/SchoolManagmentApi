using managment_api.Models;

namespace SchoolManagementApi.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<bool> CreateEnrollment(Enrollment enrollment);
    }
}
