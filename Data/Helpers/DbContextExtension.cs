using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data;
using Domain.Entities;

namespace Biblioteca.Data.Helpers;

public static class DbContextExtensions
{
    public static void Seedwork<T>(this BibliotecaContext context, string dataSource) where T : class
    {
        if (context.Set<T>().Any()) return;
        var json = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, dataSource));
        var entities = JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
        if (entities == null || entities.Count == 0) return;
        context.Set<T>().AddRange(entities);
        context.SaveChanges();
    }

    public static void SeedLoans(this BibliotecaContext context, string jsonPath)
    {
        if (context.Loans.Any()) return;

        var fullPath = Path.Combine(AppContext.BaseDirectory, jsonPath);
        var json = File.ReadAllText(fullPath);

        var loans = JsonSerializer.Deserialize<List<Loan>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (loans == null || loans.Count == 0) return;

        foreach (var dto in loans)
        {
            var customer = context.Customers.Find(dto.CustomerId);
            if (customer == null) continue;

            var loan = new Loan(dto.ReturnDate, dto.CustomerId);

            foreach (var book in dto.Books)
            {
                var _book = context.Books.Find(book.Id);
                if (_book == null) continue;
                loan.Books.Add(_book);
            }

            context.Loans.Add(loan);
        }

        context.SaveChanges();
    }
}
