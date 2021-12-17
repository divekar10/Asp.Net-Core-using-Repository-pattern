using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Database
{
    public class AuthorRepository : IAuthor
    {
        private BookDbContext _BookDbContext;
        public AuthorRepository(BookDbContext bookDbContext)
        {
            _BookDbContext = bookDbContext;
        }

        public async Task<Author> AddAuthor(Author author)
        {
            _BookDbContext.Add(author);
            await _BookDbContext.SaveChangesAsync();
            return author;
        }

        public async Task DeleteAuthor(int id)
        {
            var authorToDelete = await _BookDbContext.author.FindAsync(id);
            _BookDbContext.author.Remove(authorToDelete);
            await _BookDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            return await _BookDbContext.author.ToListAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _BookDbContext.author.FindAsync(id);
        }

        public async Task UpdateAuthor(Author author)
        {
            _BookDbContext.Entry(author).State = EntityState.Modified;
            await _BookDbContext.SaveChangesAsync();
        }
    }
}
