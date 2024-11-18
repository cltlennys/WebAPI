﻿using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.DTOs.Customer;
using Core.DTOs.Entity;
using Core.DTOs.Payment;
using Core.DTOs.Product;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using FluentValidation;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Validation.Card;
using Infrastructure.Validation.Charge;
using Infrastructure.Validation.Customer;
using Infrastructure.Validation.Entity;
using Infrastructure.Validation.Payment;
using Infrastructure.Validation.Product;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddRepositories();
        services.AddDatabase(configuration);
        services.AddMapping();
        services.AddValidation();
        services.AddServices();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IChargeRepository, ChargeRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IEntityRepository, EntityRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerEntityRepository, CustomerEntityRepository>();
        services.AddScoped<ICustomerEntityProductRepository, CustomerEntityProductRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICardService, CardService>();
        services.AddScoped<IEntityService, EntityService>();

        return services;
    }

    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration) 
    {
        var connectionString = configuration.GetConnectionString("Bootcamp");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateCustomerDTO>, CreateValidation>();
        services.AddScoped<IValidator<UpdateCustomerDTO>, UpdateValidation>();
        services.AddScoped<IValidator<CreateCardDTO>, CreateCardValidation>();
        services.AddScoped<IValidator<CreateChargeDTO>, CreateChargeValidation>();
        services.AddScoped<IValidator<CreatePaymentDTO>, CreatePaymentValidation>();
        services.AddScoped<IValidator<CreateEntityDTO>, CreateEntityValidation>();
        services.AddScoped<IValidator<CreateProductDTO>, CreateProductValidation>();
        services.AddScoped<IValidator<UpdateCardDTO>, UpdateCardValidation>();

        return services;

    }

    public static IServiceCollection AddMapping (this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper> ();

        return services;
    }
}
