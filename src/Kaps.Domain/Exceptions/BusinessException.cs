using System.Runtime.Serialization;

namespace Kaps.Domain.Exceptions;

/// <summary>
/// Business Exception Class
/// </summary>
public class BusinessException : Exception
{
    private const string DefaultErrorCode = "400";
        
    /// <summary>
    /// Error Code
    /// </summary>
    public string ErrorCode { get; set; }

    /// <summary>
    /// Business exception with error code
    /// </summary>
    /// <param name="message"></param>
    /// <param name="code"></param>
    public BusinessException(string message, string code) : base(message)
    {
        this.ErrorCode = code;
    }

    /// <summary>
    /// Business Exception
    /// </summary>
    /// <param name="message"></param>
    public BusinessException(string message) : this(message, DefaultErrorCode)
    {
    }

    /// <summary>
    /// Const.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public BusinessException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Const.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}