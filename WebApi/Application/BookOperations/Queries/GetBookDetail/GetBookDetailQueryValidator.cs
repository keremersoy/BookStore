using FluentValidation;

namespace WebApi.Application.BookOpertions.GetBookById{
class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>
{
    public GetBookDetailQueryValidator()
    {
        RuleFor(command=>command.Id).GreaterThan(0);
    }
}
}