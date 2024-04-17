namespace Kaps.Domain.Exceptions;

public class KkbBadRequestException : BusinessException
{
    public KkbBadRequestException(string message, int code) : base(message, code.ToString())
    {
    }
}