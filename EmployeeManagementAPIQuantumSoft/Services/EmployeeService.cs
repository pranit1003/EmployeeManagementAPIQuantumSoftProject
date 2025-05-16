using EmployeeManagementAPIQuantumSoft.Data;
using EmployeeManagementAPIQuantumSoft.DTOs;
using EmployeeManagementAPIQuantumSoft.Models;
using EmployeeManagementAPIQuantumSoft.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPIQuantumSoft.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<List<Employee>> GetAllEmployeesAsync()
        //{
        //    return await _context.Employees
        //        .Include(e => e.Department)
        //        .Include(e => e.Role)
        //        .ToListAsync();
        //}

        //public async Task<Employee> GetEmployeeByIdAsync(int id)
        //{
        //    return await _context.Employees
        //        .Include(e => e.Department)
        //        .Include(e => e.Role)
        //        .FirstOrDefaultAsync(e => e.Id == id);
        //}

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    Email = e.Email,
                    Phone = e.Phone,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department.Name,
                    RoleId = e.RoleId,
                    RoleName = e.Role.Name
                })
                .ToListAsync();
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
                return null;

            return new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department.Name,
                RoleId = employee.RoleId,
                RoleName = employee.Role.Name
            };
        }

        //public async Task<Employee> AddEmployeeAsync(EmployeeDTO employeeDto)
        //{
        //    var employee = new Employee
        //    {
        //        Name = employeeDto.Name,
        //        Email = employeeDto.Email,
        //        Phone = employeeDto.Phone,
        //        DepartmentId = employeeDto.DepartmentId,
        //        RoleId = employeeDto.RoleId
        //    };

        //    _context.Employees.Add(employee);
        //    await _context.SaveChangesAsync();
        //    return employee;
        //}

        //public async Task<Employee> UpdateEmployeeAsync(int id, EmployeeDTO employeeDto)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //        return null;

        //    employee.Name = employeeDto.Name;
        //    employee.Email = employeeDto.Email;
        //    employee.Phone = employeeDto.Phone;
        //    employee.DepartmentId = employeeDto.DepartmentId;
        //    employee.RoleId = employeeDto.RoleId;

        //    await _context.SaveChangesAsync();
        //    return employee;
        //}

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                DepartmentId = employeeDto.DepartmentId,
                RoleId = employeeDto.RoleId
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            employeeDto.Id = employee.Id;
            return employeeDto;
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(int id, EmployeeDTO employeeDto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return null;

            employee.Name = employeeDto.Name;
            employee.Email = employeeDto.Email;
            employee.Phone = employeeDto.Phone;
            employee.DepartmentId = employeeDto.DepartmentId;
            employee.RoleId = employeeDto.RoleId;

            await _context.SaveChangesAsync();

            employeeDto.Id = employee.Id;
            return employeeDto;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
