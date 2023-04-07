using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Common;

namespace WebApi.Application.BookOpertions.DeleteBook
{
    public class DeleteBookCommand
    {
        public int Id { get; set; }
        public readonly BookStoreDbContext _dbContext;

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _dbContext=context;
        }

        public void Handle(){
             var book = _dbContext.Books.SingleOrDefault(x => x.Id == Id);
            if (book is null)
            {
                throw new InvalidOperationException("Silinmek istenen kitap bulunamadı...");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}