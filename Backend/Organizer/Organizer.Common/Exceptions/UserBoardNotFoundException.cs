using Organizer.Models.Exceptions.Base;

namespace Organizer.Models.Exceptions;

public class UserBoardNotFoundException : BaseCustomException
{
    public UserBoardNotFoundException(string cause, string message, Exception? innerException = null)
        : base(cause, message, innerException) { }
}