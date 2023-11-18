using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class TheEmailIsNotValids : CoreBusinessException
{
    public TheEmailIsNotValids()
    {
    }

    public TheEmailIsNotValids(string msg) : base(msg)
    {
    }

    public TheEmailIsNotValids(string message, Exception inner) : base(message, inner)
    {
    }

    private TheEmailIsNotValids(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}