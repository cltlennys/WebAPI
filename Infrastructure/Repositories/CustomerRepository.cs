using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerDTO> Add(CreateCustomerDTO createCustomerDTO)
    {
        var entity = new Customer
        {
            FirstName = createCustomerDTO.FirstName,
            LastName = createCustomerDTO.LastName,
            Email = createCustomerDTO.Email,
            Phone = createCustomerDTO.Phone,
            BirthDate = createCustomerDTO.BirthDate
        };

        _context.Customers.Add(entity); //aqui no impactamos aun la BD
        await _context.SaveChangesAsync(); //esto impacta en la BD

       

        return AddTo(entity);
    }

    public async Task<CustomerDTO> Delete(int id)
    {
        var entity = await VerifyExists(id);

        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync();

        

        return AddTo(entity);
    }

    public async Task<CustomerDTO> Get(int id)
    {
        var entity = await VerifyExists(id);

        return AddTo(entity);
    }

    public async Task<List<CustomerDTO>> List(PaginationRequest request, CancellationToken cancellationToken)
    {
        var dtos = await _context.Customers
            .Skip((request.Page.Value - 1) * request.PageSize.Value)
            .Take(request.PageSize.Value).Select(customer => new CustomerDTO
            {
                Id = customer.Id,
                FullName = $"{customer.FirstName} {customer.LastName}",
                Phone = customer.Phone,
                Email = customer.Email,
                BirthDate = customer.BirthDate,
            }).ToListAsync(cancellationToken);

<<<<<<< HEAD
=======
        var dtos = entities.Select(customer => new CustomerDTO
        {
            Id = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}",
            Phone = customer.Phone,
            Email = customer.Email,
            BirthDate = customer.BirthDate.ToShortDateString(),
        });
>>>>>>> bd96a8821552a737241f1e57ac48f1778b78ef8e

        return dtos;
    }

    public async Task<CustomerDTO> Update(UpdateCustomerDTO updateCustomerDTO)
    {
        var entity = await VerifyExists(updateCustomerDTO.Id);

        entity.Id = updateCustomerDTO.Id;
        entity.FirstName = updateCustomerDTO.FirstName;
        entity.LastName = updateCustomerDTO.LastName;
        entity.Email = updateCustomerDTO.Email;
        entity.Phone = updateCustomerDTO.Phone;
        entity.BirthDate = updateCustomerDTO.BirthDate;

        _context.Customers.Update(entity);
        await _context.SaveChangesAsync();


        return AddTo(entity);
    }

    private async Task<Customer> VerifyExists(int id)
    {
        var entity = await _context.Customers.FindAsync(id);
        if (entity == null) throw new Exception("No se encontro con el id solicitado");
        return entity;
    }

    private CustomerDTO AddTo(Customer customer) => new()
    {
        Id = customer.Id,
        FullName = $"{customer.FirstName} {customer.LastName}",
        Phone = customer.Phone,
        Email = customer.Email,
        BirthDate = customer.BirthDate

    };
}
