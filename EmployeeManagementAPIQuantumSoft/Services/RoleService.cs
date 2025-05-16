using EmployeeManagementAPIQuantumSoft.Data;
using EmployeeManagementAPIQuantumSoft.DTOs;
using EmployeeManagementAPIQuantumSoft.Models;
using EmployeeManagementAPIQuantumSoft.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPIQuantumSoft.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles.Select(r => new RoleDTO { Id = r.Id, Name = r.Name }).ToList();
        }

        public async Task<RoleDTO> GetRoleByIdAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return null;

            return new RoleDTO { Id = role.Id, Name = role.Name };
        }

        public async Task<RoleDTO> CreateRoleAsync(RoleDTO roleDto)
        {
            var role = new Role { Name = roleDto.Name };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            roleDto.Id = role.Id;
            return roleDto;
        }

        public async Task<bool> UpdateRoleAsync(int id, RoleDTO roleDto)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            role.Name = roleDto.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
