using FluentValidation;

using Common.Domain.Constants;

namespace Stories.Application.Stories.Commands.AddCharacter
{
    public class AddCharacterCommandValidator : AbstractValidator<AddCharacterCommand>
    {
        public AddCharacterCommandValidator()
        {
            this.RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Story Id must be a valid Guid!");

            this.RuleFor(c => c.FirstName)
                .NotEmpty()
                .Length(StringConstants.MinNameLength, StringConstants.MaxNameLength)
                .WithMessage($"Character's first name must be between {StringConstants.MinNameLength} - {StringConstants.MaxNameLength} chars!");

            this.RuleFor(c => c.LastName)
                .NotEmpty()
                .Length(StringConstants.MinNameLength, StringConstants.MaxNameLength)
                .WithMessage($"Character's last name must be between {StringConstants.MinNameLength} - {StringConstants.MaxNameLength} chars!");

            this.RuleFor(c => c.Spotlight)
                .MaximumLength(StringConstants.MaxStoryLength)
                .WithMessage($"Character's spotlight must be less than {StringConstants.MaxStoryLength} chars!");

        }
    }
}
