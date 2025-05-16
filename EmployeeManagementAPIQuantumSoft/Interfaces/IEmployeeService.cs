using EmployeeManagementAPIQuantumSoft.DTOs;
using EmployeeManagementAPIQuantumSoft.Models;

namespace EmployeeManagementAPIQuantumSoft.Interfaces
{
    public interface IEmployeeService
    {
        //Task<List<Employee>> GetAllEmployeesAsync();
        //Task<Employee> GetEmployeeByIdAsync(int id);
        //Task<Employee> AddEmployeeAsync(EmployeeDTO employeeDto);
        //Task<Employee> UpdateEmployeeAsync(int id, EmployeeDTO employeeDto);
        //Task<bool> DeleteEmployeeAsync(int id);

        Task<List<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDto);
        Task<EmployeeDTO> UpdateEmployeeAsync(int id, EmployeeDTO employeeDto);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
