using FluentValidation;

namespace WebApi.Application.GenreOperation.Commands.UpdateGenre{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand> {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command=>command.GenreId).GreaterThan(0);
            RuleFor(command=>command.Model.Name).MinimumLength(4).When(x=>x.Model.Name!=string.Empty);
        }
    }
}