using FluentValidation;

namespace Stories.Application.Stories.Commands.Delete
{
    public class DeleteStoryCommandValidator : AbstractValidator<DeleteStoryCommand>
    {
        public DeleteStoryCommandValidator()
        {
            this.RuleFor(s => s.Id)
                .NotEmpty()
                .WithMessage("Id must be a valid Guid!");
        }
    }
}
