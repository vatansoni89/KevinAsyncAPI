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
        public async Task<IActionResult> GetBooks()
        {
            var bookEntities = await _booksRepository.GetBooksAsync();

            return Ok(bookEntities);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBooks(Guid id)
        {
            var bookEntitity = await _booksRepository.GetBookAsync(id);

            if (bookEntitity == null)
            {
                return NotFound();
            }

            return Ok(bookEntitity);
        }
    }
}
