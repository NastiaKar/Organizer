using FluentValidation;
using Organizer.Models.DTOs.Board;

namespace Organizer.Validators;

public class CreateBoardDTOValidator : AbstractValidator<CreateBoardDTO>
{
    public CreateBoardDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(0, 30);
    }
}