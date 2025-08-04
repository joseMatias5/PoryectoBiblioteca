using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Biblioteca.Domain.Interfaces;
using Domain.Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace Application.Services;

public class BookManagementService
{
    IRepository _repository;
    public BookManagementService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<BookModel.ResponseBook?> GetBookById(Guid id)
    {
        var book = await _repository.GetById<Book>(id);

        if (book == null)
            throw new Exception("Libro no encontrado");

        if (book.Available is false)
            throw new Exception("Libro no disponible");

        return new BookModel.ResponseBook(
                book.Id,
                book.Title,
                book.ISBN,
                book.Category,
                book.PublicationYear,
                book.Author,
                book.Description
             );
    }

    public async Task<IEnumerable<BookModel.ResponseBook>?> GetAllBooks()
    {
        var books = await _repository.GetFiltered<Book>(p=> p.Available == true);

        if (books == null)
            throw new Exception("Libros no encontrados");

        return books.Select(p => new BookModel.ResponseBook(
            p.Id,
            p.Title,
            p.ISBN,
            p.Category,
            p.PublicationYear,
            p.Author,
            p.Description
        ));
    }

    public async Task<BookModel.ResponseBook> AddBook(BookModel.RequestBook request)
    {
        var book = new Book(request.Title, request.Isbn, request.Category, request.PublicationYear,
            request.Author, request.Description);
        await _repository.Add(book);

        return new BookModel.ResponseBook(
            book.Id,
            book.Title,
            book.ISBN,
            book.Category,
            book.PublicationYear,
            book.Author,
            book.Description
        );
    }

    public async Task<BookModel.ResponseBook> UpdateBook(Guid id, BookModel.RequestUpdateBook request)
    {
        var book = await _repository.GetById<Book>(id);
        if (book == null) throw new Exception("Libro no encontrado");

        book.Title = request.Title;
        book.Author = request.Author;
        book.Description = request.Description;
        book.Category = request.Category;
        book.PublicationYear = request.PublicationYear;

        await _repository.Update(book);

        //para probar, sino crear updated
        return new BookModel.ResponseBook(
            book.Id,
            book.Title,
            book.ISBN,
            book.Category,
            book.PublicationYear,
            book.Author,
            book.Description
        );
    }

    public async Task<BookModel.ResponseBook>? DeactivateBook(Guid id)
    {
        var book = await _repository.GetById<Book>(id);

        if (book == null) throw new Exception("Libro no encontrado");

        book.Available = false;
        await _repository.Update(book);

        return new BookModel.ResponseBook(
            book.Id,
            book.Title,
            book.ISBN,
            book.Category,
            book.PublicationYear,
            book.Author,
            book.Description
        );
    }
}
