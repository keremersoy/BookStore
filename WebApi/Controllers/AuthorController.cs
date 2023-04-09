using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using FluentValidation.Results;
using FluentValidation;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query=new GetAuthorsQuery(_context,_mapper);
            var authors=query.Handle();
    
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorDetail(int id)
        {            
            GetAuthorDetailQuery query=new GetAuthorDetailQuery(_context,_mapper);
            
            query.AuthorId=id;
            var author=query.Handle();
    
            return Ok(author);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] Object newAuthor){
            System.Console.WriteLine("yazar eklendi");
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Object updatedAuthor)
        {
            System.Console.WriteLine(id + ". yazar güncellendi");
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id){
            System.Console.WriteLine(id+". yazar silindi");
            return Ok();
        }
    }
}