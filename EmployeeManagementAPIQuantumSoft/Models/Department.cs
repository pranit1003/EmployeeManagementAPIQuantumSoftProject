namespace EmployeeManagementAPIQuantumSoft.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<Employee> Employees { get; set; }
    }
}
