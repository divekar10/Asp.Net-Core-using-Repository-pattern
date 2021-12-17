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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor _authorRepository;

        public AuthorController(IAuthor AuthorRepository)
        {
            _authorRepository = AuthorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _authorRepository.GetAllAuthor();
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            return await _authorRepository.GetAuthorById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor([FromBody] Author author)
        {
            var newAuthor = await _authorRepository.AddAuthor(author);
            return CreatedAtAction(nameof(GetAuthors), new { id = newAuthor.AuthorId }, newAuthor);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }
            await _authorRepository.UpdateAuthor(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            var authorToDelete = await _authorRepository.GetAuthorById(id);
            if (authorToDelete == null)
                return NotFound();

            await _authorRepository.DeleteAuthor(authorToDelete.AuthorId);
            return NoContent();
        }


    }
}
