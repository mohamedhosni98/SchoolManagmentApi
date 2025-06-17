using managment_api.Models;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<bool> CreateClass(Class @class)
        {
            if (@class == null)
                return false;

            // Validations
            if (string.IsNullOrEmpty(@class.Name) || string.IsNullOrEmpty(@class.Teacher))
                return false;

            return await _classRepository.CreateClass(@class);
        }

        public async Task<List<Class>> GetAllClasses()
        {
            return await _classRepository.GetAllClasses();
        }

        public async Task<bool> DeleteClass(int id)
        {
            if (id <= 0)
                return false;

            return await _classRepository.DeleteClass(id);
        }
    }
}
