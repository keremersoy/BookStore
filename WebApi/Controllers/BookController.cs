using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.BookOpertions.GetBooks;
using WebApi.BookOpertions.CreateBook;
using WebApi.BookOpertions.UpdateBook;
using WebApi.BookOpertions.GetBookById;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }
        /*
        private static List<Book> BookList = new List<Book>(){
            new Book{
                Id=1,
                Title="Lean Startup",
                GenreId=1,//Personal growth
                PageCount=200,
                PublishDate=new DateTime(2001,06,12)
            },
            new Book{
                Id=2,
                Title="Herland",
                GenreId=2,//Science Fiction
                PageCount=250,
                PublishDate=new DateTime(2010,05,23)
            },
            new Book{
                Id=3,
                Title="Dune",
                GenreId=2,//Science Fiction
                PageCount=540,
                PublishDate=new DateTime(2001,12,21)
            },
        };*/
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdCommand command = new GetBookByIdCommand(_context);
            
            command.Id = id;
            var result = command.Handle();
            
            return Ok(result);
        }

        /*
        [HttpGet]
        public Book Get([FromQuery] string id)
        {
            var book = BookList.Where(x => x.Id == int.Parse(id)).SingleOrDefault();
            return book;
        }*/

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBook([FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return BadRequest();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}