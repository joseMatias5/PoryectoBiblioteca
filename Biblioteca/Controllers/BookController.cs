using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    BookManagementService _service;
    public BookController(BookManagementService service)
    {
        _service = service;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllBooks()
    {
        try
        {
            var books = await _service.GetAllBooks();
            return Ok(books);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        try
        {
            var book = await _service.GetBookById(id);
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost()]
    public async Task<IActionResult> AddBook([FromBody] BookModel.RequestBook request)
    {
        try
        {
            var book = await _service.AddBook(request);
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(Guid id, [FromBody] BookModel.RequestUpdateBook request)
    {
        try
        {
            var book = await _service.UpdateBook(id, request);
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}")]

    public async Task<IActionResult> DeleteBook(Guid id)
    {
        try
        {
            var book = await _service.DeactivateBook(id);
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
