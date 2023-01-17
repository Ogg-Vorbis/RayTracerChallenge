using System.Runtime.Serialization;

namespace RayTracerChallenge.Features.Exceptions;

public class MatrixNotInvertibleException : Exception
{
    public MatrixNotInvertibleException()
    {
    }

    public MatrixNotInvertibleException(string? message) : base(message)
    {
    }

    public MatrixNotInvertibleException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected MatrixNotInvertibleException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
