using Microsoft.AspNetCore.Mvc;
using NutcacheChallenge.ApplicationService.Employees.Messages;
using NutcacheChallenge.ApplicationService.Employees.Services.Contract;
using System.ComponentModel.DataAnnotations;

namespace NutcacheChallenge.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        IEmployeeService EmployeeService { get; }

        public EmployeeController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await EmployeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployeeById(long id)
        {
            try
            {
                var employee = await EmployeeService.GetEmployeeByIdAsync(id);
                return Ok(employee);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequest request)
        {
            var employee = await EmployeeService.CreateEmployeeAsync(request);
            return Created($"api/employee/{employee.Id}", employee);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRequest request)
        {
            try
            {
                var employee = await EmployeeService.UpdateEmployeeAsync(request);
                return Ok(employee);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            try
            {
                await EmployeeService.DeleteEmployeeAsync(id);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
