using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Customer : EntityBase
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public List<Loan>? Loans { get; set; } = new List<Loan>();
    public Customer()
    {
    }

    public Customer(string name, string address, string phone, string email)
    {
        Name = name;
        Address = address;
        Phone = phone;
        Email = email;
    }
}
