using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Dtos;

public record BookModel
{
    public record RequestBook(string Title, string Isbn, Category Category, int PublicationYear, 
        string Author, string? Description);

    public record ResponseBook(Guid Id, string Title, string Isbn, Category Category, int? PublicationYear,
        string Author, string? Description);

    public record RequestUpdateBook(string Title, Category Category, int PublicationYear,
        string Author, string? Description);
}
