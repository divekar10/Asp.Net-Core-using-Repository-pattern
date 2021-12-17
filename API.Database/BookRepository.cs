using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Database
{
    public class BookRepository : IBook
    {
        private BookDbContext _BookDbContext;
        public BookRepository(BookDbContext bookDbContext)
        {
            _BookDbContext = bookDbContext;
        }

        public async Task<Book> AddBook(Book book)
        {
            _BookDbContext.Add(book);
            await _BookDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            return await _BookDbContext.Book.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _BookDbContext.Book.FindAsync(id);  
        }
        
        public async Task DeleteBook(int id)
        {
            var bookToDelete = await _BookDbContext.Book.FindAsync(id);
            _BookDbContext.Book.Remove(bookToDelete);
            await _BookDbContext.SaveChangesAsync();
        }

        public async Task UpdateBook(Book book)
        {
            _BookDbContext.Entry(book).State = EntityState.Modified;
            await _BookDbContext.SaveChangesAsync();
        }
    }
}
