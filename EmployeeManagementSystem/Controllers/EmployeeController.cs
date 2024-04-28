using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.IRepository.cs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = await _repo.Get();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id:int}/ByEmployeeId")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _repo.GetById(id);
            if (result == null)
            {
                return NotFound("Employee with id is does not exsist");
            }
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetEmployeeCount()
        {
            var employeeCount = await _repo.GetCount();
            if (employeeCount == null)
            {
                return NotFound("Employee List is empty");
            }
            return Ok(employeeCount);
        }

        [HttpGet("salary")]
        public async Task<IActionResult> GetTotalSalary()
        {
            var sum = await _repo.GetTotalSalary();

            return Ok(sum);
        }
        

        [HttpPost]
        public async Task<IActionResult> InsertEmployee(Employee employee)
        {

            await _repo.Insert(employee);
            return Ok(employee);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            
                var result = await _repo.Update(id, employee);
                if (result == null)
                {
                    return NotFound("Employee with id is does not exsist");
                }
                return Ok(result);

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            
            var result = await _repo.Delete(id);
            if (result == null)
            {
                return NotFound("Employee with id is does not exsist");
            }
            return Ok(result);

        }
       

    }
}
