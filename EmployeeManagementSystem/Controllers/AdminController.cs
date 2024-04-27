using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.IRepository.cs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repo;
        public AdminController(IAdminRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAdmin()
        {
            var result = await _repo.Get();
            return Ok(result);
        }
        [HttpGet]
        [Authorize]
        [Route("{id:int}/ByAdminId")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _repo.GetById(id);
            if (result == null)
            {
                return NotFound("Admin with id is does not exsist");
            }
            return Ok(result);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertAdmin(Admin admin)
        {

            await _repo.Insert(admin);
            return Ok(admin);
        }
        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateAdmin([FromRoute] int id, [FromBody] Admin admin)
        {
            
            var result = await _repo.Update(id, admin);
            if (result == null)
            {
                return NotFound("Admin with id is does not exsist");
            }
            return Ok(result);
            

        }
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteAdmin([FromRoute] int id)
        {
             var result = await _repo.Delete(id);
                if (result == null)
                {
                    return NotFound("Admin with id is does not exsist");
                }
                return Ok(result);

        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string adminEmail, string password)
        {
            string result = _repo.Login(adminEmail,password);

            if (result == null)
            {
                return NotFound("The Entered UserEmail or Password is Not Correct.");
            }
            return Ok(result);
        }

    }
}
