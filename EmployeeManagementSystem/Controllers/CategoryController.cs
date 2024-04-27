using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.IRepository.cs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _repo.Get();
            return Ok(result);
        }
        [HttpGet]
        [Route("{id:int}/ByCategoryId")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _repo.GetById(id);
            if(result == null)
            {
                return NotFound("Category with id is does not exsist");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCategory(Category category)
        {
            
                await _repo.Insert(category);
                return Ok(category);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] Category category)
        {
            
            var result = await _repo.Update(id, category);
            if (result == null)
            {
                return NotFound("Category with id is does not exsist");
            }
            return Ok(result);
           
            
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCtegory([FromRoute] int id)
        {
            
            var result = await _repo.Delete(id);
            if (result == null)
            {
                return NotFound("Category with id is does not exsist");
            }
            return Ok(result);
            

        }
    }
}
