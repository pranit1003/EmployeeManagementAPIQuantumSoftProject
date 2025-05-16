namespace EmployeeManagementAPIQuantumSoft.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(string username, string password, int roleId);
        Task<string> Login(string username, string password);
    }
}
