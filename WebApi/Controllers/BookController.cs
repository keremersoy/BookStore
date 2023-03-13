using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.BookOpertions.GetBooks;
using WebApi.BookOpertions.CreateBook;
using WebApi.BookOpertions.UpdateBook;
using WebApi.BookOpertions.GetBookById;
using WebApi.BookOpertions.DeleteBook;
using FluentValidation.Results;
using FluentValidation;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mappper;

        public BookController(BookStoreDbContext context, IMapper mappper)
        {
            _context = context;
            _mappper = mappper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mappper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdCommand command = new GetBookByIdCommand(_context, _mappper);
            GetBookByIdModel result;
            command.Id = id;
            GetBookByIdCommandValidator validator = new GetBookByIdCommandValidator();
            validator.ValidateAndThrow(command);
            result = command.Handle();

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
            CreateBookCommand command = new CreateBookCommand(_context, _mappper);

            command.Model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updatedBook;
            UpdateBookCommandValidation validator = new UpdateBookCommandValidation();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.Id = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}