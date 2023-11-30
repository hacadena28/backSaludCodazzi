using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class DateNotAvailable : Exception
{
    public DateNotAvailable()
    {

    }
    public DateNotAvailable(string message) : base(message)
    {
    }

    public DateNotAvailable(string message, Exception inner) : base(message, inner)
    {
    }

    protected DateNotAvailable(SerializationInfo info, StreamingContext context)
    : base(info, context)
    {
    }

}