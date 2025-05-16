using EmployeeManagementAPIQuantumSoft.DTOs;

namespace EmployeeManagementAPIQuantumSoft.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO> GetRoleByIdAsync(int id);
        Task<RoleDTO> CreateRoleAsync(RoleDTO roleDto);
        Task<bool> UpdateRoleAsync(int id, RoleDTO roleDto);
        Task<bool> DeleteRoleAsync(int id);
    }
}
