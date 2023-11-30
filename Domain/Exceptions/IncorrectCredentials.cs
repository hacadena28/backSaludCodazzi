using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class IncorrectCredentials : Exception
{
    public IncorrectCredentials()
    {

    }
    public IncorrectCredentials(string message) : base(message)
    {
    }

    public IncorrectCredentials(string message, Exception inner) : base(message, inner)
    {
    }

    protected IncorrectCredentials(SerializationInfo info, StreamingContext context)
    : base(info, context)
    {
    }

}