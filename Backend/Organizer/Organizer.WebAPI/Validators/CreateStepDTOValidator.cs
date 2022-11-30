using FluentValidation;
using Organizer.Models.DTOs.Step;

namespace Organizer.Validators;

public class CreateStepDTOValidator : AbstractValidator<CreateStepDTO>
{
    public CreateStepDTOValidator()
    {
        RuleFor(dto => dto.AssignmentId).NotEmpty();
    }
}