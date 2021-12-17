using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Database
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> GetAllAuthor();

        Task GetAuthorById();

        Task<Author> AddAuthor(Book book);
    }
}
