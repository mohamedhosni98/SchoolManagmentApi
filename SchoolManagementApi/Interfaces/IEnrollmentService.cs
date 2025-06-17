using managment_api.Models;

namespace SchoolManagementApi.Interfaces
{
    public interface IEnrollmentService
    {
        Task<bool> CreateEnrollment(Enrollment enrollment);
    }
}
