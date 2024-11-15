using Core.Entities;
using Core.Interfaces.Repositories;

using Core.Requests;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Core.DTOs.Customer;

namespace WebApi.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IValidator<CreateCustomerDTO> _createValidation;
    private readonly IValidator<UpdateCustomerDTO> _updateValidation;

    public CustomerController(ICustomerRepository customerRepository, IValidator<CreateCustomerDTO> createValidation, IValidator<UpdateCustomerDTO> updateValidation)
    {
        _customerRepository = customerRepository;
        _createValidation = createValidation;
        _updateValidation = updateValidation;   
    }



    [HttpGet("list")]
    public async Task<IActionResult> List([FromQuery] PaginationRequest request, CancellationToken cancellationToken)
    {
        return Ok(await _customerRepository.List(request, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await _customerRepository.Get(id));
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateCustomerDTO createCustomerDTO)
    {
        var validation = await _createValidation.ValidateAsync(createCustomerDTO);
        if (!validation.IsValid)
            return BadRequest(validation.Errors);

        return Ok(await _customerRepository.Add(createCustomerDTO));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerDTO updateCustomerDTO)

    {
        var validation = await _updateValidation.ValidateAsync(updateCustomerDTO);
        if (!validation.IsValid)
            return BadRequest(validation.Errors);


        return Ok(await _customerRepository.Update(updateCustomerDTO));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _customerRepository.Delete(id));
    }
}
