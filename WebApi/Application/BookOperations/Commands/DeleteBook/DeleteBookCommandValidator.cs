using FluentValidation;

namespace WebApi.Application.BookOpertions.DeleteBook{
    public class DeleteBookCommandValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command=>command.Id).GreaterThan(0);
        }
    }
}