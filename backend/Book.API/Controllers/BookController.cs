using AutoMapper;
using Book.API.DbContexts;
using Book.API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        public BookController(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetBooks()
        {
            var books = _context.Books.ToList();

            //Return the entire entity
            //return Ok(books);

            //Only return what Angular needs!
            //Manual mapping
            //List<BookDto> bookDtos = new List<BookDto>();
            //foreach (var book in books)
            //{
            //    bookDtos.Add(new BookDto { Id = book.Id, Title = book.Title, Author = book.Author });
            //}

            //return Ok(bookDtos);

            //AutoMapper - MappingProfile
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

    }
}
