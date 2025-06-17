using managment_api.Models;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<bool> CreateEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
                return false;

            // Validations
            if (enrollment.StudentId <= 0 || enrollment.ClassId <= 0)
                return false;



            return await _enrollmentRepository.CreateEnrollment(enrollment);
        }
    }
}
