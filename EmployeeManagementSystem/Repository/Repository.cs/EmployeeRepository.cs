using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.IRepository.cs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.Repository.cs
{
    public class  EmployeeRepository: IEmployeeRepository
    {
        private readonly EmpDbContext _context;

    public EmployeeRepository(EmpDbContext context)
    {
        _context = context;
    }


    public async Task<List<Employee>> Get()
    {
        return await _context.Employee.ToListAsync();
    }


    public async Task<Employee> GetById(int id)
    {
        var result = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeId == id);

        if (result == null)
        {
            return null;
        }
        return result;
    }

    public async Task<Employee> Update(int id, Employee employee)
    {
        var result = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (result == null)
            {
                return null;
            }
            result.EmployeeName = employee.EmployeeName;
            result.Salary= employee.Salary;
            result.Address = employee.Address;
            result.EmployeeEmail = employee.EmployeeEmail;
            result.CategoryId= employee.CategoryId;
        await _context.SaveChangesAsync();
        return result;
    }


    public async Task<Employee> Insert(Employee employee)
    {
        _context.Employee.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }


    public async Task<Employee> Delete(int id)
    {
        var result = await _context.Employee.FirstOrDefaultAsync(x => x.EmployeeId== id);
            if (result == null)
            {
                return null;
            }
            _context.Employee.Remove(result);
        await _context.SaveChangesAsync();

        return result;
    }
}
}
