using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail{
public class GetGenreDetailQueryValidator:AbstractValidator<GetAuthorDetailQuery> {
    public GetGenreDetailQueryValidator(){
        RuleFor(query=>query.AuthorId).GreaterThan(0);
    }
}
}