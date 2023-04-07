using WebApi.DBOperations;

namespace WebApi.Application.GenreOperation.Commands.DeleteGenre{
    public class DeleteGenreCommand{
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;
        public DeleteGenreCommand(BookStoreDbContext context){
            _context=context;
        }
        public void Handle(){

            var genre=_context.Genres.SingleOrDefault(o=>o.Id==GenreId);
            if(genre is null){
                throw new InvalidOperationException("Kitap türü bulunamadı...");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}