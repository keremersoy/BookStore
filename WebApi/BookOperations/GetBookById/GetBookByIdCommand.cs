using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Common;

namespace WebApi.BookOpertions.GetBookById
{

    public class GetBookByIdCommand
    {
        public int? Id { get; set; }
        public readonly BookStoreDbContext _dbContext;
        public GetBookByIdCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }
        public GetBookByIdModel Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == Id).SingleOrDefault();
            GetBookByIdModel result = new GetBookByIdModel()
            {
                Id = book.Id,
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                PageCount = book.PageCount,
            };
            return result;
        }
    }

    public class GetBookByIdModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}