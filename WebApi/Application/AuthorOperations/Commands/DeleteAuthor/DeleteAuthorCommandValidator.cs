using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor{
    class DeleteAuthorCommandValidation:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidation()
        {
            RuleFor(command=>command.AuthorId).GreaterThan(0);
        }
    }
}