using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class ThePasswordHasToBeDifferent : CoreBusinessException
{
    public ThePasswordHasToBeDifferent()
    {
    }

    public ThePasswordHasToBeDifferent(string msg) : base(msg)
    {
    }

    public ThePasswordHasToBeDifferent(string message, Exception inner) : base(message, inner)
    {
    }

    private ThePasswordHasToBeDifferent(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}