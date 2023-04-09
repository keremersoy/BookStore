using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOpertions.CreateBook;
using WebApi.Application.BookOpertions.GetBookById;
using WebApi.Application.BookOpertions.GetBooks;
using WebApi.Application.GenreOperation.Queries.GetGenreDetail;
using WebApi.Application.GenreOperation.Queries.GetGenres;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,GetBookByIdModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name));
            CreateMap<Book,BookViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<Author,AuthorsViewModel>();
            CreateMap<Author,AuthorViewModel>();
            CreateMap<CreateAuthorModel,Author>();
        }
    }
}