using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Data;

public class BibliotecaContext : DbContext
{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
    {
    }

    //public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
   // public DbSet<Loan> Loans { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
       /* modelBuilder.Entity<Customer>(c =>
            {
                c.Property(c => c.Name).HasMaxLength(50).IsRequired();
                c.Property(c => c.Address).HasMaxLength(100).IsRequired();
                c.Property(c => c.Phone).HasMaxLength(15).IsRequired();
                c.Property(c => c.Email).HasMaxLength(50).IsRequired();
                c.HasMany(c => c.Loans)
                    .WithOne(l => l.Customer)
                    .HasForeignKey(l => l.CustomerId);
            }
        );*/


        modelBuilder.Entity<Book>(b =>
        {
            b.Property(b => b.Title).HasMaxLength(100).IsRequired();
            b.Property(b => b.ISBN).HasMaxLength(20).IsRequired();
            b.Property(b => b.Description).HasMaxLength(500);
            b.Property(b => b.Author).HasMaxLength(100).IsRequired();
            b.Property(b => b.PublicationYear).IsRequired();
            b.Property(b => b.Category).IsRequired();
        });

/*        modelBuilder.Entity<Loan>(l =>
        {
            l.Property(l => l.LoanDate).IsRequired();
            l.Property(l => l.ReturnDate).IsRequired(false);
            l.HasMany(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        });*/
    }

}
