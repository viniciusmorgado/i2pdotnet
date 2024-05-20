namespace I2P.NET.SAM.Exceptions;

internal class I2PException(string message, string errorCode, string rawMessage = null) : Exception()
{
    public string ErrorCode { get; } = errorCode;
    public string RawMessage { get; } = rawMessage;
}
