using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class InvalidDate : Exception
{
    public InvalidDate()
    {

    }
    public InvalidDate(string message) : base(message)
    {
    }

    public InvalidDate(string message, Exception inner) : base(message, inner)
    {
    }

    protected InvalidDate(SerializationInfo info, StreamingContext context)
    : base(info, context)
    {
    }

}