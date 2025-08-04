using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public record LoanModel
{
    public record RequestLoan(DateTime? ReturnDate, Guid CustomerId);
    public record ResponseLoan(DateTime LoanDate, DateTime? ReturnDate, Guid CustomerId, string Status);
}
