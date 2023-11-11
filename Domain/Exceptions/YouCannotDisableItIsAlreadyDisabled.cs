using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class YouCannotDisableItIsAlreadyDisabled : CoreBusinessException
{
    public YouCannotDisableItIsAlreadyDisabled()
    {
    }


    public YouCannotDisableItIsAlreadyDisabled(string message) : base(message)
    {
    }

    public YouCannotDisableItIsAlreadyDisabled(string message, Exception inner) :
        base(message, inner)
    {
    }

    protected YouCannotDisableItIsAlreadyDisabled(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}