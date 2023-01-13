using System.Runtime.Serialization;

namespace RayTracerChallenge.Features.Exceptions;

public class InvalidMatrixSizeException : Exception
{
    public InvalidMatrixSizeException()
    {
    }

    public InvalidMatrixSizeException(string? message) : base(message)
    {
    }

    public InvalidMatrixSizeException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected InvalidMatrixSizeException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
