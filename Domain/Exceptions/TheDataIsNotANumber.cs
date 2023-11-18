using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class TheDataIsNotANumber : CoreBusinessException
{
    public TheDataIsNotANumber()
    {
    }

    public TheDataIsNotANumber(string msg) : base(msg)
    {
    }

    public TheDataIsNotANumber(string message, Exception inner) : base(message, inner)
    {
    }

    private TheDataIsNotANumber(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}