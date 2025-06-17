using managment_api.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Repository
{
    public class MarkRepository : IMarkRepository
    {
        private readonly ApplicationDbContext _context;

        public MarkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMark(Mark mark)
        {
            var enrollmentExists = await _context.Enrollments.AnyAsync(e => e.Id == mark.EnrollmentId);
            if (!enrollmentExists)
                return false;

            await _context.Marks.AddAsync(mark);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Mark>> GetMarksByClassId(int classId)
        {
            return await _context.Marks
                .Include(m => m.Enrollment)
                .Where(m => m.Enrollment.ClassId == classId)
                .ToListAsync();
        }

        public async Task<List<Mark>> GetMarksByStudentId(int studentId)
        {
            return await _context.Marks
                .Include(m => m.Enrollment)
                .ThenInclude(e => e.Class)
                .Where(m => m.Enrollment.StudentId == studentId)
                .ToListAsync();
        }
    }
}
