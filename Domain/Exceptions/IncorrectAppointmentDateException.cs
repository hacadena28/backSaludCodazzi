using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class IncorrectAppointmentDateException : CoreBusinessException
{
    public IncorrectAppointmentDateException()
    {
    }

    public IncorrectAppointmentDateException(string msg) : base(msg)
    {
    }

    public IncorrectAppointmentDateException(string message, Exception inner) : base(message, inner)
    {
    }

    private IncorrectAppointmentDateException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}