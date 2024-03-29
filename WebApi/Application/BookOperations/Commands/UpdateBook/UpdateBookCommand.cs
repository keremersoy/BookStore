using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Common;

namespace WebApi.Application.BookOpertions.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel? Model { get; set; }
        public int BookId { get; set; }
        public readonly IBookStoreDbContext _dbContext;

        public UpdateBookCommand(IBookStoreDbContext context)
        {
            _dbContext = context;
        }

        public void Handle()
        {
            try
            {
                var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
                if (book is null)
                {
                    throw new InvalidOperationException("Güncellenmek istenen kitap mevcut değil...");
                }
                book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
                book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
                book.Title = Model.Title != default ? Model.Title : book.Title;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

    public class UpdateBookModel
    {
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}