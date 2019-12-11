using Core.DomainModel;
using NUnit.Framework;
using Services.WCFService;
using System;
using System.Threading.Tasks;

namespace Test.UnitTest.Services.WCFService
{
    [TestFixture]
    public class _convertorServiceTests
    {

        #region Properties

        private ConvertorService _convertorService { get; set; }

        #endregion /Properties

        #region Constructors

        public _convertorServiceTests()
            : base()
        {
        }

        #endregion /Constructors

        #region Methods

        [OneTimeSetUp]
        public void Setup()
        {
            this._convertorService = new ConvertorService();
        }

        [Test]
        public void ConvertNumberToWord_NullNumber_ThrowsNullOrWhiteSpaceException()
        {
            // Arrange
            string number = null;
            var expectedExceptionMessage = Constant.Exception_NullOrWhiteSpaceNumber;

            // Assert
            Assert.Throws<Exception>(() => this._convertorService.ConvertNumberToWordAsync(number), expectedExceptionMessage);
        }

        [Test]
        public void ConvertNumberToWord_EmptyNumber_ThrowsNullOrWhiteSpaceException()
        {
            // Arrange
            string number = string.Empty;
            var expectedExceptionMessage = Constant.Exception_NullOrWhiteSpaceNumber;

            // Assert
            Assert.Throws<Exception>(() => this._convertorService.ConvertNumberToWordAsync(number), expectedExceptionMessage);
        }

        [Test]
        public void ConvertNumberToWord_SpaceNumber_ThrowsNullOrWhiteSpaceException()
        {
            // Arrange
            string number = " ";
            var expectedExceptionMessage = Constant.Exception_NullOrWhiteSpaceNumber;

            // Assert
            Assert.Throws<Exception>(() => this._convertorService.ConvertNumberToWordAsync(number), expectedExceptionMessage);
        }

        [Test]
        public void ConvertNumberToWord_InvalidNumber_ThrowsInvalidNumberException()
        {
            // Arrange
            string number = "dgdfgdfg";
            var expectedExceptionMessage = Constant.Exception_InvalidNumber;

            // Assert
            Assert.Throws<Exception>(() => this._convertorService.ConvertNumberToWordAsync(number), expectedExceptionMessage);
        }

        [Test]
        public void ConvertNumberToWord_MinusNumber_ThrowsInvalidNumberException()
        {
            // Arrange
            string number = "-1";
            var expectedExceptionMessage = Constant.Exception_InvalidNumber;

            // Assert
            Assert.Throws<Exception>(() => this._convertorService.ConvertNumberToWordAsync(number), expectedExceptionMessage);
        }

        [Test]
        public void ConvertNumberToWord_TooBigNumber_ThrowsInvalidNumberException()
        {
            // Arrange
            string number = "9 999 999 999";
            var expectedExceptionMessage = Constant.Exception_InvalidNumber;

            // Assert
            Assert.Throws<Exception>(() => this._convertorService.ConvertNumberToWordAsync(number), expectedExceptionMessage);
        }

        [Test]
        public void ConvertNumberToWord_TooBigDecimalNumber_ThrowsInvalidNumberException()
        {
            // Arrange
            string number = "1,999";
            var expectedExceptionMessage = Constant.Exception_InvalidNumber;

            // Assert
            Assert.Throws<Exception>(() => this._convertorService.ConvertNumberToWordAsync(number), expectedExceptionMessage);
        }

        [Test]
        public async Task ConvertNumberToWord_ZeroNumber_ReturnsOK()
        {
            // Arrange
            string number = "0";
            var expectedResult = "zero dollars";

            //Act
            var result = await this._convertorService.ConvertNumberToWordAsync(number);

            // Assert
            Assert.AreEqual(expectedResult, result, "error in returning the correct value");
        }

        [Test]
        public async Task ConvertNumberToWord_OneNumber_ReturnsOK()
        {
            // Arrange
            string number = "1";
            var expectedResult = "one dollar";

            //Act
            var result = await this._convertorService.ConvertNumberToWordAsync(number);

            // Assert
            Assert.AreEqual(expectedResult, result, "error in returning the correct value");
        }

        [Test]
        public async Task ConvertNumberToWord_25Dollars10CentsNumber_ReturnsOK()
        {
            // Arrange
            string number = "25,1";
            var expectedResult = "twenty-five dollars and ten cents";

            //Act
            var result = await this._convertorService.ConvertNumberToWordAsync(number);

            // Assert
            Assert.AreEqual(expectedResult, result, "error in returning the correct value");
        }

        [Test]
        public async Task ConvertNumberToWord_OneCentNumber_ReturnsOK()
        {
            // Arrange
            string number = "0,01";
            var expectedResult = "zero dollars and one cent";

            //Act
            var result = await this._convertorService.ConvertNumberToWordAsync(number);

            // Assert
            Assert.AreEqual(expectedResult, result, "error in returning the correct value");
        }

        [Test]
        public async Task ConvertNumberToWord_45100DollarsNumber_ReturnsOK()
        {
            // Arrange
            string number = "45 100";
            var expectedResult = "forty-five thousand one hundred dollars";

            //Act
            var result = await this._convertorService.ConvertNumberToWordAsync(number);

            // Assert
            Assert.AreEqual(expectedResult, result, "error in returning the correct value");
        }

        [Test]
        public async Task ConvertNumberToWord_999999999Dollars99CentsNumber_ReturnsOK()
        {
            // Arrange
            string number = "999 999 999,99";
            var expectedResult = "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents";

            //Act
            var result = await this._convertorService.ConvertNumberToWordAsync(number);

            // Assert
            Assert.AreEqual(expectedResult, result, "error in returning the correct value");
        }

        #endregion /Methods

    }
}
