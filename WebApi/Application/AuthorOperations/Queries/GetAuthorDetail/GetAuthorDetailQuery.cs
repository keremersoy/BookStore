using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail{
    public class GetAuthorDetailQuery {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(BookStoreDbContext context,IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public AuthorViewModel Handle(){
            var author=_context.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            AuthorViewModel returnObj=_mapper.Map<AuthorViewModel>(author);
            return returnObj;
        }
    }

    public class AuthorViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Birthday { get; set; }
    }
}