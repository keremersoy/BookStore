using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperation.Queries.GetGenreDetail{
    public class GetGenreDetailQuery {
        public int GenreId { get; set; }
        public readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(IBookStoreDbContext context,IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public GenreDetailViewModel Handle(){
            var genres=_context.Genres.Where(x=>x.IsActive && x.Id==GenreId).OrderBy(x=>x.Id);
            return _mapper.Map<GenreDetailViewModel>(genres.SingleOrDefault());
        }
    }

    public class GenreDetailViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public bool IsActive { get; set; }
    }
}