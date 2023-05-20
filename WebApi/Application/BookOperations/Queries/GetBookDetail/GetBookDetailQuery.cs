using System;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Common;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.BookOpertions.GetBookById
{

    public class GetBookDetailQuery
    {
        public int? Id { get; set; }
        public readonly IBookStoreDbContext _dbContext;
        public readonly IMapper _mapper;
        public GetBookDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public GetBookByIdModel Handle()
        {
            var book = _dbContext.Books.Include(x=>x.Genre).Include(x=>x.Author).Where(x => x.Id == Id).SingleOrDefault();
            if(book is null){
                throw new InvalidOperationException("Kitap bulunamadı...");
            }
            GetBookByIdModel result = _mapper.Map<GetBookByIdModel>(book);/*new GetBookByIdModel()
            {
                Id = book.Id,
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                PageCount = book.PageCount,
            };*/
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
        public string Author { get; set; }
    }
}