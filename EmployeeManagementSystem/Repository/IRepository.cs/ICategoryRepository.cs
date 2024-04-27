using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository.IRepository.cs
{
        public interface ICategoryRepository
        {
            Task<List<Category>> Get();
            Task<Category> GetById(int id);
            Task<Category> Insert(Category category);
            Task<Category> Update(int id, Category category);
            Task<Category> Delete(int id);
        }
}
