using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository.IRepository.cs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagementSystem.Repository.Repository.cs
{
    public class AdminRepository : IAdminRepository
    {
        private readonly EmpDbContext _context;
        private readonly IConfiguration _configuration;

        public AdminRepository(EmpDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public async Task<List<Admin>> Get()
        {
            return await _context.Admin.ToListAsync();
        }


        public async Task<Admin> GetById(int id)
        {
            var result = await _context.Admin.FirstOrDefaultAsync(x => x.AdminId == id);

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<Admin> Update(int id, Admin admin)
        {
            var result = await _context.Admin.FirstOrDefaultAsync(x => x.AdminId == id);
            if (result == null)
            {
                return null;
            }
            result.AdminName = admin.AdminName;
            result.AdminEmail = admin.AdminEmail;
            result.Password = admin.Password;
            await _context.SaveChangesAsync();
            return result;
        }


        public async Task<Admin> Insert(Admin admin)
        {
            _context.Admin.AddAsync(admin);
            await _context.SaveChangesAsync();

            return admin;
        }


        public async Task<Admin> Delete(int id)
        {
            var result = await _context.Admin.FirstOrDefaultAsync(x => x.AdminId == id);
            if (result == null)
            {
                return null;
            }
            _context.Admin.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
        public string Login(string adminEmail, string password)
        {
            var adminExist = _context.Admin.FirstOrDefault(t => t.AdminEmail == adminEmail && EF.Functions.Collate(t.Password, "SQL_Latin1_General_CP1_CS_AS") == password);
            if (adminExist != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
             new Claim(ClaimTypes.Email,adminExist.AdminEmail),
             new Claim("AdminId",adminExist.AdminId.ToString())
         };
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            return null;
        }
    }
}
