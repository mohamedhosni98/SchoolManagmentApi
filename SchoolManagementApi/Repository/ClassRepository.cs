using managment_api.Models;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<bool> CreateClass(Class @class)
        {
            await _context.Classes.AddAsync(@class);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClass(int id)
        {
            var @class = await _context.Classes.FindAsync(id);
            if (@class == null)
                return false;
            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<List<Class>> GetAllClasses()
        {
            return await _context.Classes.ToListAsync();
        }
    }
}
