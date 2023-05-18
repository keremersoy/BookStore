using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor{
    public class DeleteAuthorCommand {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int AuthorId { get; set; }
        
        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context=context;
        }   

        public void Handle(){
            var author=_context.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            if(author is null){
                throw new InvalidOperationException("Silinmek istenen yazar bulunamadı...");
            }   
            if(_context.Books.Any(x=>x.AuthorId==author.Id)){
                throw new InvalidOperationException("Bu yazarın kitapları mevcut olduğundan silinemez...");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}