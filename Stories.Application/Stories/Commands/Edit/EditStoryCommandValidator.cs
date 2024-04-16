using FluentValidation;

using Common.Domain.Constants;

namespace Stories.Application.Stories.Commands.Edit
{
    public class EditStoryCommandValidator : AbstractValidator<EditStoryCommand>
    {
        public EditStoryCommandValidator()
        {
            this.RuleFor(s => s.Id)
                .NotEmpty()
                .WithMessage("Id must be a valid Guid!");

            this.RuleFor(s => s.Title)
                .NotEmpty()
                .Length(StringConstants.MinNameLength, StringConstants.MaxNameLength)
                .WithMessage($"Title must be between {StringConstants.MinNameLength} - {StringConstants.MaxNameLength} chars!");

            this.RuleFor(s => s.Plot)
                .NotEmpty()
                .Length(StringConstants.MinStoryLength, StringConstants.MaxStoryLength)
                .WithMessage($"Plot must be between {StringConstants.MinStoryLength} - {StringConstants.MaxStoryLength} chars!");
        }
    }
}
