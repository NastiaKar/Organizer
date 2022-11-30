using FluentValidation;
using Organizer.Models.DTOs.Assignment;

namespace Organizer.Validators;

public class UpdateAssignmentDTOValidator : AbstractValidator<UpdateAssignmentDTO>
{
    public UpdateAssignmentDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(0, 30);
        RuleFor(dto => dto.Deadline)
            .GreaterThan(dto => dto.StartTime);
    }
}