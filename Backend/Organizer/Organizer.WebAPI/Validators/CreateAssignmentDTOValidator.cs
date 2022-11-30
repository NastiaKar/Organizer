using FluentValidation;
using Organizer.Models.DTOs.Assignment;

namespace Organizer.Validators;

public class CreateAssignmentDTOValidator : AbstractValidator<CreateAssignmentDTO>
{
    public CreateAssignmentDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(0, 30);
        RuleFor(dto => dto.Deadline)
            .GreaterThan(dto => dto.StartTime);
        RuleFor(dto => dto.BoardId)
            .NotEmpty();
    }
}