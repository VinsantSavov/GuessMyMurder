using FluentValidation;

using Common.Domain.Constants;

namespace Stories.Application.Stories.Commands.EditCharacter
{
    public class EditCharacterCommandValidator : AbstractValidator<EditCharacterCommand>
    {
        public EditCharacterCommandValidator()
        {
            this.RuleFor(s => s.Id)
                .NotEmpty()
                .WithMessage("Id must be a valid Guid!");

            this.RuleFor(s => s.CharacterId)
                .GreaterThan(0)
                .WithMessage("Character Id must be a positive number!");

            this.RuleFor(c => c.FirstName)
                .NotEmpty()
                .Length(StringConstants.MinNameLength, StringConstants.MaxNameLength)
                .WithMessage($"First name must be between {StringConstants.MinNameLength} - {StringConstants.MaxNameLength} chars!");

            this.RuleFor(c => c.LastName)
                .NotEmpty()
                .Length(StringConstants.MinNameLength, StringConstants.MaxNameLength)
                .WithMessage($"Last name must be between {StringConstants.MinNameLength} - {StringConstants.MaxNameLength} chars!");

            this.RuleFor(c => c.Spotlight)
                .MaximumLength(StringConstants.MaxStoryLength)
                .WithMessage($"Spotlight must be less than {StringConstants.MaxStoryLength} chars!");
        }
    }
}
