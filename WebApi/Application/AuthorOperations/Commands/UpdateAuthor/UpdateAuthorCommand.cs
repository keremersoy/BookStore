using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{//TODO: update kontrol edilecek.
    public class UpdateAuthorCommand
    {

        public readonly BookStoreDbContext _context;
        public UpdateAuthorModel Model { get; set; }
        public int AuthorId { get; set; }
        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Güncellenmek istenen yazar kayıtlı değil...");
            }
            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Birthday = Model.Birthday != default ? Model.Birthday : author.Birthday;
            _context.SaveChanges();
        }
    }
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}

