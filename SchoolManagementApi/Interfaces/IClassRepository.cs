using managment_api.Models;

namespace SchoolManagementApi.Interfaces
{
    public interface IClassRepository
    {
        Task<bool> CreateClass(Class @class);
        Task<List<Class>> GetAllClasses();

        Task<bool> DeleteClass(int id);
    }
}
