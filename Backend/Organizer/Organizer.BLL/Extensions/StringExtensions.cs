using Organizer.Models;

namespace Organizer.BLL.Extensions;

public static class StringExtensions
{
    public static State ConvertToState(this string source)
    {
        bool parsed = Enum.TryParse(source, out State state);
        if (!parsed)
            throw new Exception("Unable to parse");
        return state;
    }
}