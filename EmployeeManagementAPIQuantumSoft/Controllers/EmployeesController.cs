using Microsoft.AspNetCore.Http;
using EmployeeManagementAPIQuantumSoft.DTOs;
using EmployeeManagementAPIQuantumSoft.Models;
using EmployeeManagementAPIQuantumSoft.Services;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPIQuantumSoft.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagementAPIQuantumSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        [Authorize(Roles = "Admin, Manager")] // Only Admin and Manager can access
        public async Task<ActionResult<List<EmployeeDTO>>> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        // GET: api/Employee/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager")] // Only Admin and Manager can access
        public async Task<ActionResult<EmployeeDTO>> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // Only Admin can add employees
        public async Task<ActionResult<EmployeeDTO>> Create(EmployeeDTO employeeDto)
        {
            var newEmployee = await _employeeService.AddEmployeeAsync(employeeDto);
            return CreatedAtAction(nameof(GetById), new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDTO>> Update(int id, EmployeeDTO employeeDto)
        {
            var updated = await _employeeService.UpdateEmployeeAsync(id, employeeDto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _employeeService.DeleteEmployeeAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
