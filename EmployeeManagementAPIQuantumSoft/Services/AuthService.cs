using EmployeeManagementAPIQuantumSoft.Data;
using EmployeeManagementAPIQuantumSoft.Interfaces;
using EmployeeManagementAPIQuantumSoft.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagementAPIQuantumSoft.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Register(string username, string password, int roleId)
        {
            if (await _context.Users.AnyAsync(u => u.Username == username))
                return "User already exists.";

            var passwordHash = ComputeSha256Hash(password);

            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash,
                RoleId = roleId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "User registered successfully.";
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == username);
            if (user == null || user.PasswordHash != ComputeSha256Hash(password))
                return "Invalid username or password.";

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.Name)
        }),
                Expires = DateTime.UtcNow.AddHours(1),

                // ✅ ADD THESE TWO LINES
                Issuer = _configuration["Jwt:Issuer"],      // "QuantumSoftAPI"
                Audience = _configuration["Jwt:Audience"],  // "QuantumSoftClient"

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
