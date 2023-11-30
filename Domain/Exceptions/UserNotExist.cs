using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class UserNotExist : Exception
{
    public UserNotExist()
    {

    }
    public UserNotExist(string message) : base(message)
    {
    }

    public UserNotExist(string message, Exception inner) : base(message, inner)
    {
    }

    protected UserNotExist(SerializationInfo info, StreamingContext context)
    : base(info, context)
    {
    }

}