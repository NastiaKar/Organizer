using Organizer.Models.Exceptions.Base;

namespace Organizer.Models.Exceptions;

public class StepNotFoundException : BaseCustomException
{
    public StepNotFoundException(string cause, string message, Exception? innerException = null) 
        : base(cause, message, innerException) { }
}