using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Database
{
    public interface IBook
    {
        Task<IEnumerable<Book>> GetAllBook();

        Task<Book> GetBookById(int id);

        Task<Book> AddBook(Book book);

        Task UpdateBook(Book book);
        Task DeleteBook(int id);

    }
}
