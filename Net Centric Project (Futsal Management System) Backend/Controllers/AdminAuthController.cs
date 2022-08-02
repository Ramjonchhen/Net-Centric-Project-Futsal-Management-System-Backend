using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Net_Centric_Project__Futsal_Management_System__Backend.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Net_Centric_Project__Futsal_Management_System__Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private static Admin admin = new Admin();
        private readonly FutsalManagementDBContext dbContext;
        private readonly IConfiguration configuration;

        public AdminAuthController(
            FutsalManagementDBContext dbContext,
            IConfiguration configuration
        )
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Admin>> Register(UserRegisterDTO request)
        {
            CreatePassowordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            admin.Name = request.Name;
            admin.Email = request.Email;
            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;

            dbContext.Admins.Add(admin);
            await dbContext.SaveChangesAsync();
            return Ok(admin);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLogin userLogin)
        {
            var query = $"select * from Admins where Email = '{userLogin.Email}'";
            List<Admin> admin = dbContext.Admins.FromSqlRaw(query).ToList(); ;

            if(admin.Count == 0 )
            {
                return BadRequest("No User With Provided Email");
            }

            if (!VefiryPasswordHash(userLogin.Password, admin[0].PasswordHash, admin[0].PasswordSalt) ) {
                return BadRequest("You have Enterd Wrong Password");
            }

            string token = CreateToken(admin[0]);
            return Ok(token);
        }


        private string CreateToken(Admin admin)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, admin.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                configuration["SECRET"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePassowordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VefiryPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
