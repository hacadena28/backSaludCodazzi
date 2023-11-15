namespace Application.Common.Exceptions;

public class EntityNotFound : CustomException
{
    public EntityNotFound(string message)
        : base(message, null)
    {
    }
}