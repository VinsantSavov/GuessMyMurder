using FluentValidation;

namespace Stories.Application.Stories.Commands.DeleteCharacter
{
    public class DeleteCharacterCommandValidator : AbstractValidator<DeleteCharacterCommand>
    {
        public DeleteCharacterCommandValidator()
        {
            this.RuleFor(s => s.Id)
                .NotEmpty()
                .WithMessage("Id must be a valid Guid!");

            this.RuleFor(s => s.CharacterId)
                .GreaterThan(0)
                .WithMessage("Character Id must be a positive number!");
        }
    }
}
