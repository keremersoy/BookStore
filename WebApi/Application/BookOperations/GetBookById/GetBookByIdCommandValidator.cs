using FluentValidation;

namespace WebApi.Application.BookOpertions.GetBookById{
class GetBookByIdCommandValidator:AbstractValidator<GetBookByIdCommand>
{
    public GetBookByIdCommandValidator()
    {
        RuleFor(command=>command.Id).GreaterThan(0);
    }
}
}