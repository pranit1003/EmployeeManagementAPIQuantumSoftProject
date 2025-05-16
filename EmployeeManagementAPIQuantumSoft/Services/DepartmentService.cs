using EmployeeManagementAPIQuantumSoft.Data;
using EmployeeManagementAPIQuantumSoft.DTOs;
using EmployeeManagementAPIQuantumSoft.Models;
using EmployeeManagementAPIQuantumSoft.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPIQuantumSoft.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentDTO>> GetAllAsync()
        {
            return await _context.Departments
                .Select(d => new DepartmentDTO { Id = d.Id, Name = d.Name })
                .ToListAsync();
        }

        public async Task<DepartmentDTO> GetByIdAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return null;

            return new DepartmentDTO { Id = dept.Id, Name = dept.Name };
        }

        public async Task<DepartmentDTO> CreateAsync(DepartmentDTO dto)
        {
            var dept = new Department { Name = dto.Name };
            _context.Departments.Add(dept);
            await _context.SaveChangesAsync();

            dto.Id = dept.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, DepartmentDTO dto)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return false;

            dept.Name = dto.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return false;

            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
