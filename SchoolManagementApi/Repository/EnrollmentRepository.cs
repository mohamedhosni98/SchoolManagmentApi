using managment_api.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEnrollment(Enrollment enrollment)
        {
            // Check if Student and Class exist
            var studentExists = await _context.Students.AnyAsync(s => s.Id == enrollment.StudentId);
            var classExists = await _context.Classes.AnyAsync(c => c.Id == enrollment.ClassId);

            if (!studentExists || !classExists)
                return false;

            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
