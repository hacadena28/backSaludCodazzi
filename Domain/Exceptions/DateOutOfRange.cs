using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class DateOutOfRange : Exception
{
    public DateOutOfRange()
    {

    }
    public DateOutOfRange(string message) : base(message)
    {
    }

    public DateOutOfRange(string message, Exception inner) : base(message, inner)
    {
    }

    protected DateOutOfRange(SerializationInfo info, StreamingContext context)
    : base(info, context)
    {
    }

}