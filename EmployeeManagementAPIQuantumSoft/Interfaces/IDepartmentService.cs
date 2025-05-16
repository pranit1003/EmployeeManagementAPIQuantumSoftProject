using EmployeeManagementAPIQuantumSoft.DTOs;

namespace EmployeeManagementAPIQuantumSoft.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetAllAsync();
        Task<DepartmentDTO> GetByIdAsync(int id);
        Task<DepartmentDTO> CreateAsync(DepartmentDTO departmentDto);
        Task<bool> UpdateAsync(int id, DepartmentDTO departmentDto);
        Task<bool> DeleteAsync(int id);
    }
}
