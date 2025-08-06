using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Domain.Interfaces;

namespace Application.Services;

public class CustomerManagementService
{
    IRepository repository;
    public CustomerManagementService(IRepository repository)
    {
        this.repository = repository;
    }

    public async Task<bool> CustomerExists(Guid customerId)
    {
        var customer = await repository.GetById<Domain.Entities.Customer>(customerId);
        return customer != null;
    }

    //public async
}
