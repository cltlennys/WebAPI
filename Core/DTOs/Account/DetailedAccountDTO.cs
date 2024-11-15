using Core.DTOs.Customer;
using Core.Entities;
using System;
using System.Collections.Generic;
namespace Core.DTOs.Account;

public class DetailedAccountDTO
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;

    public decimal Balance { get; set; }

    public string OpeningDate { get; set; } = string.Empty;

    public CustomerDTO? Customer { get; set; }


}
