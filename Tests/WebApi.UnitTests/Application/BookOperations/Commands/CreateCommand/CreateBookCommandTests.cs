using TestSetup;
using WebApi.DBOperations;
using Xunit;

namespace Application.BookOperations.Commands.CreateCommand{
    public class CreateBookCommandTests:IClassFixture<CommonTestFixture> {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
            _mapper=testFixture.Mapper;
        }
        
    }
}