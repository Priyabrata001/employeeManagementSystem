using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.IRepository.cs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.Repository.cs
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EmpDbContext _context;

        public CategoryRepository(EmpDbContext context)
        {
            _context = context;
        }


        public async Task<List<Category>> Get()
        {
            return await _context.Category.ToListAsync();
        }


        public async Task<Category> GetById(int id)
        {
            var result = await _context.Category.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<Category> Update(int id, Category category)
        {
            var result = await _context.Category.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            result.Name = category.Name;
            await _context.SaveChangesAsync();
            return result;
        }


        public async Task<Category> Insert(Category category)
        {
            _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }


        public async Task<Category> Delete(int id)
        {
            var result = await _context.Category.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            _context.Category.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
