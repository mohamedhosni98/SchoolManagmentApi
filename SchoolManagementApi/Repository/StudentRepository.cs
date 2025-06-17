using managment_api.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> CreateStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return false;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var newstudent = await _context.Students.FindAsync(id);
            newstudent.FirstName = student.FirstName;
            newstudent.LastName = student.LastName;
            newstudent.Age = student.Age;

            await _context.SaveChangesAsync();
            return newstudent;
        }
    }
}
