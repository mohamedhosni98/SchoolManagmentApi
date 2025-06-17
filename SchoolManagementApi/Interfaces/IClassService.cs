using managment_api.Models;

namespace SchoolManagementApi.Interfaces
{
    public interface IClassService
    {
        Task<bool> CreateClass(Class @class);
        Task<List<Class>> GetAllClasses();

        Task<bool> DeleteClass(int id);
    }
}
