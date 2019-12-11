using Core.DomainModel;
using Core.DomainService.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.WCFService
{
    public class ConvertorService : IConvertorService
    {

        #region Properties

        private readonly IDictionary<int, string> _generalNumbers = new Dictionary<int, string>
        {
            {0, "zero" },
            {1, "one" },
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
            {10, "ten"},
            {11, "eleven"},
            {12, "twelve"},
            {13, "thirteen"},
            {14, "forteen"},
            {15, "fifteen"},
            {16, "sixteen"},
            {17, "seventeen"},
            {18, "eighteen"},
            {19, "nineteen"},
            {20, "twenty"},
            {30, "thirty"},
            {40, "forty"},
            {50, "fifty"},
            {60, "sixty"},
            {70, "seventy"},
            {80, "eighty"},
            {90, "ninety"},
            {100, "hundred"},
            {1000, "thousand"},
            {1000000, "million"}
        };

        #endregion /Properties

        #region OperationContracts


        /// <summary>
        /// Convert Number to Word
        /// </summary>
        /// <param name="number">number in string</param>
        /// <returns></returns>
        public Task<string> ConvertNumberToWordAsync(string number)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(number))
                {
                    throw new CustomException(Constant.Exception_NullOrWhiteSpaceNumber);
                }
                number = CorrectNumber(number);
                float floatNumber;
                if (!float.TryParse(number, out floatNumber))
                {
                    throw new CustomException(Constant.Exception_InvalidNumber);
                }
                if (floatNumber < 0)
                {
                    throw new CustomException(Constant.Exception_InvalidNumber);
                }
                if (floatNumber > Constant.MaxIntegerNumber)
                {
                    throw new CustomException(Constant.Exception_TooBigIntegerPart);
                }

                return Task.FromResult(GetWord(number));
            }
            catch (CustomException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception)
            {
                throw new Exception(Constant.Exception_HasError);
            }
        }

        #endregion /OperationContracts

        #region Methods

        private string CorrectNumber(string number)
        {
            return number.Replace(" ", "") // remove spaces
                          .Replace(",", "."); // replace ',' with '.'
        }

        private string GetWord(string number)
        {
            string word = string.Empty;
            string[] parts = number.Split('.');
            int integerPart = int.Parse(parts[0]);
            word += ConvertNumberPartToWord(integerPart);
            word += GetIntegerCurrency(integerPart);

            if (parts.Length > 1)
            {
                int fractionalPart = int.Parse(parts[1].PadRight(2, '0'));
                if (fractionalPart > Constant.MaxFractionalNumber)
                {
                    throw new CustomException(Constant.Exception_TooBigFractionalPart);
                }
                if (fractionalPart > 0)
                {
                    word += Constant.Ampersand;
                    word += ConvertNumberPartToWord(fractionalPart);
                    word += GetFractionalCurrency(fractionalPart);
                }
            }
            return word;
        }

        private string GetIntegerCurrency(int number)
        {
            return string.Format(Constant.DollarCurrency, (number == 1 ? "" : "s"));
        }

        private string GetFractionalCurrency(int number)
        {
            return string.Format(Constant.CentCurrency, (number == 1 ? "" : "s"));
        }

        private string ConvertNumberPartToWord(int number)
        {
            if (number <= 20) // 0-20
            {
                return this._generalNumbers[number];
            }
            else
            {
                string word = string.Empty;
                if (number <= 99) // 21-99
                {
                    word += this._generalNumbers[(number / 10) * 10];
                    if ((number % 10) > 0)
                    {
                        word += Constant.TensNumberSeperator;
                        word += ConvertNumberPartToWord(number % 10);
                    }
                }
                else
                {
                    int numberLevel = 0;
                    if (number <= 999) // 100-999
                    {
                        numberLevel = 100;
                    }
                    else if (number <= 999999) // 1000-999999
                    {
                        numberLevel = 1000;
                    }
                    else if (number <= 999999999) // 1000000-999999999
                    {
                        numberLevel = 1000000;
                    }

                    word += ConvertNumberPartToWord(number / numberLevel);
                    word += Constant.Space;
                    word += this._generalNumbers[numberLevel];
                    if ((number % numberLevel) > 0)
                    {
                        word += Constant.Space;
                        word += ConvertNumberPartToWord(number % numberLevel);
                    }
                }

                return word;
            }
        }

        #endregion

    }
}
