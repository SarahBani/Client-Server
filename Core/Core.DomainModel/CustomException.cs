using System;

namespace Core.DomainModel
{

    public enum ExceptionKey
    {
        Unknown,
        ConnectionFailed,
        NullOrWhiteSpaceNumber,
        InvalidNumber,
        TooBigIntegerPart,
        TooBigFractionalPart
    }

    /// <summary>
    /// This class is used for handling custom exceptions & displaying appropriate messages
    /// </summary>
    public class CustomException : Exception
    {

        #region Properties

        public ExceptionKey ExceptionKey { get; private set; }

        public new string Message { get; private set; }

        #endregion /Properties

        #region Constructors

        public CustomException(ExceptionKey exceptionKey, params object[] args)
        {
            this.ExceptionKey = exceptionKey;
            this.Message = string.Format(GetMessage(), args);
        }

        public CustomException(string message)
        {
            this.Message = message;
        }

        #endregion /Constructors

        #region Methods

        private string GetMessage()
        {
            switch (ExceptionKey)
            {
                case ExceptionKey.NullOrWhiteSpaceNumber:
                    return Constant.Exception_NullOrWhiteSpaceNumber;
                case ExceptionKey.InvalidNumber:
                    return Constant.Exception_InvalidNumber;
                case ExceptionKey.TooBigIntegerPart:
                    return Constant.Exception_TooBigIntegerPart;
                case ExceptionKey.TooBigFractionalPart:
                    return Constant.Exception_TooBigFractionalPart;
                case ExceptionKey.ConnectionFailed:
                    return Constant.Exception_ConnectionFailed;
                case ExceptionKey.Unknown:
                default:
                    return Constant.Exception_HasError;
            }
        }

        #endregion /Methods

    }
}