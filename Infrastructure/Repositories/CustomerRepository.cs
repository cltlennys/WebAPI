using Core.DTOs.Customer;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
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



        return entity.Adapt<CustomerDTO>();
    }

    public async Task<CustomerDTO> Delete(int id)
    {
        var entity = await VerifyExists(id);

        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync();



        return entity.Adapt<CustomerDTO>();
    }

    public async Task<CustomerDTO> Get(int id)
    {
        var entity = await _context.Customers
            .Include(x => x.Accounts)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) throw new Exception("No se encontro con el id solicitado");

        return entity.Adapt<CustomerDTO>();
    }

    public async Task<List<CustomerDTO>> List(PaginationRequest request, CancellationToken cancellationToken)
    {
        var entities = await _context.Customers
            .Skip((request.Page.Value - 1) * request.PageSize.Value)
            .Take(request.PageSize.Value).Select(customer => new CustomerDTO
            {
                Id = customer.Id,
                FullName = $"{customer.FirstName} {customer.LastName}",
                Phone = customer.Phone,
                Email = customer.Email,
                BirthDate = customer.BirthDate,
            }).ToListAsync(cancellationToken);


       

        return entities;
    }

    public async Task<CustomerDTO> Update(UpdateCustomerDTO updateCustomerDTO)
    {
        var entity = await VerifyExists(updateCustomerDTO.Id);

        updateCustomerDTO.Adapt(entity);

        _context.Customers.Update(entity);
        await _context.SaveChangesAsync();


        return entity.Adapt<CustomerDTO>();
    }

    private async Task<Customer> VerifyExists(int id)
    {
        var entity = await _context.Customers.FindAsync(id);
        if (entity == null) throw new Exception("No se encontro con el id solicitado");
        return entity;
    }

    
}
