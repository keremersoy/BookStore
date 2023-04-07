using FluentValidation;

namespace WebApi.Application.GenreOperation.Commands.CreateGenre{
public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand> {
    public CreateGenreCommandValidator(){
        RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(4);
    }
}
}