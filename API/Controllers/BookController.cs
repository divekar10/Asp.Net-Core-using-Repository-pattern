using API.Database;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _bookRepository;

        public BookController(IBook BookRepository)
        {
            _bookRepository = BookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetAllBook();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.GetBookById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepository.AddBook(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.BookId }, newBook);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if(id != book.BookId)
            {
                return BadRequest();
            }
            await _bookRepository.UpdateBook(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var bookToDelete = await _bookRepository.GetBookById(id);
            if (bookToDelete == null)
                return NotFound();

            await _bookRepository.DeleteBook(bookToDelete.BookId);
            return NoContent();
        }
    }
}
