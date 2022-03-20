namespace I2P.NET.SAM.Exceptions
{
    internal class I2PException : Exception
    {
        public string ErrorCode { get; }
        public string RawMessage { get; }
        public I2PException(string message, string errorCode, string rawMessage = null) : base()
        {
            ErrorCode = errorCode;
            RawMessage = rawMessage;
        }
    }
}