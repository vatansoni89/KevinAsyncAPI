using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("api/syncbooks")]
    public class SyncBooksController : ControllerBase
    {
        private Services.IBooksRepository _booksRepository;
        public SyncBooksController(Services.IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var bookEntities =  _booksRepository.GetBooks();

            return Ok(bookEntities);
        }
    }
}
