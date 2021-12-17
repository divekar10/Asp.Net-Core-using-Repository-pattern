using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Database
{
    public class BookRepository : IBook
    {
        public Task<Book> AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllBook()
        {
            throw new NotImplementedException();
        }

        public Task GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
