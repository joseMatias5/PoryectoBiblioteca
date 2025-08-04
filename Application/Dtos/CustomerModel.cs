using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public record CustomerModel
{
    public record RequestCustomer(string Name, string Address, string Phone, string Email);
    public record ResponseCustomer(Guid Id, string Name, string Address, string Phone, string Email);
}
