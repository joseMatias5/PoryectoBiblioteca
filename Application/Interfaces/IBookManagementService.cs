using Application.Dtos;

namespace Application.Interfaces
{
    public interface IBookManagementService
    {
        Task<BookModel.ResponseBook> AddBook(BookModel.RequestBook request);
        Task<BookModel.ResponseBook>? DeactivateBook(Guid id);
        Task<IEnumerable<BookModel.ResponseBook>?> GetAllBooks();
        Task<BookModel.ResponseBook?> GetBookById(Guid id);
        Task<BookModel.ResponseBook> UpdateBook(Guid id, BookModel.RequestUpdateBook request);
    }
}