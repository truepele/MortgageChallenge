using Mortgage;
using Mortgage.Builder;
using Mortgage.MortgageProcessors;
using Xunit;

namespace MortgageTests
{
    public class Tests
    {
        private IMortgageProcessor BuildDefaultProcessor(double minimumDownpayment, double maxPropertyValue)
        {
            return new MortgageProcessorBuilder(new MortgageTypeMortgageProcessor())
                .And(new MinimumDownpaymentMortgageProcessor(minimumDownpayment))
                .And(new MaxPropertyValueMortgageProcessor(maxPropertyValue))
                .Build();
        }

        [Fact]
        public void VariableMortgageForFivePercentDownpaymentAndOverMillionDollarsValueDeclined()
        {
            // Arrange
            var mortgage = BuildDefaultProcessor(5, 2000000);
            var app = new MortgageApplication
            {
                DownpaymentPercentage = 5,
                MortgageType = MortgageType.Variable,
                PropertyValue = 1100000.00
            };
            // Act
            var actualResult = mortgage.ProcessApplication(app);

            // Assert
            Assert.Equal(MortgageApplicationResult.Declined, actualResult);
        }

        [Fact]
        public void FixedMortgageForFivePercentDownpaymentAndOverTwoMillionDollarsValueDeclined()
        {
            // Arrange
            var mortgage = BuildDefaultProcessor(5, 2000000);
            var app = new MortgageApplication
            {
                DownpaymentPercentage = 5,
                MortgageType = MortgageType.Fixed,
                PropertyValue = 2100000.00
            };
            // Act
            var actualResult = mortgage.ProcessApplication(app);
            // Assert
            Assert.Equal(MortgageApplicationResult.Declined, actualResult);
        }

        [Fact]
        public void FixedMortgageForFivePercentDownpaymentAndOverMillionDollarsValueApproved()
        {
            // Arrange
            var mortgage = BuildDefaultProcessor(5, 2000000);
            var app = new MortgageApplication
            {
                DownpaymentPercentage = 5,
                MortgageType = MortgageType.Fixed,
                PropertyValue = 1100000.00
            };
            // Act
            var actualResult = mortgage.ProcessApplication(app);
            // Assert
            Assert.Equal(MortgageApplicationResult.Approved, actualResult);
        }
    }
}
