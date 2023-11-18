using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class TheDateIsNotValid : CoreBusinessException
{
    public TheDateIsNotValid()
    {
    }

    public TheDateIsNotValid(string msg) : base(msg)
    {
    }

    public TheDateIsNotValid(string message, Exception inner) : base(message, inner)
    {
    }

    private TheDateIsNotValid(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}