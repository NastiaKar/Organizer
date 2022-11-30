using System.Xml;
using FluentValidation;
using Organizer.Models.DTOs.Board;

namespace Organizer.Validators;

public class UpdateBoardDTOValidator : AbstractValidator<UpdateBoardDTO>
{
    public UpdateBoardDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(0, 30);
    }   
}