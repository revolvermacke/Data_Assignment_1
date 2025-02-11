using Business.Dtos;
using Business.Interfaces;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment_API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    private readonly IEmployeeService _employeeService = employeeService;

    [HttpPost]
    public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeeRegistrationForm form)
    {
        if (form == null)
            return BadRequest("Invalid input");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var employee = await _employeeService.CreateEmployeeAsync(form);

            if (employee == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee.");

            return true ? Ok("employee was created!") : Problem("Error creating employee");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var response = await _employeeService.GetAllEmployeesAsync();
        return response.StatusCode switch
        {
            200 => Ok(response),
            400 => BadRequest(response.ErrorMessage),
            409 => Conflict(response.ErrorMessage),
            500 => Problem(response.ErrorMessage),
            _ => Problem("Something went wrong!"),
        };

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var response = await _employeeService.GetEmployeeByIdAsync(id);
        return response.StatusCode switch
        {
            200 => Ok(response),
            400 => BadRequest(response.ErrorMessage),
            409 => Conflict(response.ErrorMessage),
            500 => Problem(response.ErrorMessage),
            _ => Problem("Something went wrong!"),
        };

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, EmployeeRegistrationForm updateForm)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        try
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, updateForm);
            return result != null ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeById(int id)
    {
        try
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest("Error deleting customer");
        }
    }
}
