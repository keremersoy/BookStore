using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Common;
using AutoMapper;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.BookOpertions.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BookViewModel> Handle(){
            var bookList=_dbContext.Books.Include(x=>x.Genre).OrderBy(x=>x.Id).ToList<Book>();
            List<BookViewModel> vm= _mapper.Map<List<BookViewModel>>(bookList); /*new List<BookViewModel>();
            foreach(var book in bookList){
                vm.Add(new BookViewModel(){
                    Id=book.Id,
                    Title=book.Title,
                    Genre=((GenreEnum)book.GenreId).ToString(),
                    PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy"),
                    PageCount=book.PageCount,
                });
            }*/
            return vm;
        }
    }

    public class BookViewModel{
        
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}