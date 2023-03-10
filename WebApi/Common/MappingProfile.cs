using AutoMapper;
using WebApi.BookOpertions.CreateBook;
using WebApi.BookOpertions.GetBookById;
using WebApi.BookOpertions.GetBooks;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,GetBookByIdModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BookViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
        }
    }
}