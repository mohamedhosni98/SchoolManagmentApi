using managment_api.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Services
{
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _markRepository;
        private readonly ApplicationDbContext _context;

        public MarkService(IMarkRepository markRepository, ApplicationDbContext context)
        {
            _markRepository = markRepository;
            _context = context;
        }

        public async Task<bool> CreateMark(int studentId, int classId, decimal examMark, decimal assignmentMark)
        {
            if (studentId <= 0 || classId <= 0)
                return false;

            if (examMark < 0 || examMark > 100 || assignmentMark < 0 || assignmentMark > 100)
                return false;

            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.ClassId == classId);

            if (enrollment == null)
                return false;

            var mark = new Mark
            {
                EnrollmentId = enrollment.Id,
                ExamMark = examMark,
                AssignmentMark = assignmentMark,
                CreatedAt = DateTime.UtcNow
            };

            return await _markRepository.CreateMark(mark);
        }

        public async Task<decimal?> GetAverageMarksByClassId(int classId)
        {
            if (classId <= 0)
                return null;

            var marks = await _markRepository.GetMarksByClassId(classId);
            if (!marks.Any())
                return null;

            var totalMarks = marks.Select(m => m.ExamMark + m.AssignmentMark).Average();
            return (decimal)totalMarks;
        }

        public async Task<StudentReportResponse?> GetStudentReport(int studentId)
        {
            if (studentId <= 0)
                return null;

            var marks = await _markRepository.GetMarksByStudentId(studentId);
            if (!marks.Any())
                return null;

            var report = new StudentReportResponse
            {
                Classes = marks.Select(m => new ClassReport
                {
                    ClassId = m.Enrollment.ClassId,
                    ClassName = m.Enrollment.Class.Name,
                    ExamMark = m.ExamMark,
                    AssignmentMark = m.AssignmentMark,
                    TotalMark = m.ExamMark + m.AssignmentMark
                }).ToList()
            };

            report.OverallAverageMark = report.Classes.Any()
                ? report.Classes.Average(c => c.TotalMark)
                : null;

            return report;
        }
    }
}
