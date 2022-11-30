using Organizer.Models.Exceptions.Base;

namespace Organizer.Models.Exceptions;

public class AssignmentNotFoundException : BaseCustomException
{
    public AssignmentNotFoundException(string cause, string message, Exception? innerException = null)
    : base(cause, message, innerException) { }
}