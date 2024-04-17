using System.Runtime.Serialization;

namespace Kaps.Domain.Exceptions;

public class MaxRetryCountExceedException : Exception
{
    public MaxRetryCountExceedException()
    {
    }

    public MaxRetryCountExceedException(string message) : base(message)
    {
    }

    public MaxRetryCountExceedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected MaxRetryCountExceedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}