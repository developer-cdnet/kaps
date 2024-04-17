using System.Runtime.Serialization;

namespace Kaps.Domain.Exceptions;

/// <summary>
/// Unrecoverable Exception 
/// </summary>
[Serializable]
public abstract class UnrecoverableException : Exception
{
    /// <summary>
    /// Default Const.
    /// </summary>
    protected UnrecoverableException()
    {
    }
    
    /// <summary>
    /// Const.
    /// </summary>
    /// <param name="message"></param>
    protected UnrecoverableException(string message) : base(message)
    {
    }

    /// <summary>
    /// Const.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    protected UnrecoverableException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Const.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected UnrecoverableException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}