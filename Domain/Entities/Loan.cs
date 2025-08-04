using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Loan : EntityBase
{
    public DateTime? LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public bool? Status { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    
    public List<Book> Books { get; set; } = new List<Book>();

    public Loan()
    {
    }
    public Loan(DateTime? returnDate, Guid customerId)
    {
        LoanDate = DateTime.UtcNow;
        ReturnDate = returnDate;
        CustomerId = customerId;
        Status = true;
    }
}
