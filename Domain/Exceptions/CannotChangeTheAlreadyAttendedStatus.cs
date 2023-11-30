using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class CannotChangeTheAlreadyAttendedStatus : Exception
{
    public CannotChangeTheAlreadyAttendedStatus()
    {

    }
    public CannotChangeTheAlreadyAttendedStatus(string message) : base(message)
    {
    }

    public CannotChangeTheAlreadyAttendedStatus(string message, Exception inner) : base(message, inner)
    {
    }

    protected CannotChangeTheAlreadyAttendedStatus(SerializationInfo info, StreamingContext context)
    : base(info, context)
    {
    }

}