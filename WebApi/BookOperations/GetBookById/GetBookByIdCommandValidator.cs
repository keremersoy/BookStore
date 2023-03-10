using FluentValidation;

namespace WebApi.BookOpertions.GetBookById{
class GetBookByIdCommandValidator:AbstractValidator<GetBookByIdCommand>
{
    public GetBookByIdCommandValidator()
    {
        RuleFor(command=>command.Id).GreaterThan(0);
    }
}
}