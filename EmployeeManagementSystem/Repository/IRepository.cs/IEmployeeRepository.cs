using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repository.IRepository.cs
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> Get();
        Task<Employee> GetById(int id);
        Task<Employee> Insert(Employee employee);
        Task<Employee> Update(int id, Employee employee);
        Task<Employee> Delete(int id);
        
    }
}
