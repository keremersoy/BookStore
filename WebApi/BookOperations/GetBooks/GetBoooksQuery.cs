using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Common;

namespace WebApi.BookOpertions.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookViewModel> Handle(){
            var bookList=_dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            List<BookViewModel> vm=new List<BookViewModel>();
            foreach(var book in bookList){
                vm.Add(new BookViewModel(){
                    Id=book.Id,
                    Title=book.Title,
                    Genre=((GenreEnum)book.GenreId).ToString(),
                    PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy"),
                    PageCount=book.PageCount,
                });
            }
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