using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Repository.IRepository.cs
{
    public interface IAdminRepository
    {
        Task<List<Admin>> Get();
        Task<Admin> GetById(int id);
        Task<Admin> Insert(Admin admin);
        Task<Admin> Update(int id, Admin admin);
        Task<Admin> Delete(int id);
        string Login(string adminEmail, string password);
        Task<int> GetCount();
    }
}
