using Simulator;

namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(5, 0, 10, 5)]
        [InlineData(0, 0, 10, 0)]
        [InlineData(10, 0, 10, 10)]
        [InlineData(-5, 0, 10, 0)]
        [InlineData(15, 0, 10, 10)]
        public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
        {
            // Act
            int result = Validator.Limiter(value, min, max);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("shrek", 3, 10, '*', "Shrek")]
        [InlineData("shrek", 5, 5, '*', "Shrek")]
        [InlineData("shrek", 9, 10, '*', "Shrek****")]
        [InlineData("S", 5, 10, '*', "S****")]
        [InlineData("A B C", 8, 12, '*', "A B C***")]
        [InlineData("A B C", 7, 7, '*', "A B C**")]
        [InlineData("A B C", 5, 7, '*', "A B C")]
        [InlineData("a", 5, 10, '*', "A****")]
        [InlineData("a", 2, 10, '*', "A*")]
        public void Shortener_ShouldTrimAndFormatCorrectly(string input, int min, int max, char placeholder, string expected)
        {
            //Act
            string result = Validator.Shortener(input, min, max, placeholder);
            //Assert
            Assert.Equal(expected, result);
        }
    }
}