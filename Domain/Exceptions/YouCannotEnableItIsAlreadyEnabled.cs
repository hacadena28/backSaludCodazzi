using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class YouCannotEnableItIsAlreadyEnabled : CoreBusinessException
{
    public YouCannotEnableItIsAlreadyEnabled()
    {
    }


    public YouCannotEnableItIsAlreadyEnabled(string message) : base(message)
    {
    }

    public YouCannotEnableItIsAlreadyEnabled(string message, Exception inner) :
        base(message, inner)
    {
    }

    protected YouCannotEnableItIsAlreadyEnabled(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}