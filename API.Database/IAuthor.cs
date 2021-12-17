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

        Task<Author> GetAuthorById(int id);

        Task<Author> AddAuthor(Author author);

        Task UpdateAuthor(Author author);
        Task DeleteAuthor(int id);
    }
}
