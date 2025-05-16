namespace EmployeeManagementAPIQuantumSoft.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
