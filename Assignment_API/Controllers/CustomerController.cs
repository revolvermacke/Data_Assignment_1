using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Assignment_API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;


    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerRegistrationForm form)
    {
        if (form == null)
            return BadRequest("Invalid input");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var customer = await _customerService.CreateCustomerAsync(form);

            if (customer == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating customer.");

            return true ? Ok("Customer was created!") : Problem("Error creating customer");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var response = await _customerService.GetAllCustomersAsync();
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
    public async Task<IActionResult> GetCustomerById(int id) 
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var response = await _customerService.GetCustomerByIdAsync(id);
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
    public async Task<IActionResult> UpdateCustomer(int id, CustomerRegistrationForm updateForm)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        try
        {
            var result = await _customerService.UpdateCustomerAsync(id, updateForm);
            return result != null ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomerById(int id)
    {
        try
        {
            var result = await _customerService.DeleteCustomerAsync(id);
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