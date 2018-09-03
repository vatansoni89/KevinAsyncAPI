using Books.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api.Controllers
{
    [ApiController] // will force for attbr based routing.
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private Services.IBooksRepository _booksRepository;
        public BooksController(Services.IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            var bookEntities = await _booksRepository.GetBooksAsync();

            return Ok(bookEntities);
        }

        [HttpGet]
        [BookResultFilter]
        [Route("{id}")]
        
        public async Task<IActionResult> GetBook(Guid id)
        {
            var bookEntity = await _booksRepository.GetBookAsync(id);

            if (bookEntity == null)
            {
                return NotFound();
            }

            return Ok(bookEntity);
        }
    }
}
