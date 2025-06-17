using managment_api.Models;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Services
{
    public class StudentService : IStudentService
    {
        // injection 
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        // create student 
        public async Task<bool> CreateStudent(Student student)
        {
            if (student == null)
                return false;

            // Validations
            if (string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.LastName))
                return false;

            if (student.Age < 5 || student.Age > 100) // مثال على validation للعمر
                return false;

            return await _studentRepository.CreateStudent(student);
        }
        // get all student 
        public async Task<List<Student>> GetAllStudents()
        {
            return await _studentRepository.GetAllStudents();
        }

        // update student 
        public async Task<Student> UpdateStudent(int id, Student student)
        {
            if (student == null || id <= 0)
                return null;

            // Validations
            if (string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.LastName))
                return null;

            if (student.Age < 5 || student.Age > 100)
                return null;

            var updatedStudent = await _studentRepository.UpdateStudent(id, student);
            return updatedStudent;
        }


        // delete student 
        public async Task<bool> DeleteStudent(int id)
        {
            if (id <= 0)
                return false;

            return await _studentRepository.DeleteStudent(id);
        }
    }
}
