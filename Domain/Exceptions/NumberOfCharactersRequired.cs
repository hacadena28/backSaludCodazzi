using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class NumberOfCharactersRequired : CoreBusinessException
{
    public NumberOfCharactersRequired()
    {
    }

    public NumberOfCharactersRequired(string msg) : base(msg)
    {
    }

    public NumberOfCharactersRequired(string message, Exception inner) : base(message, inner)
    {
    }

    private NumberOfCharactersRequired(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}