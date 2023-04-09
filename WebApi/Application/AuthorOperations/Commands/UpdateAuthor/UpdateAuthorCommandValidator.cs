using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor{
    class UpdateAuthorCommandValidation:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidation()
        {
            RuleFor(command=>command.AuthorId).GreaterThan(0);
            
            RuleFor(command=>command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command=>command.Model.Birthday.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}