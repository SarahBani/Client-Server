namespace Core.DomainModel
{
    public static class Constant
    {

        public const string TensNumberSeperator = "-";

        public const string DollarCurrency = " dollar{0}";

        public const string CentCurrency = " cent{0}";

        public const string Ampersand = " and ";

        public const string Space = " ";

        public const int MaxIntegerNumber = 999999999;

        public const int MaxFractionalNumber = 99;

        public const string WaitAlert = "Please wait ...";

        #region AppSetting

        public const string AppSetting_ConvertorServiceUrl = "ConvertorServiceUrl";

        #endregion /AppSetting

        #region Exceptions

        public const string Exception_HasError = "An error has occured!";

         public const string Exception_ConnectionFailed = "There is an error in connecting to the service!";

        public const string Exception_NullOrWhiteSpaceNumber = "The number is null or empty or space!";

        public const string Exception_InvalidNumber = "The number is invalid!";

        public const string Exception_TooBigIntegerPart = "The maximum number is 999 999 999!";

        public const string Exception_TooBigFractionalPart = "The maximum number of cents is 99!";

        #endregion /Exceptions  

    }
}
